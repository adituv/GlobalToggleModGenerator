using System.Text.Json.Serialization;

namespace GlobalToggleModGenerator.Model.Penumbra;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GroupType
{
    Single,
    Multi,
    Combining,
    IMC
}
