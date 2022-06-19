using System.Text;

namespace SimpleFeatures
{
    public static class HelperExtention
    {
        public static async Task<string> ReadWebPage(Uri uri)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage result = await httpClient.GetAsync(uri);

            Stream stream = await result.Content.ReadAsStreamAsync();

            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.Default))
            {
                return reader.ReadToEnd();
            }
        }
    }
}