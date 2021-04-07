using System;
using System.Linq;

namespace Ista.Repository.FileSystem
{
    internal static class FileHelper
    {
        private static string SBaseDirectory = $@"c:\temp\Ista";

        static string GetPath(string fileName)
        {
            return System.IO.Path.Combine(SBaseDirectory, $"{fileName}.json");
        }

        public static void Create(string fileName, object obj)
        {
            obj = obj ?? throw new ArgumentNullException(nameof(obj));

            string path = GetPath(fileName);

            var strObj = System.Text.Json.JsonSerializer.Serialize(obj);

            System.IO.File.WriteAllText(path, strObj);
        }


        public static T GetData<T>(string fileName, T emptyData)
        {
            string path = GetPath(fileName);

            if (!System.IO.File.Exists(path))
            {
                return emptyData;
            }

            string jsonObj = System.IO.File.ReadAllText(path);
            return System.Text.Json.JsonSerializer.Deserialize<T>(jsonObj);
        }

        public static string[] GetFiles(string pattern)
        {
            return System.IO.Directory.GetFiles(SBaseDirectory, $"{pattern}.json")
                .Select(f => System.IO.Path.GetFileNameWithoutExtension(f))
                .ToArray();
        }
    }
}
