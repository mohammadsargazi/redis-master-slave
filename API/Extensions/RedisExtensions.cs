using StackExchange.Redis;

namespace API.Extensions;

public static class RedisExtensions
{
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConfig = configuration.GetSection("Redis");
        var master = redisConfig["Master"] ?? throw new InvalidOperationException("Redis master endpoint not configured.");
        var slaves = redisConfig.GetSection("Slaves").Get<string[]>() ?? [];

        services.AddSingleton<IConnectionMultiplexer>(_ =>
        {
            var configOptions = new ConfigurationOptions
            {
                AbortOnConnectFail = false
            };

            configOptions.EndPoints.Add(master);
            foreach (var slave in slaves)
            {
                configOptions.EndPoints.Add(slave);
            }

            return ConnectionMultiplexer.Connect(configOptions);
        });

        return services;
    }
}

