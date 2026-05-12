using System.Text.Json;
using GlobalToggleModGenerator.Model.Penumbra;

namespace GlobalToggleModGenerator;

public static class Program
{
    // Game file path patterns
    private const string HEAD_PATTERN = "chara/equipment/e{0:D4}/model/c0201e{0:D4}_met.mdl";
    private const string BODY_PATTERN = "chara/equipment/e{0:D4}/model/c0201e{0:D4}_top.mdl";
    private const string HAND_PATTERN = "chara/equipment/e{0:D4}/model/c0201e{0:D4}_glv.mdl";
    private const string LEGS_PATTERN = "chara/equipment/e{0:D4}/model/c0201e{0:D4}_dwn.mdl";
    private const string FEET_PATTERN = "chara/equipment/e{0:D4}/model/c0201e{0:D4}_sho.mdl";
    
    // TODO: Allow customizing the destination paths and the bitfield values
    
    // Redirected file paths
    private const string HEAD_PATH = "common\\1\\c0101e0279_met.mdl";
    private const string BODY_PATH = "common\\2\\c0201e0001_top.mdl";
    private const string HAND_PATH = "common\\3\\c0201e0001_glv.mdl";
    private const string LEGS_PATH = "common\\4\\c0201e0001_dwn.mdl";
    private const string FEET_PATH = "common\\5\\c0201e0001_sho.mdl";
    
    // EQP group bitfield values
    private const ulong HEAD_EQP_BITS = 0xB7F_E100_0000_0000UL;
    private const ulong BODY_EQP_BITS = 0x000_0000_0000_3F01UL;
    private const ulong HAND_EQP_BITS = 0x000_0000_7100_0000UL;
    private const ulong LEGS_EQP_BITS = 0x000_0000_0610_000UL;
    private const ulong FEET_EQP_BITS = 0x000_0001_0000_0000UL;
    
    // EQDP group bitfield values
    private const ulong HEAD_EQDP_BITS = 0x0003;
    private const ulong BODY_EQDP_BITS = 0x000C;
    private const ulong HAND_EQDP_BITS = 0x0030;
    private const ulong LEGS_EQDP_BITS = 0x00C0;
    private const ulong FEET_EQDP_BITS = 0x0300;

    private static void AddSetToOption(ref GroupOption option, int setId, EquipSlot slot, string sourcePattern,
        string targetPath, ulong eqpBits, ulong eqdpBits)
    {
        option.AddFileRedirect(string.Format(sourcePattern, setId), targetPath);

        // Set body part visibility flags
        // NB. only the five main slots support EQP manipulations
        if (slot <= EquipSlot.Feet)
        {
            option.AddManipulation(new EqpManipulationImpl()
            {
                Entry = eqpBits,
                SetId = setId,
                Slot = slot
            });
        }
        
        // Set racial/gender variant flags:
        // * Midlander F has unique model and material
        // * Lalafell F is skipped (use game default)
        // * All other races use Midlander F model and material
        option.AddManipulation(new EqdpManipulationImpl()
        {
            Slot = slot,
            Entry = eqdpBits,
            Gender = Gender.Female,
            Race = Race.Midlander,
            SetId = setId
        });
        
        foreach (var race in Enum.GetValues(typeof(Race)).Cast<Race>().ToList())
        {
            // Midlander already set; do not set Lalafell
            if (race == Race.Lalafell || race == Race.Midlander) continue;
            
            option.AddManipulation(new EqdpManipulationImpl()
            {
                Slot = slot,
                Entry = 0,
                Gender = Gender.Female,
                Race = race,
                SetId = setId
            });
        }
    }
    
    static void Main(string[] args)
    {
        Group group = new Group();
        
        GroupOption headGroup = new GroupOption("Head", "", 0);
        GroupOption bodyGroup = new GroupOption("Body", "", 0);
        GroupOption handGroup = new GroupOption("Hands", "", 0);
        GroupOption legsGroup = new GroupOption("Legs", "", 0);
        GroupOption feetGroup = new GroupOption("Feet", "", 0);

        for (int i = 1; i <= 9999; i++)
        {
            AddSetToOption(ref headGroup, i, EquipSlot.Head, HEAD_PATTERN, HEAD_PATH, HEAD_EQP_BITS, HEAD_EQDP_BITS);
            AddSetToOption(ref bodyGroup, i, EquipSlot.Body, BODY_PATTERN, BODY_PATH, BODY_EQP_BITS, BODY_EQDP_BITS);
            AddSetToOption(ref handGroup, i, EquipSlot.Hands, HAND_PATTERN, HAND_PATH, HAND_EQP_BITS, HAND_EQDP_BITS);
            AddSetToOption(ref legsGroup, i, EquipSlot.Legs, LEGS_PATTERN, LEGS_PATH, LEGS_EQP_BITS, LEGS_EQDP_BITS);
            AddSetToOption(ref feetGroup, i, EquipSlot.Feet, FEET_PATTERN, FEET_PATH, FEET_EQP_BITS, FEET_EQDP_BITS);
        }
        
        group.Options.Add(headGroup);
        group.Options.Add(bodyGroup);
        group.Options.Add(handGroup);
        group.Options.Add(legsGroup);
        group.Options.Add(feetGroup);

        using (var fs = new FileStream("mod_out.txt", FileMode.Create))
        {
            JsonSerializer.Serialize(fs, group);
        }
    }
}
