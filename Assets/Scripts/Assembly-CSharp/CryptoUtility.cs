using System.IO;
using System.Security.Cryptography;

public class CryptoUtility
{
	public CryptoUtility(string key)
	{
		byte[] salt = new byte[]
		{
			82,
			166,
			66,
			87,
			146,
			51,
			179,
			108,
			242,
			110,
			98,
			237,
			124
		};
		Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(key, salt);
		this.m_keyBytes = rfc2898DeriveBytes.GetBytes(32);
		this.m_ivBytes = rfc2898DeriveBytes.GetBytes(16);
	}

	public byte[] Encrypt(byte[] clearTextBytes)
	{
		byte[] result;
		using (AesManaged aesManaged = new AesManaged())
		{
			aesManaged.Key = this.m_keyBytes;
			aesManaged.IV = this.m_ivBytes;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesManaged.CreateEncryptor(), CryptoStreamMode.Write))
				{
					cryptoStream.Write(clearTextBytes, 0, clearTextBytes.Length);
					cryptoStream.FlushFinalBlock();
					memoryStream.Position = 0L;
					byte[] array = new byte[memoryStream.Length];
					memoryStream.Read(array, 0, array.Length);
					result = array;
				}
			}
		}
		return result;
	}

	public byte[] Decrypt(byte[] encryptedBytes, int offset)
	{
		byte[] result;
		using (AesManaged aesManaged = new AesManaged())
		{
			aesManaged.Key = this.m_keyBytes;
			aesManaged.IV = this.m_ivBytes;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesManaged.CreateDecryptor(), CryptoStreamMode.Write))
				{
					cryptoStream.Write(encryptedBytes, offset, encryptedBytes.Length - offset);
					cryptoStream.FlushFinalBlock();
					memoryStream.Position = 0L;
					byte[] array = new byte[memoryStream.Length];
					memoryStream.Read(array, 0, array.Length);
					result = array;
				}
			}
		}
		return result;
	}

	public static byte[] ComputeHash(byte[] data)
	{
		return CryptoUtility.m_sha1Service.ComputeHash(data);
	}

	public byte[] ComputeHash(byte[] data, int offset, int count)
	{
		return CryptoUtility.m_sha1Service.ComputeHash(data, offset, count);
	}

	private byte[] m_keyBytes;

	private byte[] m_ivBytes;

	private static SHA1CryptoServiceProvider m_sha1Service = new SHA1CryptoServiceProvider();
}
