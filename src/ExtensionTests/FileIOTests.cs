

using System.Linq;

namespace ExtensionTests;

public class FileIOTests
{
    IFileIO _files = new FileIO();

    [Fact]
    public void DirectoryExists_ShouldBeTrue()
    {
        var exists = _files.DirectoryExists("./");
        exists.Should().BeTrue();
    }

    [Fact]
    public void DirectoryDoesNotExists_ShouldBeFalse()
    {
        var exists = _files.DirectoryExists("./blah/");
        exists.Should().BeFalse();
    }

    [Fact]
    public void GetFilesCount_NoFilter()
    {
        var results = _files.GetFiles("./", "");
        results.Count().Should().BeGreaterThan(10);
    }

    [Fact]
    public void GetFilesCount_FilterToOneFile()
    {
        var results = _files.GetFiles("./", "Calebs.Extensions.dll");
        results.Count().Should().Be(1);
    }

    [Fact]
    public void GetDirectoryName()
    {
        var results = _files.GetDirectoryName("./Calebs.Extensions.dll");
        results.Should().Be(".");
    }

    [Fact]
    public void ReadAllText_Reads()
    {
        var exists = _files.FileExists("./resources/example.txt");
        exists.Should().BeTrue();

        var result = _files.ReadAllText("./resources/example.txt");
        result.Should().Be("test");
    }

    [Fact]
    public void FilesExists_DoesExist()
    {
        var result = _files.FileExists("./Calebs.Extensions.dll");
        result.Should().BeTrue();
    }

    [Fact]
    public void FilesExists_DoesNotExist()
    {
        var result = _files.FileExists("./blah");
        result.Should().BeFalse();
    }

    [Fact]
    public void PathCombine_MadeUpFolders()
    {
        var result = _files.PathCombine("A:\\test", "picture");
        result.Should().Be("A:\\test\\picture");
    }

    [Fact]
    public void PathCombine_MadeUpLongerFolders()
    {
        var result = _files.PathCombine("A:\\test\\two\\three", "picture\\four");
        result.Should().Be("A:\\test\\two\\three\\picture\\four");
    }

    [Fact]
    public void PathCombine_MadeUpMoreFolders()
    {
        var result = System.IO.Path.Combine("test", "picture", "help");
        result.Should().Be("test\\picture\\help");
    }

    //Need WriteAllLines
    //Need DeleteFile
}
