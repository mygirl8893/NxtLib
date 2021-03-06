﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace NxtLib.Internal
{
    internal class ByteToHexStringConverter : JsonConverter
    {
        internal static string ToHexString(IEnumerable<byte> bytes)
        {
            return BitConverter.ToString(bytes.ToArray()).Replace("-", "").ToLowerInvariant();
        }

        internal static IEnumerable<byte> ToBytes(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            return bytes;
        }

        internal static IEnumerable<byte> ToBytesFromHexString(string hexString)
        {
            var numberChars = hexString.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return bytes;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                if (objectType == typeof(IEnumerable<byte>))
                {
                    return ToBytesFromHexString(reader.Value.ToString());
                }
                if (objectType == typeof (BinaryHexString))
                {
                    return new BinaryHexString(reader.Value.ToString());
                }
                if (objectType == typeof(UnencryptedMessage))
                {
                    return new UnencryptedMessage(reader.Value.ToString());
                }
            }
            throw new NotSupportedException($"objectType {objectType} and TokenType {reader.TokenType} is not supported");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
