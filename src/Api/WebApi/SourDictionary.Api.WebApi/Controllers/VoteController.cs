namespace SourDictionary.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : BaseController
    {
        private readonly IMediator _mediator;

        public VoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Entry/{entryId}")]
        public async Task<IActionResult> CreateEntryVote(Guid entryId, VoteType voteType = VoteType.UpVote)
        {
            var result = await _mediator.Send(new CreateEntryVoteCommand(entryId, voteType, UserId.Value));
            return Ok(result);
        }

        [HttpPost]
        [Route("EntryComment/{entryCommentId}")]
        public async Task<IActionResult> CreateEntryCommentVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
        {
            var result = await _mediator.Send(new CreateEntryCommentVoteCommand(entryCommentId, voteType, UserId.Value));
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteEntryVote/{entryId}")]
        public async Task<IActionResult> DeleteEntryVote(Guid entryId)
        {
            await _mediator.Send(new DeleteEntryVoteCommand(entryId, UserId.Value));
            return Ok();
        }

        [HttpPost]
        [Route("DeleteEntryCommentVote/{entryId}")]
        public async Task<IActionResult> DeleteEntryCommentVote(Guid entryCommentId)
        {
            await _mediator.Send(new DeleteEntryCommentVoteCommand(entryCommentId, UserId.Value));
            return Ok();
        }
    }
}
