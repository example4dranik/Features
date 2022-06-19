namespace SimpleFeatures.ScanFiles
{
    public class ScanFiles : ISolution
    {
        public void Execute()
        {
            string pathDirectory = "c:\\torrent\\";

            RecursionSearchFiles(pathDirectory)
                .ForEach(f => Console.WriteLine(f));
        }

        private static List<string> RecursionSearchFiles(string dirPath)
        {
            var answer = new List<string>();

            var currentDir = new DirectoryInfo(dirPath);

            var fs = currentDir.GetFiles();
            if (fs != null)
            {
                foreach (var f in fs)
                {
                    answer.Add(f.FullName);
                }
            }

            var ds = currentDir.GetDirectories();
            if (ds != null)
            {
                foreach (var d in ds)
                {
                    answer.AddRange(RecursionSearchFiles(d.FullName));
                }
            }

            return answer;
        }
    }
}