using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Lektion16
{
    internal class Program

    {
       
        static void Main(string[] args)
        {
            string pathNames = @"C:\Repos\ovningarolaxor\Lektion16\namn.txt";
            if (File.Exists(pathNames))
            { string[] namn = File.ReadAllLines(pathNames);

            }
           
            
        #region Övning 3
        string pathFood = @"C:\Repos\ovningarolaxor\Lektion16\favoritmat.txt";
        if(File.Exists(pathFood))
        {
            string[] maträtter = File.ReadAllLines(pathFood);
            foreach(string rätt in maträtter)
            {
                Console.WriteLine(rätt);
            }
        }
        #endregion*/
            /*string path = @"C:\Repos\ovningarolaxor\Lektion16\shits.txt";
            FileInfo fileInfo = new FileInfo(path);
            if(File.Exists(path))
            {
                Console.WriteLine($"Filnamn: {fileInfo.Name}");
                Console.WriteLine($"Skapad: {fileInfo.CreationTime}");
                Console.WriteLine($"Senast ändrad: {fileInfo.LastWriteTime}");
                Console.WriteLine($"Filtyp: {fileInfo.Extension}");
            }*/
            /* var userPath = AppPaths.UserProfile;
             string directory = "MinApp";
             string fileName = "config.txt";
             string fullpath = Path.Combine(userPath, directory, fileName);
             Console.WriteLine(fullpath);
             var userFilePath = @"C:\Project\WebApp\wwwroot\images\logo.png";
             string uFPdirectory = Path.GetDirectoryName(userFilePath);
             string uFPfileName = Path.GetFileNameWithoutExtension(userFilePath);
             string uFPfilenameExt = Path.GetFileName(userFilePath);
             string uFPfileExtension = Path.GetExtension(userFilePath);
             Console.WriteLine(uFPdirectory);
             Console.WriteLine(uFPfileName);
             Console.WriteLine(uFPfilenameExt);
             Console.WriteLine(uFPfileExtension);

             #region Övning 1
             Func<int, int> doubleValue = x => x * 2;
             Func<int, int, int> largestValue = (z, y) => Math.Max(z, y);
             Func<string, bool> capitolLetter = s => char.IsUpper(s[0]);
             #endregion
             #region Övning 2
             int[] arrayMedInts = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
             Func<int, bool> evenNumbers = h => h % 2 == 0;
             Func<int, int> threeTimes = c => c * 3;
             Func<int, bool> biggerThanSeven = d => d > 7;
             var isEven = arrayMedInts.Where(evenNumbers);
             var firstbiggerThanSeven = arrayMedInts.First(biggerThanSeven);
             var timesThree = arrayMedInts.Select(threeTimes);
             #endregion*/
        }
        public static class AppPaths
        {
            public static string UserDocuments =>
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            public static string AppData =>
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            public static string LocalAppData =>
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            public static string UserProfile =>
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            public static string Desktop =>
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Skapa applikationsspecifik mapp
            public static string GetAppDataPath(string appName)
            {
                return Path.Combine(AppData, appName);
            }
        }
    }
}
