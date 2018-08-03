using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IFExperiment.Shared.Util
{
    public static class ConverterJson
    {
        private static readonly JsonSerializerSettings _serializerSettings;

        static ConverterJson()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public static string ObjetoParaJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, _serializerSettings);
        }

    }
}
