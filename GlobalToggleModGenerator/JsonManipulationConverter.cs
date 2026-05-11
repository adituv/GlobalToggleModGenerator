using System.Text.Json;
using System.Text.Json.Serialization;
using GlobalToggleModGenerator.Model.Penumbra;

namespace GlobalToggleModGenerator;

public class JsonManipulationConverter : JsonConverter<Manipulation>
{
    public override Manipulation? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Manipulation value, JsonSerializerOptions options)
    {
        var typeConverter = (JsonConverter<ManipulationType>)options.GetConverter(typeof(ManipulationType));
        
        writer.WriteStartObject();
        writer.WritePropertyName("Type");
        typeConverter.Write(writer, value.Type, options);
        
        writer.WritePropertyName("Manipulation");
        var converter = options.GetConverter(value.ManipulationInner.GetType());
        var writeMethod = converter.GetType().GetMethod("Write")!;
        writeMethod.Invoke(converter, [writer, value.ManipulationInner, options]);
        
        writer.WriteEndObject();
    }
}