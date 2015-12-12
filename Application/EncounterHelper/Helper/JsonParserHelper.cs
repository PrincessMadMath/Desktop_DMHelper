using System.Collections.Generic;
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
    }
}