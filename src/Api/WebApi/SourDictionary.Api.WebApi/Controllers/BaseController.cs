namespace SourDictionary.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public Guid? UserId => GetUserId();

        private Guid? GetUserId()
        {
            var claim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim is null)
                return default;

            return Guid.Parse(claim.Value);
        }
    }
}
