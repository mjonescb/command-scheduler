namespace Api
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public class JobHandler
    {
        public async Task Go(string url, string method, string state)
        {
            using(HttpClient client = new HttpClient())
            {
                HttpMethod httpMethod = new HttpMethod(method);

                HttpRequestMessage request = new HttpRequestMessage(
                    httpMethod,
                    url);

                await client.SendAsync(request);
            }
        }
    }
}