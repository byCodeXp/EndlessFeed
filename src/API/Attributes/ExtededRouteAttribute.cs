using Microsoft.AspNetCore.Mvc;

namespace API.Attributes
{
    public class ExtendedRouteAttribute : RouteAttribute
    {
        public ExtendedRouteAttribute(string template, int version) : base($"api/v{version.ToString()}/{template}")
        {
        }
    }
}