using System.Diagnostics;
using GlobalToggleModGenerator.Model.Penumbra;

namespace GlobalToggleModGenerator;

public class PenumbraGroupBuilder
{
    public string Name { get; set; } = "Toggles";
    public string Description { get; set; } = "";
    
    // TODO: come up with a better property name.  It's actually race/gender combinations
    public ISet<(Race,Gender)> TargetRaces { get; } = new HashSet<(Race, Gender)>();
    public ISet<int> TargetSetIds { get; } = new SortedSet<int>([..Enumerable.Range(1, 9999)]);

    // Models is initialized with an empty dictionary for each valid equipment slot
    public Dictionary<EquipSlot, Dictionary<(Race Race, Gender Gender), string>> Models { get; }
        = Enum.GetValues<EquipSlot>()
            .ToDictionary(
                s => s,
                _ => new Dictionary<(Race, Gender), string>());

    public Dictionary<EquipSlot, EquipFlags> EquipmentFlags { get; } = new()
    {
        { EquipSlot.Head, EquipFlags.Head_Default },
        { EquipSlot.Body, EquipFlags.Body_Default },
        { EquipSlot.Hands, EquipFlags.Hands_Default },
        { EquipSlot.Legs, EquipFlags.Legs_Default },
        { EquipSlot.Feet, EquipFlags.Feet_Default }
    };

    private string makeGameModelPath(Race race, Gender gender, int setId, EquipSlot slot)
    {
        int rgid = Utils.GetRaceGenderIdentifier(race, gender);
        string suffix = Utils.GetSlotSuffix(slot);

        if (slot <= EquipSlot.Feet)
        {
            return $"chara/equipment/e{setId:D4}/model/c{rgid:D2}01e{setId:D4}_{suffix}.mdl";
        }
        else
        {
            return $"chara/accessory/a{setId:D4}/model/c{rgid:D2}01a{setId:D4}_{suffix}.mdl";
        }
    }
    
    private GroupOption buildOption(EquipSlot slot)
    {
        string optionName = Enum.GetName(slot) ?? throw new ArgumentOutOfRangeException(nameof(slot));
        GroupOption opt = new GroupOption(optionName, "", 0);

        foreach (int setId in TargetSetIds)
        {
            foreach ((Race race, Gender gender) in TargetRaces)
            {
                if (Models[slot].ContainsKey((race, gender)))
                {
                    var moddedPath = Models[slot][(race, gender)];
                    
                    opt.AddFileRedirect(makeGameModelPath(race, gender, setId, slot), moddedPath);
                    
                    // TODO: add separate handling for unique materials
                    opt.AddManipulation(new EqdpManipulationImpl()
                    {
                        Entry = Utils.GetRacialModelFlagBase(slot) * 3, // *3 ==> Set both material and model flags
                        Slot = slot,
                        Gender = gender,
                        Race = race,
                        SetId = setId
                    });
                }
                else
                {
                    opt.AddManipulation(new EqdpManipulationImpl()
                    {
                        Entry = 0,
                        Slot = slot,
                        Gender = gender,
                        Race = race,
                        SetId = setId
                    });
                }
            }
            
            opt.AddManipulation(new EqpManipulationImpl()
            {
                Entry = (ulong)EquipmentFlags[slot],
                SetId = setId,
                Slot = slot
            });
        }

        return opt;
    }
    
    public Group Build()
    {
        Group g = new Group()
        {
            Version = 0,
            Name = this.Name,
            Description = this.Description,
            Type = GroupType.Multi
        };

        foreach (EquipSlot slot in Enum.GetValues(typeof(EquipSlot)))
        {
            if (Models[slot].Count > 0)
            {
                GroupOption opt = buildOption(slot);
                g.Options.Add(opt);
            }
        }

        return g;
    }
}
