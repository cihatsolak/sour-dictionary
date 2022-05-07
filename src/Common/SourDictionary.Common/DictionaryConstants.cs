namespace SourDictionary.Common
{
    public class DictionaryConstants
    {
        public const string RabbitMQHost = "localhost";

        public const string DefaultExchangeType = "direct";


        public const string UserExchangeName = "UserExchange";
        public const string FavoriteExchangeName = "FavoriteExchange";
        public const string VoteExchangeName = "VoteExchange";


        public const string UserWelcomeEmailQueueName = "UserWelcomeEmailQueue";
        public const string UserEmailChangedQueueName = "UserEmailChangedQueue";
        public const string CreateEntryCommentFavoriteQueueName = "CreateEntryCommentFavoriteQueue";
        public const string CreateEntryVoteQueueName = "CreateEntryVoteQueue";
        public const string DeleteEntryFavoriteQueueName = "DeleteEntryFavoriteQueue";
        public const string DeleteEntryVoteQueueName = "DeleteEntryVoteQueue";
        public const string CreateEntryCommentVoteQueueName = "CreateEntryCommentVoteQueue";
    }
}
