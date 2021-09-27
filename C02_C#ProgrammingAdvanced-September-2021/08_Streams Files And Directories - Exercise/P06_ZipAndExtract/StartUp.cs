namespace _06_ZipAndExtract
{
    using System;
    using System.IO.Compression;

    public class StartUp
    {
        const string PATH = @"D:\SoftUni - Материали\C#\P02_Advanced\P04 Streams, Files and Directories\ZipFileDemo";
        const string CREATE_PATH = @"D:\SoftUni - Материали\C#\P02_Advanced\P04 Streams, Files and Directories\ZipFileDemoCreation\myZipFile.zip";
        const string EXTRACT_PATH = @"D:\SoftUni - Материали\C#\P02_Advanced\P04 Streams, Files and Directories\ZipFileDemoExtract";

        public static void Main()
        {
            ZipFile.CreateFromDirectory(PATH, CREATE_PATH);
            ZipFile.ExtractToDirectory(CREATE_PATH, EXTRACT_PATH);
        }
    }
}
