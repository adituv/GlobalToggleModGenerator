using System.Text.Json;
using System.Text.Json.Serialization;

namespace GlobalToggleModGenerator;

public class JsonStringNumberConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(float) || typeToConvert == typeof(double)
                                              || typeToConvert == typeof(int) || typeToConvert == typeof(uint)
                                              || typeToConvert == typeof(short) || typeToConvert == typeof(ushort)
                                              || typeToConvert == typeof(long) || typeToConvert == typeof(ulong);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return (JsonConverter)Activator.CreateInstance(typeof(JsonStringNumberConverterInner<>).MakeGenericType(typeToConvert))!;
    }

    private class JsonStringNumberConverterInner<T> : JsonConverter<T> where T : struct
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var numberAsString = reader.GetString();
            if (numberAsString == null)
            {
                if (reader.TokenType != JsonTokenType.String)
                {
                    throw new JsonException($"Invalid token type {reader.TokenType}, expected {JsonTokenType.String}");
                }
                else
                {
                    throw new JsonException("Failed to read string from JSON");
                }
            }

            if (typeof(T) == typeof(float))
            {
                if (!float.TryParse(numberAsString, out float value))
                {
                    throw new JsonException($"Failed to parse \"{numberAsString}\" as a floating point value.");
                }

                return (T)(object)value;
            }
            
            if (typeof(T) == typeof(double))
            {
                if (!double.TryParse(numberAsString, out double value))
                {
                    throw new JsonException($"Failed to parse \"{numberAsString}\" as a floating point value.");
                }

                return (T)(object)value;
            }
            
            if (typeof(T) == typeof(int))
            {
                if (!int.TryParse(numberAsString, out int value))
                {
                    throw new JsonException($"Failed to parse \"{numberAsString}\" as a floating point value.");
                }

                return (T)(object)value;
            }
            
            if (typeof(T) == typeof(uint))
            {
                if (!uint.TryParse(numberAsString, out uint value))
                {
                    throw new JsonException($"Failed to parse \"{numberAsString}\" as a floating point value.");
                }

                return (T)(object)value;
            }
            
            if (typeof(T) == typeof(short))
            {
                if (!short.TryParse(numberAsString, out short value))
                {
                    throw new JsonException($"Failed to parse \"{numberAsString}\" as a floating point value.");
                }

                return (T)(object)value;
            }
            
            if (typeof(T) == typeof(ushort))
            {
                if (!ushort.TryParse(numberAsString, out ushort value))
                {
                    throw new JsonException($"Failed to parse \"{numberAsString}\" as a floating point value.");
                }

                return (T)(object)value;
            }
            
            if (typeof(T) == typeof(long))
            {
                if (!long.TryParse(numberAsString, out long value))
                {
                    throw new JsonException($"Failed to parse \"{numberAsString}\" as a floating point value.");
                }

                return (T)(object)value;
            }
            
            if (typeof(T) == typeof(ulong))
            {
                if (!ulong.TryParse(numberAsString, out ulong value))
                {
                    throw new JsonException($"Failed to parse \"{numberAsString}\" as a floating point value.");
                }

                return (T)(object)value;
            }
            
            throw new JsonException($"Unsupported type {typeof(T)}");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}