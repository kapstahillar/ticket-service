using Microsoft.AspNetCore.Mvc;

namespace AgileWorksAPI.Tests.Helpers;
public static class ActionResultExtensions
{
    public static T ReturnValue<T>(this ActionResult<T> result)
    {
        return result.Result == null ? result.Value : (T)((ObjectResult)result.Result).Value;
    }
}