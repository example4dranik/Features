using System.Diagnostics;

namespace SimpleFeatures.ProcessStart
{
    public class ProcessStart : ISolution
    {
        public void Execute()
        {
            List<string> listSoft = new List<string>();
            listSoft.Add("c:" + Path.DirectorySeparatorChar);
            listSoft.Add("Program Files");
            listSoft.Add("Notepad++");
            listSoft.Add("notepad++.exe");

            List<string> listFile = new List<string>();
            listFile.Add("c:" + Path.DirectorySeparatorChar);
            listFile.Add("1.txt");

            using (Process myProcess = new Process())
            {
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(Path.Combine(listSoft.ToArray()));

                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcessStartInfo.RedirectStandardError = true;
                myProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcessStartInfo.Arguments = Path.Combine(listFile.ToArray());
                myProcess.StartInfo = myProcessStartInfo;
                myProcess.Start();

                StreamReader myStreamReader = myProcess.StandardError;
                Console.WriteLine(myStreamReader.ReadLine());
                myStreamReader = myProcess.StandardOutput;
                Console.WriteLine(myStreamReader.ReadLine());
            }
        }
    }
}