

using System.IO;
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
        result.Should().StartWith("test");
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


    //Need WriteAllLines
    //Need DeleteFile

    [Fact]
    public void WriteAllLines_withDeleteFile()
    {
        // string settingsPath = Path.Combine(_hostingEnvironment.ContentRootPath, "AppData");
        var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
        folderPath.Length.Should().BeGreaterThan(1);

        // Source File
        var confirmSource = _files.FileExists("./resources/example.txt");
        confirmSource.Should().BeTrue();

        var source = _files.ReadAllText("./resources/example.txt");
        var sourceList = new List<string>() { source };

        // Target File - Confirm not already there
        var target = Path.Combine(folderPath, "example.txt");
        var targetExist = _files.FileExists(target);

        if (targetExist)
        {
            _files.DeleteFile(target);
            targetExist = _files.FileExists(target);
        }

        targetExist.Should().BeFalse();

        // Do the thing - Write File
        _files.WriteAllLines(target, sourceList);

        // Confirm created and content matches
        var resultFile = _files.FileExists(target);
        resultFile.Should().BeTrue();

        var result = _files.ReadAllText(target).Trim();
        
        result.Should().Be(source);

        // Clean Up
        _files.DeleteFile(target);
        var confirmDelete = _files.FileExists(target);
        confirmDelete.Should().BeFalse();
    }
}
