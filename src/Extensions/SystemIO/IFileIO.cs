using System;
using System.Collections.Generic;
using System.IO;


namespace Calebs.Extensions.SystemIO;

/// <summary>
/// A File IO interface and implementation of common IO uses - designed for edge testability
/// </summary>
public interface IFileIO
{
    bool FileExists(string path) => File.Exists(path);
    void DeleteFile(string path) => File.Delete(path);
    string ReadAllText (string path) => File.ReadAllText(path);
    void WriteAllLines(string path, IEnumerable<string> lines) => File.WriteAllLines(path, lines);
    string[] GetFiles(string path, string filter = "") => Directory.GetFiles(path, filter);
    bool DirectoryExists(string path) => Directory.Exists(path);
    string GetDirectoryName(string path) => Path.GetDirectoryName(path);
    void CreateDirectory(string path) => Directory.CreateDirectory(path);
    void DeleteDirectory (string path) => Directory.Delete(path);
}
