using System.Diagnostics;

namespace SimpleFeatures.ProcessStart
{
    public class ProcessStart : ISolution
    {
        public void Execute()
        {
            var listSoft = new List<string>
            {
                "c:" + Path.DirectorySeparatorChar,
                "Program Files",
                "Notepad++",
                "notepad++.exe"
            };

            var listFile = new List<string>
            {
                "c:" + Path.DirectorySeparatorChar,
                "1.txt"
            };

            using var myProcess = new Process();
            var myProcessStartInfo = new ProcessStartInfo(Path.Combine(listSoft.ToArray()))
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = Path.Combine(listFile.ToArray())
            };
            myProcess.StartInfo = myProcessStartInfo;
            myProcess.Start();

            StreamReader myStreamReader = myProcess.StandardError;
            Console.WriteLine(myStreamReader.ReadLine());
            myStreamReader = myProcess.StandardOutput;
            Console.WriteLine(myStreamReader.ReadLine());
        }
    }
}