using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
namespace _3K1SNRDB.DAL
{
    public static class RedisCRUD
    {
        public static ConnectionMultiplexer _connection = ConnectionMultiplexer.Connect(Helper.CnnValRedis());
        public static void SetRecord<T> (string recordId,
            T data,
            TimeSpan? absoluteExpireTime = null)
        {
            var jsonData = JsonSerializer.Serialize(data);
            _connection.GetDatabase().StringSet(recordId, jsonData, absoluteExpireTime);
        }
        
        public static T GetRecord<T>(string recordId)
        {
            RedisValue jsonData = _connection.GetDatabase().StringGet(recordId); 
            if(jsonData == RedisValue.Null)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}
