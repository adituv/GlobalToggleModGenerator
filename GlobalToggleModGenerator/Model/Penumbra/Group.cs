namespace GlobalToggleModGenerator.Model.Penumbra;

public class Group
{
    public int Version { get; set; } = 0;
    public string Name { get; set; } = "Toggles";
    public string Description { get; set; } = "";
    public string Image { get; set; } = "";
    public int Page { get; set; } = 0;
    public int Priority { get; set; } = 0;
    public GroupType Type { get; set; } = GroupType.Multi;
    public int DefaultSettings { get; set; } = 0;
    public List<GroupOption> Options { get; } = [];
}
