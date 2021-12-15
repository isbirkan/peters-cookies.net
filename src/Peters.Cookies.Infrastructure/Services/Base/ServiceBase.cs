using Newtonsoft.Json;
using Peters.Cookies.Infrastructure.Interfaces;

namespace Peters.Cookies.Infrastructure.Services;

public class ServiceBase : IService
{
    private readonly HttpClient _httpClient;

    public ServiceBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> GetAsync<T>(string url)
    {
        T? result;
        try
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(url);
            using HttpContent content = response.Content;
            string responseContent = await content.ReadAsStringAsync();
            if (responseContent != null)
            {
                result = JsonConvert.DeserializeObject<T>(responseContent);
                return result;
            }
        }
        catch (Exception ex)
        {
            throw new HttpRequestException(ex.Message);
        }

        object o = new();
        return (T)o;
    }

    public async Task<T?> PostAsync<T>(string url, HttpContent requestContent)
    {
        T? result;
        try
        {
            using HttpResponseMessage response = await _httpClient.PostAsync(url, requestContent);
            using HttpContent content = response.Content;
            string responseContent = await content.ReadAsStringAsync();
            if (responseContent != null)
            {
                result = JsonConvert.DeserializeObject<T>(responseContent);
                return result;
            }
        }
        catch (Exception ex)
        {
            throw new HttpRequestException(ex.Message);
        }

        object o = new();
        return (T)o;
    }
}
