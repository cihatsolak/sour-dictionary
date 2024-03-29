﻿namespace SourDictionary.Api.Application.Features.Commands.Entry.DeleteFavorite
{
    public class DeleteEntryFavoriteCommand : IRequest<bool>
    {
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }

        public DeleteEntryFavoriteCommand(Guid entryId, Guid userId)
        {
            EntryId = entryId;
            UserId = userId;
        }
    }
}
