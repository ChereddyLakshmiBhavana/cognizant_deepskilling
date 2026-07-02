namespace MagicFilesLib;

public class DirectoryExplorer : IDirectoryExplorer
{
    public List<string> GetFiles(string path)
    {
        return Directory.GetFiles(path)
            .Select(Path.GetFileName)
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .Select(name => name!)
            .ToList();
    }
}