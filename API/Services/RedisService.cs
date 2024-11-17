using StackExchange.Redis;

namespace API.Services;

public class RedisService(IConnectionMultiplexer redis) : IRedisService
{
    public async Task SetAsync(string key, string value)
    {
        var db = redis.GetDatabase();
        await db.StringSetAsync(key, value, flags: CommandFlags.DemandMaster);
    }
    public async Task<string?> GetFromMasterAsync(string key)
    {
        return await GetAsync(key);
    }
    public async Task<string?> GetFromSlaveAsync(string key)
    {
        return await GetAsync(key, CommandFlags.PreferReplica);
    }
    private async Task<string?> GetAsync(string key, CommandFlags flags = CommandFlags.None)
    {
        var db = redis.GetDatabase();
        var value = await db.StringGetAsync(key, flags);
        return value.HasValue ? value.ToString() : null;
    }
}