using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using NetWork;
using Newtonsoft.Json;
namespace network;

class Program
{
    // class Meta
    // {
    //     public string code { set; get; }
    //     public IList<Data> meta { get; set; }
    // }
    // public class Data
    // {
    //     public string company { set; get; }
    //     public IList<Data> data { get; set; }
    // }
    public static async Task Main(string[] args)
    {
        string url = "https://ms.vietnamworks.com/job-search/v1.0/search";
        var httpClient = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
        // httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        // string text = await response.Content.ReadAsStringAsync();
        // Console.WriteLine($"Nhận được {text.Length} ký tự");
        request.Content = new StringContent("{\"query\":\"IT\",\"filter\":[{\"field\":\"workingLocations.cityId\",\"value\":\"7\"}],\"ranges\":[],\"order\":[],\"hitsPerPage\":50,\"page\":0,\"retrieveFields\":[\"benefits\",\"jobTitle\",\"salaryMax\",\"isSalaryVisible\",\"jobLevelVI\",\"isShowLogo\",\"salaryMin\",\"companyLogo\",\"userId\",\"jobLevel\",\"jobId\",\"companyId\",\"approvedOn\",\"isAnonymous\",\"alias\",\"expiredOn\",\"industries\",\"workingLocations\",\"services\",\"companyName\",\"salary\",\"onlineOn\",\"simpleServices\",\"visibilityDisplay\",\"isShowLogoInSearch\",\"priorityOrder\",\"skills\"]}");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        // đọc content web trả về
        string responseBody = await response.Content.ReadAsStringAsync();

        // Meta bsObj = JsonConvert.DeserializeObject<Meta>(responseBody.ToString());

        var arr = @"{meta:{
            ""code"": ""203"",
             ""data"": [
                { ""company"": ""hoang dz A""},
                 {""company"": ""hoang dz B""}
             ]
         }
         }";
        var json = @$"{responseBody.ToString()}";
        var dynamicObject = JsonConvert.DeserializeObject<dynamic>(json)!;
        // Console.WriteLine(dynamicObject.meta.data[0].company);

        // Console.WriteLine(dynamicObject.data[0].companyName);
        var company = dynamicObject.data;

        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine(company[i].companyName);
        }

        // đọc byte dowload file c1 

        // string url = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
        // var httpClient = new HttpClient();
        // HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        // HttpResponseMessage response = await httpClient.SendAsync(request);
        // byte[] responded = response.Content.ReadAsByteArrayAsync().Result;

        // string filepath = "anh1.png";


        // using (var stream = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None))
        // {
        //     stream.Write(responded, 0, responded.Length);
        //     Console.WriteLine("save " + filepath);
        // }


        // // đọc byte dowload file c2

        // await DownloadDataStream(url, "anh2.png");


        // sendData();










    }

    public static async Task DownloadDataStream(string url, string filename)
    {
        var httpClient = new HttpClient();
        Console.WriteLine($"Starting connect {url}");
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // Lấy Stream để đọc content
            using var stream = await response.Content.ReadAsStreamAsync();

            // THỰC HIỆN ĐỌC Content
            int SIZEBUFFER = 500;
            using var streamwrite = File.OpenWrite(filename);  // Mở stream để lưu file
            byte[] buffer = new byte[SIZEBUFFER];               // tạo bộ nhớ đệm lưu dữ liệu khi đọc stream

            bool endread = false;
            do                                                  // thực hiện đọc các byte từ stream và lưu ra streamwrite
            {
                int numberRead = await stream.ReadAsync(buffer, 0, SIZEBUFFER);
                Console.WriteLine(numberRead);
                if (numberRead == 0)
                {
                    endread = true;
                }
                else
                {
                    await streamwrite.WriteAsync(buffer, 0, numberRead);
                }

            } while (!endread);
            Console.WriteLine("Download success");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw e;
        }
    }
    // send data server Sử dụng FormUrlEncodedContent
    public static async Task sendData()
    {
        var httpClient = new HttpClient();

        var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Method = HttpMethod.Post;
        httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");

        var parameters = new List<KeyValuePair<string, string>>();
        parameters.Add(new KeyValuePair<string, string>("key1", "value1"));

        parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
        parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));

        // Thiết lập Content
        var content = new FormUrlEncodedContent(parameters);
        httpRequestMessage.Content = content;

        // Thực hiện Post
        var response = await httpClient.SendAsync(httpRequestMessage);
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
    }

    // send data server 
    public static async Task sendDatabyStringContent()
    {
        var httpClient = new HttpClient();

        var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Method = HttpMethod.Post;
        httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");

        // Tạo StringContent
        string jsoncontent = "{\"value1\": \"giatri1\", \"value2\": \"giatri2\"}";
        var httpContent = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
        httpRequestMessage.Content = httpContent;

        var response = await httpClient.SendAsync(httpRequestMessage);
        var responseContent = await response.Content.ReadAsStringAsync();

        Console.WriteLine(responseContent);
    }
    public static async Task sendDatabyFile()
    {
        var httpClient = new HttpClient();

        var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Method = HttpMethod.Post;
        httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");


        // Tạo đối tượng MultipartFormDataContent
        var content = new MultipartFormDataContent();

        // Tạo StreamContent chứa nội dung file upload, sau đó đưa vào content
        Stream fileStream = System.IO.File.OpenRead("Program.cs");
        content.Add(new StreamContent(fileStream), "fileupload", "abc.xyz");

        // Thêm vào MultipartFormDataContent một StringContent
        content.Add(new StringContent("value1"), "key1");
        // Thêm phần tử chứa mạng giá trị (HTML Multi Select)
        content.Add(new StringContent("value2-1"), "key2[]");
        content.Add(new StringContent("value2-2"), "key2[]");


        httpRequestMessage.Content = content;
        var response = await httpClient.SendAsync(httpRequestMessage);
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
    }
}

