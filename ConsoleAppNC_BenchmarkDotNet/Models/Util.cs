using System.IO;

namespace ConsoleAppNC_BenchmarkDotNet.Models
{
    public class Util
    {
        public static string ReadSerializedDataByFileName(string fileName)
        {
            return File.ReadAllText("./Data/" + fileName);
        }
    }
}
