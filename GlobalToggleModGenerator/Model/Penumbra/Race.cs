using System.Text.Json.Serialization;

namespace GlobalToggleModGenerator.Model.Penumbra;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Race
{
    Midlander,
    Highlander,
    Elezen,
    Lalafell,
    Miqote,
    Roegadyn,
    AuRa,
    Hrothgar,
    Viera
}