using System;
using System.Collections.Generic;
using System.IO;


namespace Calebs.Extensions.SystemIO;

/// <summary>
/// A File IO interface and implementation of common IO uses - designed for edge testability
/// </summary>
public interface IFileIO
{
    string[] GetFiles(string path, string filter = "") => Directory.GetFiles(path, filter);
    bool DirectoryExists(string path) => Directory.Exists(path);
    string GetDirectoryName(string path) => Path.GetDirectoryName(path);
    string ReadAllText (string path) => File.ReadAllText(path);
    bool FileExists(string path) => File.Exists(path);
    void WriteAllLines(string path, IEnumerable<string> lines) => File.WriteAllLines(path, lines);
    string PathCombine(string path1, string path2) => Path.Combine(path1, path2);
    void DeleteFile(string path) => File.Delete(path);
}
