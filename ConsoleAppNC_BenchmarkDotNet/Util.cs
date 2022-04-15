using System.IO;

namespace ConsoleAppNC_BenchmarkDotNet.Models
{
    public class Util
    {
        public static string ReadSerializedDataFromFileName(string fileName)
        {
            return File.ReadAllText("./Data/" + fileName);
        }
    }
}
