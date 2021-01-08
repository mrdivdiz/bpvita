using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using PlayFab.Internal;
using UnityEngine;

namespace PlayFab.Public
{
	public abstract class PlayFabLoggerBase : IPlayFabLogger
	{
		protected PlayFabLoggerBase()
		{
			PlayFabDataGatherer playFabDataGatherer = new PlayFabDataGatherer();
			string item = playFabDataGatherer.GenerateReport();
			object logMessageQueue = this.LogMessageQueue;
			lock (logMessageQueue)
			{
				this.LogMessageQueue.Enqueue(item);
			}
		}

		public IPAddress ip { get; set; }

		public int port { get; set; }

		public string url { get; set; }

		public virtual void OnEnable()
		{
			SingletonMonoBehaviour<PlayFabHttp>.instance.StartCoroutine(this.RegisterLogger());
		}

		private IEnumerator RegisterLogger()
		{
			yield return new WaitForEndOfFrame();
			if (!string.IsNullOrEmpty(PlayFabSettings.LoggerHost))
			{
				Application.logMessageReceivedThreaded += this.HandleUnityLog;
			}
			yield break;
		}

		public virtual void OnDisable()
		{
			if (!string.IsNullOrEmpty(PlayFabSettings.LoggerHost))
			{
				Application.logMessageReceivedThreaded -= this.HandleUnityLog;
			}
		}

		public virtual void OnDestroy()
		{
			this._isApplicationPlaying = false;
		}

		protected abstract void BeginUploadLog();

		protected abstract void UploadLog(string message);

		protected abstract void EndUploadLog();

		private void HandleUnityLog(string message, string stacktrace, LogType type)
		{
			if (!PlayFabSettings.EnableRealTimeLogging)
			{
				return;
			}
			PlayFabLoggerBase.Sb.Length = 0;
			if (type == LogType.Log || type == LogType.Warning)
			{
				PlayFabLoggerBase.Sb.Append(type).Append(": ").Append(message);
				message = PlayFabLoggerBase.Sb.ToString();
				object logMessageQueue = this.LogMessageQueue;
				lock (logMessageQueue)
				{
					this.LogMessageQueue.Enqueue(message);
				}
			}
			else if (type == LogType.Error || type == LogType.Exception)
			{
				PlayFabLoggerBase.Sb.Append(type).Append(": ").Append(message).Append("\n").Append(stacktrace).Append(StackTraceUtility.ExtractStackTrace());
				message = PlayFabLoggerBase.Sb.ToString();
				object logMessageQueue2 = this.LogMessageQueue;
				lock (logMessageQueue2)
				{
					this.LogMessageQueue.Enqueue(message);
				}
			}
			this.ActivateThreadWorker();
		}

		private void ActivateThreadWorker()
		{
			object threadLock = this._threadLock;
			lock (threadLock)
			{
				if (this._writeLogThread == null)
				{
					this._writeLogThread = new Thread(new ThreadStart(this.WriteLogThreadWorker));
					this._writeLogThread.Start();
				}
			}
		}

		private void WriteLogThreadWorker()
		{
			try
			{
				object threadLock = this._threadLock;
				lock (threadLock)
				{
					this._threadKillTime = DateTime.UtcNow + PlayFabLoggerBase._threadKillTimeout;
				}
				Queue<string> queue = new Queue<string>();
				bool flag;
				do
				{
					object logMessageQueue = this.LogMessageQueue;
					lock (logMessageQueue)
					{
						this._pendingLogsCount = this.LogMessageQueue.Count;
						while (this.LogMessageQueue.Count > 0)
						{
							queue.Enqueue(this.LogMessageQueue.Dequeue());
						}
					}
					this.BeginUploadLog();
					while (queue.Count > 0)
					{
						this.UploadLog(queue.Dequeue());
					}
					this.EndUploadLog();
					object threadLock2 = this._threadLock;
					lock (threadLock2)
					{
						DateTime utcNow = DateTime.UtcNow;
						if (this._pendingLogsCount > 0 && this._isApplicationPlaying)
						{
							this._threadKillTime = utcNow + PlayFabLoggerBase._threadKillTimeout;
						}
						flag = (utcNow <= this._threadKillTime);
						if (!flag)
						{
							this._writeLogThread = null;
						}
					}
					Thread.Sleep(10000);
				}
				while (flag);
			}
			catch
			{
				this._writeLogThread = null;
			}
		}

		private static readonly StringBuilder Sb = new StringBuilder();

		private readonly Queue<string> LogMessageQueue = new Queue<string>();

		private const int LOG_CACHE_INTERVAL_MS = 10000;

		private Thread _writeLogThread;

		private readonly object _threadLock = new object();

		private static readonly TimeSpan _threadKillTimeout = TimeSpan.FromSeconds(60.0);

		private DateTime _threadKillTime = DateTime.UtcNow + PlayFabLoggerBase._threadKillTimeout;

		private bool _isApplicationPlaying = true;

		private int _pendingLogsCount;
	}
}
