using System;
using System.Security.Cryptography;

namespace Cryptography
{
/// <summary>
///Encryption class secures the code for octane8.
/// </summary>

	public class Encryption
	{
/// <summary>
///Class variable to hold an array of key values.
/// </summary>

		private static byte[] _key = null;
/// <summary>
///Class variable to hold an array of key values.
/// </summary>

//		private static byte[] _key = new byte[16]
//			{
//				54, 38, 94, 254, 25, 81, 79, 2, 105, 193, 201, 45, 93, 251, 114, 99	
//			};
/// <summary>
///Class variable to hold an array of key values as a string for securing the octane's product.
/// </summary>

		private static string _key_string = "54,38,94,254,25,81,79,2,105,193,201,45,93,251,114,99";
/// <summary>
///Class variable to hold the encryption object as an array.
/// </summary>

		private static byte[] _iv = null;
/// <summary>
///Class variable to hold the encryption object as an array.
/// </summary>

//		private static byte[] _iv = new byte[16]
//			{
//				2, 4, 63, 59, 154, 67, 39, 214, 55, 156, 102, 43, 252, 211, 42, 111
//			};
/// <summary>
///Class variable to hold the array of id's for securing the octane's product.
/// </summary>

		private static string _iv_string = "2,4,63,59,154,67,39,214,55,156,102,43,252,211,42,111";
/// <summary>
///Class variable to hold an array for license.
/// </summary>

		private static byte[] _licenseKey = null;
/// <summary>
///Class variable to hold an array for license.
/// </summary>

//		private static byte[] _licenseKey = new byte[16]
//			{
//				51, 38, 94, 254, 25, 81, 79, 2, 102, 193, 201, 47, 93, 211, 13, 99	
//			};
/// <summary>
///Class variable which has the license keys for octane product.
/// </summary>

		private static string _licenseKey_string = "51,38,94,254,25,81,79,2,102,193,201,47,93,211,13,99";
/// <summary>
///Class variable to hold an array for license.
/// </summary>

		private static byte[] _licenseIv = null;
/// <summary>
///Class variable to hold an array for license.
/// </summary>

//		private static byte[] _licenseIv = new byte[16]
//			{
//				2, 2, 63, 59, 153, 7, 39, 214, 55, 56, 12, 43, 25, 21, 42, 11
//			};
/// <summary>
///Class variable which has the license keys for octane product.
/// </summary>

		private static string _licenseIv_string = "2,2,63,59,153,7,39,214,55,56,12,43,25,21,42,11";
/// <summary>
///Retrieves the set of key for the octane product.
/// </summary>

		private static byte[] key
		{
			get
			{
				if (Encryption._key == null)
				{
					string[] keyArray = Encryption._key_string.Split(',');
					Encryption._key = new byte[16];
					for (int i = 0; i < keyArray.Length; i++)
					{
						Encryption._key[i] = Convert.ToByte(keyArray[i]);
					}
				}
				return (Encryption._key);
			}
		}
/// <summary>
///Retrieves the set of visitors for the octane product.
/// </summary>

		private static byte[] iv
		{
			get
			{
				if (Encryption._iv == null)
				{
					string[] keyArray = Encryption._iv_string.Split(',');
					Encryption._iv = new byte[16];
					for (int i = 0; i < keyArray.Length; i++)
					{
						Encryption._iv[i] = Convert.ToByte(keyArray[i]);
					}
				}
				return (Encryption._iv);
			}
		}
/// <summary>
///Retrieves the set of license keys for the octane product.
/// </summary>

		private static byte[] licenseKey
		{
			get
			{
				if (Encryption._licenseKey == null)
				{
					string[] keyArray = Encryption._licenseKey_string.Split(',');
					Encryption._licenseKey = new byte[16];
					for (int i = 0; i < keyArray.Length; i++)
					{
						Encryption._licenseKey[i] = Convert.ToByte(keyArray[i]);
					}
				}
				return (Encryption._licenseKey);
			}
		}
/// <summary>
///Retrieves the set of license lv's for the octane product.
/// </summary>

		private static byte[] licenseIv
		{
			get
			{
				if (Encryption._licenseIv == null)
				{
					string[] keyArray = Encryption._licenseIv_string.Split(',');
					Encryption._licenseIv = new byte[16];
					for (int i = 0; i < keyArray.Length; i++)
					{
						Encryption._licenseIv[i] = Convert.ToByte(keyArray[i]);
					}
				}
				return (Encryption._licenseIv);
			}
		}


/// <summary>
///Sets string to octane8 5.0 encryption style.
/// </summary>
/// <param name="dataString">String to be encrypted.</param>
/// <returns>Encrypted string</returns>

