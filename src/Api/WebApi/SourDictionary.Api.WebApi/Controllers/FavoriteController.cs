namespace SourDictionary.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : BaseController
    {
        private readonly IMediator _mediator;

        public FavoriteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("entry/{entryId}")]
        public async Task<IActionResult> CreateEntryFav(Guid entryId)
        {
            var result = await _mediator.Send(new CreateEntryFavoriteCommand(entryId, UserId));
            return Ok(result);
        }

        [HttpPost]
        [Route("entrycomment/{entrycommentId}")]
        public async Task<IActionResult> CreateEntryCommentFav(Guid entrycommentId)
        {
            var result = await _mediator.Send(new CreateEntryCommentFavoriteCommand(entrycommentId, UserId.Value));
            return Ok(result);
        }


        [HttpPost]
        [Route("deleteentryfav/{entryId}")]
        public async Task<IActionResult> DeleteEntryFav(Guid entryId)
        {
            var result = await _mediator.Send(new DeleteEntryFavoriteCommand(entryId, UserId.Value));
            return Ok(result);
        }

        [HttpPost]
        [Route("deleteentrycommentfav/{entrycommentId}")]
        public async Task<IActionResult> DeleteEntryCommentFav(Guid entrycommentId)
        {
            var result = await _mediator.Send(new DeleteEntryCommentFavoriteCommand(entrycommentId, UserId.Value));
            return Ok(result);
        }
    }
}
