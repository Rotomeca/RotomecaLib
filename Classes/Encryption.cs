//V1
using System;
using System.IO;
using System.Security.Cryptography;

namespace RotomecaLib
{
  public class Encryption
  {
    private byte[] Key = { 123, 196, 29, 24, 26, 17, 218, 19, 11, 24, 162, 37, 112, 222, 209, 26, 236, 53, 209, 85, 45, 114, 184, 217, 53, 27, 241, 24, 175, 144, 173, 131 };
    private byte[] Vector = { 146, 252, 111, 231, 121, 32, 23, 3, 113, 112, 79, 64, 191, 119, 114, 156 };

    private ICryptoTransform EncryptorTransform, DecryptorTransform;
    private System.Text.UTF8Encoding UTFEncoder;

    public Encryption(string key)
    {

      RijndaelManaged rm = new RijndaelManaged();

      key = (key).Substring(0, 16);
      Vector = System.Text.Encoding.ASCII.GetBytes(key);

      EncryptorTransform = rm.CreateEncryptor(Key, Vector);
      DecryptorTransform = rm.CreateDecryptor(Key, Vector);

      UTFEncoder = new System.Text.UTF8Encoding();
    }

    public Encryption UpdateKey(byte[] newKeys)
    {
      Key = newKeys;
      return this;
    }

    public string EncryptToString(string TextValue)
    {
      return ByteArrToString(Encrypt(TextValue));
    }

    public byte[] Encrypt(string TextValue)
    {
      Byte[] bytes = UTFEncoder.GetBytes(TextValue);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cs = new CryptoStream(memoryStream, EncryptorTransform, CryptoStreamMode.Write);

      cs.Write(bytes, 0, bytes.Length);
      cs.FlushFinalBlock();
      memoryStream.Position = 0;

      byte[] encrypted = new byte[memoryStream.Length];

      memoryStream.Read(encrypted, 0, encrypted.Length);
      cs.Close();
      memoryStream.Close();

      return encrypted;
    }

    public string DecryptString(string EncryptedString)
    {
      try
      {
        return Decrypt(StrToByteArray(EncryptedString));
      }
      catch (Exception) { return "Erreur de format !"; }
    }
 

    public string Decrypt(byte[] EncryptedValue)
    {
      MemoryStream encryptedStream = new MemoryStream();
      CryptoStream decryptStream = new CryptoStream(encryptedStream, DecryptorTransform, CryptoStreamMode.Write);

      decryptStream.Write(EncryptedValue, 0, EncryptedValue.Length);
      decryptStream.FlushFinalBlock();
      encryptedStream.Position = 0;

      Byte[] decryptedBytes = new Byte[encryptedStream.Length];

      encryptedStream.Read(decryptedBytes, 0, decryptedBytes.Length);
      encryptedStream.Close();

      return UTFEncoder.GetString(decryptedBytes);

    }


    public byte[] StrToByteArray(string str)
    {

      if (str.Length == 0) throw new Exception("Invalid string value in StrToByteArray");

      byte val;
      byte[] byteArr = new byte[str.Length / 3];
      int i = 0;
      int j = 0;

      do
      {
        val = byte.Parse(str.Substring(i, 3));
        byteArr[j++] = val;
        i += 3;
      } while (i < str.Length);

      return byteArr;
    }

    public string ByteArrToString(byte[] byteArr)
    {
      byte val;
      string tempStr = "";

      for (int i = 0; i <= byteArr.GetUpperBound(0); i++)
      {
        val = byteArr[i];

        if (val < 10) tempStr += "00" + val.ToString();
        else if (val < 100) tempStr += "0" + val.ToString();
        else tempStr += val.ToString();
      }

      return tempStr;
    }
  }

}