		public static string Encrypt (string dataString) 
		{
			byte[] dataStringByteArray = System.Text.Encoding.UTF8.GetBytes(dataString);
			System.Security.Cryptography.Rijndael securityAlg = Rijndael.Create();
			
			securityAlg.IV = Encryption.iv;
			securityAlg.Key = Encryption.key;
			System.IO.MemoryStream ms = new System.IO.MemoryStream();
			
			System.Security.Cryptography.CryptoStream cs_base64 = new CryptoStream(ms, new ToBase64Transform(), CryptoStreamMode.Write);
			System.Security.Cryptography.CryptoStream cs = new CryptoStream(cs_base64, securityAlg.CreateEncryptor(Encryption.key, Encryption.iv), CryptoStreamMode.Write);
			cs.Write(dataStringByteArray, 0, dataStringByteArray.Length);
			cs.Close();
			byte[] cypherTextByteArray = ms.ToArray();
			string cypherText = System.Text.Encoding.UTF8.GetString(cypherTextByteArray);
			return (cypherText);
		}
/// <summary>
///Decodes string from octane8 5.0 encryption style.
/// </summary>
/// <param name="dataString">String to be decrypted.</param>
/// <returns>Decrypted string.</returns>

        public static string Decrypt(string dataString) 
		{
			string cypherText = dataString;
			byte[] dataStringByteArray = System.Text.Encoding.UTF8.GetBytes(dataString);
			System.Security.Cryptography.Rijndael securityAlg = Rijndael.Create();
	
			securityAlg.IV = Encryption.iv;
			securityAlg.Key = Encryption.key;
			System.IO.MemoryStream ms = new System.IO.MemoryStream();
			System.Security.Cryptography.CryptoStream cs_tmp = new CryptoStream(ms, securityAlg.CreateDecryptor(Encryption.key, Encryption.iv), CryptoStreamMode.Write);
			System.Security.Cryptography.CryptoStream cs = new CryptoStream(cs_tmp, new FromBase64Transform(), CryptoStreamMode.Write);
			byte[] cypherTextByteArray = System.Text.Encoding.UTF8.GetBytes(dataString);
			cs.Write(cypherTextByteArray, 0, cypherTextByteArray.Length);
			cs.Close();
			byte[] roundTripText = ms.ToArray();
			cypherText = System.Text.Encoding.UTF8.GetString(roundTripText);
			return (cypherText);
		}
/// <summary>
///Decodes octane8 license file.
/// </summary>
/// <param name="dataString">String to be decrypted.</param>
/// <returns>Decrypted string.</returns>

		internal static string DecryptLicense (string dataString) 
		{
			string cypherText = dataString;
			byte[] dataStringByteArray = System.Text.Encoding.UTF8.GetBytes(dataString);
			System.Security.Cryptography.Rijndael securityAlg = Rijndael.Create();
	
			securityAlg.IV = Encryption.licenseIv;
			securityAlg.Key = Encryption.licenseKey;
			System.IO.MemoryStream ms = new System.IO.MemoryStream();
			System.Security.Cryptography.CryptoStream cs_tmp = new CryptoStream(ms, securityAlg.CreateDecryptor(Encryption.licenseKey, Encryption.licenseIv), CryptoStreamMode.Write);
			System.Security.Cryptography.CryptoStream cs = new CryptoStream(cs_tmp, new FromBase64Transform(), CryptoStreamMode.Write);
			byte[] cypherTextByteArray = System.Text.Encoding.UTF8.GetBytes(dataString);
			cs.Write(cypherTextByteArray, 0, cypherTextByteArray.Length);
			cs.Close();
			byte[] roundTripText = ms.ToArray();
			cypherText = System.Text.Encoding.UTF8.GetString(roundTripText);
			
			return (cypherText);
		}
        /*Aswith 14 Feb 2007 
        Bug Fix:Encrypted Password copied from the Database is accepted in the Enterprise Login Page*/
        public static bool Match(string encryptedStringDbase, string encryptedStringText, bool caseSensitive)
        {
            bool returnValue = false;
            if (caseSensitive)
            {
                returnValue = (encryptedStringText == encryptedStringDbase);
            }
            else
            {
                returnValue = (encryptedStringText.ToUpper() == encryptedStringDbase.ToUpper());
            }
            return (returnValue);
        }
/// <summary>
///Compares an encrypted string to an unencrypted string.
/// </summary>
/// <param name="encryptedString">Encrypted string.</param>
/// <param name="unencryptedString">Unencrypted string.</param>
/// <returns>true or false</returns>

		public static bool Match (string encryptedString, string unencryptedString) 
		{
			return (Match(encryptedString, unencryptedString, true));
		}
	}
}
