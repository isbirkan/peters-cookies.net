namespace Peters.Cookies.Infrastructure.Interfaces;

public interface IService
{
    Task<T?> GetAsync<T>(string url);

    Task<T?> PostAsync<T>(string url, HttpContent requestContent);
}
