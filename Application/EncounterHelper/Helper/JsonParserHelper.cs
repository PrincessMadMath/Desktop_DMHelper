using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace Helper
{
    public static class JsonParserHelper
    {
        public static List<TType> ParseList<TType>(string serializeString)
        {
            List<TType> list = JsonConvert.DeserializeObject<List<TType>>(serializeString);
            return list;
        }

        public static TType ParseSingleton<TType>(string serializeString)
        {
            TType result = JsonConvert.DeserializeObject<TType>(serializeString);
            return result;
        }
    }
}