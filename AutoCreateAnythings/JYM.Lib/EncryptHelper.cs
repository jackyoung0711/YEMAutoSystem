using System;
using System.Security.Cryptography;
using System.Text;
using Moe.Lib;
using Crypto = J.Base.Lib.Security.Crypto;

namespace JYM.Lib
{
    /// <summary>
    ///     Class EncryptHelper.
    /// </summary>
    public static class EncryptHelper
    {
        /// <summary>
        ///     加密数据兼容性处理
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="length">The length.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string ToCompatibleDecryptString(this string str, int length, string salt)
        {
            return str?.Length > length ? str.ToDecryptString(salt) : str;
        }

        /// <summary>
        ///     待加密数据兼容性处理
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="length">The length.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string ToCompatibleEncryptString(this string str, int length, string salt)
        {
            return str?.Length > length ? str : str.ToEncryptString(salt);
        }

        /// <summary>
        ///     不对空字符串解密
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string ToDecryptString(this string str, string salt)
        {
            try
            {
                return str.IsNullOrWhiteSpace() ? str : Crypto.DecryptString(str, salt);
            }
            catch (Exception)
            {
                return str;
            }
        }

        /// <summary>
        ///     不对空字符串加密
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string ToEncryptString(this string str, string salt)
        {
            try
            {
                return str.IsNullOrWhiteSpace() ? str : Crypto.EncryptString(str, salt);
            }
            catch (Exception)
            {
                return str;
            }
        }

        /// <summary>
        ///     ms the d5 string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string ToMD5String(this string str, string salt)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(str, salt)));
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        #region base64加密解密

        /// <summary>
        ///     Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(string result)
        {
            return Base64Decode(Encoding.UTF8, result);
        }

        /// <summary>
        ///     Base64解密
        /// </summary>
        /// <param name="encodeType">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(Encoding encodeType, string result)
        {
            string decode = string.Empty;
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encodeType.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        /// <summary>
        ///     Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string Base64Encode(string source)
        {
            return Base64Encode(Encoding.UTF8, source);
        }

        /// <summary>
        ///     Base64加密
        /// </summary>
        /// <param name="encodeType">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string Base64Encode(Encoding encodeType, string source)
        {
            string encode = string.Empty;
            byte[] bytes = encodeType.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;
        }

        #endregion base64加密解密
    }
}