using System.Text.Json.Serialization;

namespace GlobalToggleModGenerator.Model.Penumbra;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EquipSlot
{
    Head,
    Body,
    Hands,
    Legs,
    Feet,
    Ears,
    Neck,
    Wrists,
    RFinger,
    LFinger
}
