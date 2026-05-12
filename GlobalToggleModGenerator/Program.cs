using System.Text.Json;
using GlobalToggleModGenerator.Model.Penumbra;

namespace GlobalToggleModGenerator;

public static class Program
{
    // Redirected file paths
    private const string HEAD_PATH = "common\\1\\c0101e0279_met.mdl";
    private const string BODY_PATH = "common\\2\\c0201e0001_top.mdl";
    private const string HAND_PATH = "common\\3\\c0201e0001_glv.mdl";
    private const string LEGS_PATH = "common\\4\\c0201e0001_dwn.mdl";
    private const string FEET_PATH = "common\\5\\c0201e0001_sho.mdl";
    
    static void Main(string[] args)
    {
        PenumbraGroupBuilder builder = new PenumbraGroupBuilder();
        builder.Name = "Toggles";

        builder.TargetRaces.UnionWith(from Race r in Enum.GetValues<Race>()
            where r != Race.Lalafell
            select (r, Gender.Female)); 
        
        // To reduce the scale of the tests, I'm only generating a few entries
        builder.TargetSetIds.Clear();
        builder.TargetSetIds.UnionWith([1,279,3601]);
        
        builder.Models[EquipSlot.Head][(Race.Midlander, Gender.Female)] = HEAD_PATH;
        builder.Models[EquipSlot.Body][(Race.Midlander, Gender.Female)] = BODY_PATH;
        builder.Models[EquipSlot.Hands][(Race.Midlander, Gender.Female)] = HAND_PATH;
        builder.Models[EquipSlot.Legs][(Race.Midlander, Gender.Female)] = LEGS_PATH;
        builder.Models[EquipSlot.Feet][(Race.Midlander, Gender.Female)] = FEET_PATH;
        
        // You can also set the equipment visibility flags here, e.g.
        // builder.EquipmentFlags[EquipSlot.Hands] |= EquipFlags.Hands_HideElbow;
        // builder.EquipmentFlags[EquipSlot.Hands] &= ~EquipFlags.Hands_ShowLeftRing;
        
        Group group = builder.Build();
        
        using (var fs = new FileStream("mod_out.txt", FileMode.Create))
        {
            JsonSerializer.Serialize(fs, group);
        }
    }
}
