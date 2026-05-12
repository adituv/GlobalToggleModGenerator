namespace GlobalToggleModGenerator.Model.Penumbra;

// EQP group bitfield values
// private const ulong HEAD_EQP_BITS = 0xB7F_E100_0000_0000UL;

// Flags for EQP modifications
[Flags]
public enum EquipFlags : ulong
{
    Body_Enabled = 0x0001,
    Body_HideWaist = 0x0002,
    Body_HideThighPads = 0x0004,
    Body_HideSmalLGloves = 0x0008,
    Body_HideGloveCuffs = 0x0010,
    Body_HideMediumGloves = 0x0020,
    Body_HideLargeGloves = 0x0040,
    Body_HideGorget = 0x0080,
    Body_ShowLegs = 0x0100,
    Body_ShowHands = 0x0200,
    Body_ShowHead = 0x0400,
    Body_ShowNecklace = 0x0800,
    Body_ShowBracelet = 0x1000,
    Body_ShowTail = 0x2000,
    Body_DisableBreastPhysics = 0x4000,
    Body_UsesEvpTable = 0x8000,

    Body_Mask = 0xFFFF,
    Body_Default = 0x3F01,

    Legs_Enabled = 0x01_0000,
    Legs_HideKneePads = 0x02_0000,
    Legs_HideSmallBoots = 0x04_0000,
    Legs_HideMediumBoots = 0x08_0000,
    Legs_Unknown20 = 0x10_0000,
    Legs_ShowFoot = 0x20_0000,
    Legs_ShowTail = 0x40_0000,
    Legs_Unknown23 = 0x80_0000,

    Legs_Mask = 0xFF_0000,
    Legs_Default = 0x61_0000,

    Hands_Enabled = 0x0100_0000,
    Hands_HideElbow = 0x0200_0000,
    Hands_HideForearm = 0x0400_0000,
    Hands_Unknown27 = 0x0800_0000,
    Hands_ShowBracelet = 0x1000_0000,
    Hands_ShowLeftRing = 0x2000_0000,
    Hands_ShowRightRing = 0x4000_0000,
    Hands_Unknown31 = 0x8000_0000,

    Hands_Mask = 0xFF00_0000,
    Hands_Default = 0x7100_0000,

    Feet_Enabled = 0x01_0000_0000UL,
    Feet_HideKnees = 0x02_0000_0000UL,
    Feet_HideCalves = 0x04_0000_0000UL,
    Feet_HideAnkles = 0x08_0000_0000UL,
    Feet_Unknown36 = 0x10_0000_0000UL,
    Feet_Unknown37 = 0x20_0000_0000UL,
    Feet_Unknown38 = 0x40_0000_0000UL,
    Feet_Unknown39 = 0x80_0000_0000UL,

    Feet_Mask = 0xFF_0000_0000UL,
    Feet_Default = 0x01_0000_0000UL,

    Head_Enabled = 0x000_0100_0000_0000UL,
    Head_HideScalp = 0x000_0200_0000_0000UL,
    Head_HideHair = 0x000_0400_0000_0000UL,
    Head_ShowHairOverride = 0x000_0800_0000_0000UL,
    Head_HideNeck = 0x000_1000_0000_0000UL,
    Head_ShowNecklace = 0x000_2000_0000_0000UL,
    Head_ShowEarrings_HyurRoe = 0x000_4000_0000_0000UL,
    Head_ShowEarrings_ElezenLala = 0x000_8000_0000_0000UL,
    Head_ShowEarrings_MiqoHrothViera = 0x001_0000_0000_0000UL,
    Head_ShowEarrings_AuRa = 0x002_0000_0000_0000UL,
    Head_ShowEars_Human = 0x004_0000_0000_0000UL,
    Head_ShowEars_Miqote = 0x008_0000_0000_0000UL,
    Head_ShowEars_AuRa = 0x010_0000_0000_0000UL,
    Head_ShowEars_Viera = 0x020_0000_0000_0000UL,
    Head_DisableHairPhysics_Bangs = 0x040_0000_0000_0000UL,
    Head_DisableHairPhysics_SidesBack = 0x080_0000_0000_0000UL,
    Head_ShowOnHrothgar = 0x100_0000_0000_0000UL,
    Head_ShowOnViera = 0x200_0000_0000_0000UL,
    Head_UsesEvpTable = 0x400_0000_0000_0000UL,

    Head_Mask = 0x7FF_FF00_0000_0000UL,
    Head_Default = 0x33F_E100_0000_0000UL
}
