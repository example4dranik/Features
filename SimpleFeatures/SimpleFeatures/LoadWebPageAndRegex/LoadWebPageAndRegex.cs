using System.Text.RegularExpressions;

namespace SimpleFeatures.LoadWebPageAndRegex
{
    public class LoadWebPageAndRegex : ISolution
    {
        private const string PatternSearch = @"<img alt=""([^""]+)"".+>";

        public void Execute()
        {
            var listUrls = new List<string>
            {
                "https://en.wikipedia.org",
                "https://google.com",
                "https://github.com",
                "https://en.wikipedia.org/wiki/C_Sharp_(programming_language)",
                "https://www.reddit.com",
                "https://www.flickr.com",
                "https://www.pexels.com"
            };

            listUrls.ForEach(u => Console.WriteLine($"{u}: {ExtractAltImgFromPage(u)}"));
        }

        private string ExtractAltImgFromPage(string url)
        {
            string answer = string.Empty;

            Task<string> task = HelperExtention.ReadWebPage(new Uri(url));
            string str = task.Result;

            Match m = Regex.Match(str, PatternSearch, RegexOptions.IgnoreCase);
            if (m.Success)
            {
                answer = m.Groups[1].Value;
            }

            return answer;
        }
    }
}