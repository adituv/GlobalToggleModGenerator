using System.Text.Json.Serialization;

namespace GlobalToggleModGenerator.Model.Penumbra;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    Male,
    Female
}