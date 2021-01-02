using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ionic.Zlib;
using PlayFab.Json;
using PlayFab.SharedModels;
using UnityEngine.Networking;

namespace PlayFab.Internal
{
	public class PlayFabUnityHttp : IPlayFabHttp
	{
		public bool SessionStarted { get; set; }

		public string AuthKey { get; set; }

		public string EntityToken { get; set; }

		public void InitializeHttp()
		{
		}

		public void Update()
		{
		}

		public void OnDestroy()
		{
		}

		public void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback)
		{
			SingletonMonoBehaviour<PlayFabHttp>.instance.StartCoroutine(PlayFabUnityHttp.SimpleCallCoroutine(fullUrl, null, successCallback, errorCallback));
		}

		public void SimplePutCall(string fullUrl, byte[] payload, Action successCallback, Action<string> errorCallback)
		{
			SingletonMonoBehaviour<PlayFabHttp>.instance.StartCoroutine(PlayFabUnityHttp.SimpleCallCoroutine(fullUrl, payload, delegate(byte[] result)
			{
				successCallback();
			}, errorCallback));
		}

		private static IEnumerator SimpleCallCoroutine(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
		{
			if (payload == null)
			{
				UnityWebRequest www = new UnityWebRequest(fullUrl)
				{
					downloadHandler = new DownloadHandlerBuffer(),
					method = "POST"
				};
				yield return www;
				if (!string.IsNullOrEmpty(www.error))
				{
					errorCallback(www.error);
				}
				else
				{
					successCallback(www.downloadHandler.data);
				}
			}
			else
			{
				UnityWebRequest putRequest = UnityWebRequest.Put(fullUrl, payload);
				putRequest.SendWebRequest();
				while (putRequest.uploadProgress < 1f && putRequest.downloadProgress < 1f)
				{
					yield return 1;
				}
				if (!string.IsNullOrEmpty(putRequest.error))
				{
					errorCallback(putRequest.error);
				}
				else
				{
					successCallback(null);
				}
			}
			yield break;
		}

		public void MakeApiCall(CallRequestContainer reqContainer)
		{
			reqContainer.RequestHeaders["Content-Type"] = "application/json";
			if (PlayFabSettings.CompressApiData)
			{
				reqContainer.RequestHeaders["Content-Encoding"] = "GZIP";
				reqContainer.RequestHeaders["Accept-Encoding"] = "GZIP";
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression))
					{
						gzipStream.Write(reqContainer.Payload, 0, reqContainer.Payload.Length);
					}
					reqContainer.Payload = memoryStream.ToArray();
				}
			}
			SingletonMonoBehaviour<PlayFabHttp>.instance.StartCoroutine(this.Post(reqContainer));
		}

		private IEnumerator Post(CallRequestContainer reqContainer)
		{
			UnityWebRequest www = new UnityWebRequest(reqContainer.FullUrl)
			{
				uploadHandler = new UploadHandlerRaw(reqContainer.Payload),
				downloadHandler = new DownloadHandlerBuffer(),
				method = "POST"
			};
			foreach (KeyValuePair<string, string> keyValuePair in reqContainer.RequestHeaders)
			{
				www.SetRequestHeader(keyValuePair.Key, keyValuePair.Value);
			}
			yield return www.SendWebRequest();
			if (!string.IsNullOrEmpty(www.error))
			{
				this.OnError(www.error, reqContainer);
			}
			else
			{
				try
				{
					byte[] data = www.downloadHandler.data;
					bool flag = data != null && data[0] == 31 && data[1] == 139;
					string response = "Unexpected error: cannot decompress GZIP stream.";
					if (!flag && data != null)
					{
						response = Encoding.UTF8.GetString(data, 0, data.Length);
					}
					if (flag)
					{
						MemoryStream stream = new MemoryStream(data);
						using (GZipStream gzipStream = new GZipStream(stream, CompressionMode.Decompress, false))
						{
							byte[] array = new byte[4096];
							using (MemoryStream memoryStream = new MemoryStream())
							{
								int count;
								while ((count = gzipStream.Read(array, 0, array.Length)) > 0)
								{
									memoryStream.Write(array, 0, count);
								}
								memoryStream.Seek(0L, SeekOrigin.Begin);
								StreamReader streamReader = new StreamReader(memoryStream);
								string response2 = streamReader.ReadToEnd();
								this.OnResponse(response2, reqContainer);
							}
						}
					}
					else
					{
						this.OnResponse(response, reqContainer);
					}
				}
				catch (Exception arg)
				{
					this.OnError("Unhandled error in PlayFabUnityHttp: " + arg, reqContainer);
				}
			}
			www.Dispose();
			yield break;
		}

		public int GetPendingMessages()
		{
			return this._pendingWwwMessages;
		}

		public void OnResponse(string response, CallRequestContainer reqContainer)
		{
			try
			{
				HttpResponseObject httpResponseObject = JsonWrapper.DeserializeObject<HttpResponseObject>(response);
				if (httpResponseObject.code == 200)
				{
					reqContainer.JsonResponse = JsonWrapper.SerializeObject(httpResponseObject.data);
					reqContainer.DeserializeResultJson();
					reqContainer.ApiResult.Request = reqContainer.ApiRequest;
					reqContainer.ApiResult.CustomData = reqContainer.CustomData;
					SingletonMonoBehaviour<PlayFabHttp>.instance.OnPlayFabApiResult(reqContainer.ApiResult);
					PlayFabDeviceUtil.OnPlayFabLogin(reqContainer.ApiResult);
					try
					{
						PlayFabHttp.SendEvent(reqContainer.ApiEndpoint, reqContainer.ApiRequest, reqContainer.ApiResult, ApiProcessingEventType.Post);
					}
					catch (Exception ex)
					{
					}
					try
					{
						reqContainer.InvokeSuccessCallback();
					}
					catch (Exception ex2)
					{
					}
				}
				else if (reqContainer.ErrorCallback != null)
				{
					reqContainer.Error = PlayFabHttp.GeneratePlayFabError(reqContainer.ApiEndpoint, response, reqContainer.CustomData);
					PlayFabHttp.SendErrorEvent(reqContainer.ApiRequest, reqContainer.Error);
					reqContainer.ErrorCallback(reqContainer.Error);
				}
			}
			catch (Exception ex3)
			{
			}
		}

		public void OnError(string error, CallRequestContainer reqContainer)
		{
			reqContainer.JsonResponse = error;
			if (reqContainer.ErrorCallback != null)
			{
				reqContainer.Error = PlayFabHttp.GeneratePlayFabError(reqContainer.ApiEndpoint, reqContainer.JsonResponse, reqContainer.CustomData);
				PlayFabHttp.SendErrorEvent(reqContainer.ApiRequest, reqContainer.Error);
				reqContainer.ErrorCallback(reqContainer.Error);
			}
		}

		private readonly int _pendingWwwMessages;
	}
}
