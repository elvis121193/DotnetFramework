﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dotnet.Serializing
{
    /// <summary>使用系统默认的二进制序列化方式进行序列化
    /// </summary>
    public class DefaultBinarySerializer : IBinarySerializer
    {
        private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();

        /// <summary> 将对象序列化成二进制
        /// </summary>
        public byte[] Serialize(object obj)
        {
            using (var stream = new MemoryStream())
            {
                _binaryFormatter.Serialize(stream, obj);
                stream.Position = 0;
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                _binaryFormatter.Serialize(stream, obj);
                return bytes;
            }
        }

        /// <summary> 将二进制反序列化成byte
        /// </summary>
        public object Deserialize(byte[] data, Type type)
        {
            using (var stream = new MemoryStream(data))
            {
                stream.Position = 0;
                return _binaryFormatter.Deserialize(stream);
            }
        }
        /// <summary> 将二进制反序列化成对象
        /// </summary>
        public T Deserialize<T>(byte[] data) where T : class
        {
            using (var stream = new MemoryStream(data))
            {
                stream.Position = 0;
                return _binaryFormatter.Deserialize(stream) as T;
            }
        }
    }
}
