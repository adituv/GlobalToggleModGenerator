using System.Text.Json.Serialization;

namespace GlobalToggleModGenerator.Model.Penumbra;

[JsonConverter(typeof(JsonManipulationConverter))]
public class Manipulation
{
    public ManipulationType Type { get; }

    [JsonPropertyName("Manipulation")]
    public ManipulationImpl ManipulationInner { get; }

    public Manipulation(EqpManipulationImpl impl)
    {
        Type = ManipulationType.Equipment;
        ManipulationInner = impl;
    }

    public Manipulation(EqdpManipulationImpl impl)
    {
        Type = ManipulationType.RacialToggle;
        ManipulationInner = impl;
    }
}

// Empty base class for all inner "Manipulation" fields.  
public class ManipulationImpl
{
    
}

public class EqdpManipulationImpl : ManipulationImpl
{
    public ulong Entry { get; set; }
    public Gender Gender { get; set; }
    public Race Race { get; set; }
    
    [JsonConverter(typeof(JsonStringNumberConverter))]
    public int SetId { get; set; }
    public EquipSlot Slot { get; set; }
}

public class EqpManipulationImpl : ManipulationImpl
{
    [JsonConverter(typeof(JsonStringNumberConverter))]
    public ulong Entry { get; set; }
    [JsonConverter(typeof(JsonStringNumberConverter))]
    public int SetId { get; set; }

    public EquipSlot Slot
    {
        get => field;
        set
        {
            if (value > EquipSlot.Feet)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            field = value;
        }
    }
}