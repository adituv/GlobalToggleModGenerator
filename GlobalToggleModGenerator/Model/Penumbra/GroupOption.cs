namespace GlobalToggleModGenerator.Model.Penumbra;

public record GroupOption(string Name, string Description, int Priority)
{
    private readonly Dictionary<string, string> _files = new();
    private readonly List<Manipulation> _manips = new();
    
    public IReadOnlyDictionary<string, string> Files => _files;
    public IReadOnlyList<Manipulation> Manipulations => _manips;

    public void AddFileRedirect(string gamePath, string replacementPath)
    {
        _files.Add(gamePath, replacementPath);
    }

    public void AddManipulation(EqpManipulationImpl eqpManip)
    {
        Manipulation manip = new Manipulation(eqpManip);
        _manips.Add(manip);
    }

    public void AddManipulation(EqdpManipulationImpl eqdpManip)
    {
        Manipulation manip = new Manipulation(eqdpManip);
        _manips.Add(manip);
    }
}
