using GlobalToggleModGenerator.Model.Penumbra;

namespace GlobalToggleModGenerator;

public class Utils
{
    // Gets the numeric identifier for a race-gender pair for a game file.  E.g. Midlander Female would be 02,
    // and Viera Male would be 17.
    public static int GetRaceGenderIdentifier(Race race, Gender gender)
    {
        return ((int)race * 2) + (gender ==  Gender.Male ? 1 : 2);
    }

    public static string GetSlotSuffix(EquipSlot slot)
    {
        switch (slot)
        {
            case  EquipSlot.Head:
                return "met";
            case   EquipSlot.Body:
                return "top";
            case EquipSlot.Hands:
                return "glv";
            case EquipSlot.Legs:
                return "dwn";
            case EquipSlot.Feet:
                return "sho";
            case EquipSlot.Ears:
                return "ear";
            case EquipSlot.Neck:
                return "nek";
            case EquipSlot.Wrists:
                return "wrs";
            case EquipSlot.RFinger:
                return "rir";
            case EquipSlot.LFinger:
                return "ril";
        }
        
        throw new ArgumentOutOfRangeException(nameof(slot));
    }

    // Returns the value of the material EQDP flag for the given slot.
    // To get the model EQDP flag, multiply the result by 2.
    public static ulong GetRacialModelFlagBase(EquipSlot slot)
    {
        if (slot <= EquipSlot.Feet)
        {
            return 2 * (ulong)slot + 1;
        }
        if (slot <= EquipSlot.LFinger)
        {
            return 2 * (ulong)(slot - EquipSlot.Ears) + 1;
        }
        
        throw new ArgumentOutOfRangeException(nameof(slot));
    }
}