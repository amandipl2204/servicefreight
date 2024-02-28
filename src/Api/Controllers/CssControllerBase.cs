using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    public abstract class CssControllerBase : ControllerBase
    {
        [NonAction]
        public virtual ActionResult HandleResponse(int statusCode = StatusCodes.Status200OK)
        {
            return this.StatusCode(statusCode);
        }
    }
}
