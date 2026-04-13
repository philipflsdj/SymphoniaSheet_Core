using Microsoft.AspNetCore.Mvc;
using SS.Api.Models.Common;
using SS.Domain.SeedWorks;

namespace SS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult CustomResponse<T>(Result<T> result)
        {
            if (result.Success)
                return Ok(ApiResponse<T>.Ok(result.Data, result.Message));

            return BadRequest(ApiResponse<T>.Fail(result.Errors.Any() ? result.Errors : new[] { result.Message }, result.Message));
        }

        protected IActionResult CustomResponse(Result result)
        {
            if (result.Success)
                return Ok(ApiResponse<object>.Ok(null, result.Message));

            return BadRequest(ApiResponse<object>.Fail(result.Errors.Any() ? result.Errors : new[] { result.Message }, result.Message));
        }

        protected IActionResult NotFoundResponse(string message)
        {
            return NotFound(ApiResponse<object>.Fail(message, message));
        }
    }
}
