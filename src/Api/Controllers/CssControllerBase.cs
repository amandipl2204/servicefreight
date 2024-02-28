using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Utilities.Contract;

namespace Api.Controllers
{
    public abstract class CssControllerBase : ControllerBase
    {
        [NonAction]
        public virtual ActionResult HandleResponse(IResponseWrappers responseWrappers, int statusCode = StatusCodes.Status200OK)
        {
            if (responseWrappers.HasMessages)
            {
                statusCode = StatusCodes.Status400BadRequest;

                return this.StatusCode(
                    statusCode,
                    responseWrappers.ToMessageStatus(
                        ReasonPhrases.GetReasonPhrase(statusCode),
                        statusCode.ToString()));
            }

            var response = responseWrappers.ToResponse(
                ReasonPhrases.GetReasonPhrase(statusCode),
                statusCode.ToString());

            return this.StatusCode(statusCode, response);
        }
    }
}
