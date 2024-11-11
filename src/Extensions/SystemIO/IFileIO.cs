using System;
using System.Collections.Generic;
using io = System.IO;


namespace Calebs.Extensions.SystemIO;

/// <summary>
/// A File IO interface and implementation of common IO uses - designed for edge testability
/// </summary>
public interface IFileIO
{
    bool FileExists(string path) => io.File.Exists(path);
    void DeleteFile(string path) => io.File.Delete(path);
    string ReadAllText (string path) => io.File.ReadAllText(path);
    void WriteAllLines(string path, IEnumerable<string> lines) => io.File.WriteAllLines(path, lines);
    string[] GetFiles(string path, string filter = "") => io.Directory.GetFiles(path, filter);
    io.FileAttributes GetFileAttributes(string path) => io.File.GetAttributes(path);
    io.FileInfo GetFileInfo (string path) => new io.FileInfo(path);
    bool DirectoryExists(string path) => io.Directory.Exists(path);
    string GetDirectoryName(string path) => io.Path.GetDirectoryName(path);
    void CreateDirectory(string path) => io.Directory.CreateDirectory(path);
    void DeleteDirectory (string path) => io.Directory.Delete(path);
}
