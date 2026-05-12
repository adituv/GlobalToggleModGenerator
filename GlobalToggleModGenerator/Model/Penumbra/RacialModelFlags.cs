namespace GlobalToggleModGenerator.Model.Penumbra;

// Flags for EQDP modifications
[Flags]
public enum RacialModelFlags
{
    Head_Material = 0x001,
    Head_Model = 0x002,
    Body_Material = 0x004,
    Body_Model = 0x008,
    Hands_Material = 0x010,
    Hands_Model = 0x020,
    Legs_Material = 0x040,
    Legs_Model = 0x080,
    Feet_Material = 0x100,
    Feet_Model = 0x200,
    
}
