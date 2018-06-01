using System;
using System.Configuration;
using StackExchange.Redis;

namespace JYM.Lib
{
    public class RedisHelper
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(GetOptions()));

        private static readonly string redisConectionStr = ConfigurationManager.AppSettings["RedisConectionStr"];

        public static IDatabase GetBizRedisClient()
        {
            return LazyConnection.Value.GetDatabase(0, new object());
        }

        private static ConfigurationOptions GetOptions()
        {
            ConfigurationOptions options = ConfigurationOptions.Parse(redisConectionStr, true);
            options.AbortOnConnectFail = false;
            options.AllowAdmin = true;
            options.ConnectRetry = 10;
            options.ConnectTimeout = 20000;
            options.DefaultDatabase = 0;
            options.ResponseTimeout = 20000;
            options.Ssl = false;
            options.SyncTimeout = 20000;
            return options;
        }
    }
}