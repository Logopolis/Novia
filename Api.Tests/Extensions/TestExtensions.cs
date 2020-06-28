using Newtonsoft.Json;

namespace Api.Tests.Extensions
{
    public static class TestExtensions
    {
        public static bool ObjectMembersEqual(this object objA, object objB)
        {
            return JsonConvert.SerializeObject(objA) == JsonConvert.SerializeObject(objB);
        }
    }
}
