using System.Text.Json.Serialization;

namespace GlobalToggleModGenerator.Model.Penumbra;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ManipulationType
{
    [JsonStringEnumMemberName("Eqp")]
    Equipment,
    [JsonStringEnumMemberName("Eqdp")]
    RacialToggle,
    /*
    Variant,
    Skeleton,
    Gimmick,
    RacialScale,
    Attachment,
    Shape,
    Attribute,
    GlobalEquipment
    */
}