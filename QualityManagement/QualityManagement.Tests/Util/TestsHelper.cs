using Newtonsoft.Json;

namespace QualityManagement.Tests.Util
{
    public static class TestsHelper
    {
        public static bool VerificarEntidadesIguais(object objeto1, object objeto2)
        {
            return JsonConvert.SerializeObject(objeto1) == JsonConvert.SerializeObject(objeto2);
        }
    }
}
