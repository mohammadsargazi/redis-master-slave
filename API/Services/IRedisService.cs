namespace API.Services;

public interface IRedisService
{
    Task SetAsync(string key, string value);
    Task<string?> GetFromMasterAsync(string key);
    Task<string?> GetFromSlaveAsync(string key);
}