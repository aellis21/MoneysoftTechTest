using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoneysoftTechTest
{
    public class QuestionFour
    {
        public async Task<long> GetContentLength()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://moneysoft.com.au");

            HttpClient httpClient = new HttpClient();

            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = await request.GetResponseAsync();
            return response.ContentLength;
        }

    }
}
