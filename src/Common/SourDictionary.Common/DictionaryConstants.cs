namespace SourDictionary.Common
{
    public class DictionaryConstants
    {
        public const string RabbitMQHost = "localhost";

        public const string DefaultExchangeType = "direct";

        public const string UserExchangeName = "UserExchange";
        public const string UserWelcomeEmailQueueName = "UserWelcomeEmailQueue";
        public const string UserEmailChangedQueueName = "UserEmailChangedQueue";

        public const string FavoriteExchangeName = "FavoriteExchangeName";
        public const string CreateEntryCommentFavoriteQueueName = "CreateEntryCommentFavoriteQueue";
    }
}
