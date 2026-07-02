using MagicFilesLib;
using Moq;

namespace DirectoryExplorer.Tests;

[TestFixture]
public class DirectoryExplorerTests
{
    private Mock<IDirectoryExplorer> _directoryExplorerMock = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _directoryExplorerMock = new Mock<IDirectoryExplorer>();

        _directoryExplorerMock
            .Setup(explorer => explorer.GetFiles(It.IsAny<string>()))
            .Returns(new List<string>
            {
                "file.txt",
                "file2.txt"
            });
    }

    [Test]
    public void GetFiles_ReturnsExpectedHardcodedFiles()
    {
        List<string> files = _directoryExplorerMock.Object.GetFiles("C:/any/path");

        Assert.That(files, Is.Not.Null);
        Assert.That(files.Count, Is.EqualTo(2));
        Assert.That(files, Does.Contain("file.txt"));
    }
}