namespace SourDictionary.Common.Infrastructure
{
    public static class QueueFactory
    {
        public static void SendMessageToExchange<TModel>(string exchangeName, string exchangeType, string queueName, TModel model) where TModel : class, new()
        {
            IModel channel = CreateBasicConsumer()
                         .EnsureExchange(exchangeName, exchangeType)
                         .EnsureQueue(exchangeName, queueName)
                         .Model;

            string jsonStringModel = JsonSerializer.Serialize(model);
            byte[] body = Encoding.UTF8.GetBytes(jsonStringModel);

            channel.BasicPublish(exchangeName, queueName, basicProperties: null, body: body);
        }

        public static EventingBasicConsumer CreateBasicConsumer()
        {
            ConnectionFactory connectionFactory = new()
            {
                HostName = DictionaryConstants.RabbitMQHost
            };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            return new EventingBasicConsumer(channel);
        }

        public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer consumer, string exchangeName, string exchangeType = DictionaryConstants.DefaultExchangeType)
        {
            consumer.Model.ExchangeDeclare(
                exchange: exchangeName,
                type: exchangeType,
                durable: false,
                autoDelete: false);

            return consumer;
        }

        public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer consumer, string exchangeName, string queueName)
        {
            consumer.Model.QueueDeclare(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                null);

            consumer.Model.QueueBind(
                queue: queueName,
                exchange: exchangeName,
                routingKey: queueName //direct exchange'de routingkey queue ismiyle aynı olur.
                );

            return consumer;
        }

        public static EventingBasicConsumer Receive<TModel>(this EventingBasicConsumer consumer, Action<TModel> action)
        {
            consumer.Received += (m, eventArgs) =>
            {
                byte[] body = eventArgs.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                TModel model = JsonSerializer.Deserialize<TModel>(message);

                action(model);
                consumer.Model.BasicAck(eventArgs.DeliveryTag, false);
            };

            return consumer;
        }

        public static EventingBasicConsumer StartConsuming(this EventingBasicConsumer consumer, string queueName)
        {
            consumer.Model.BasicConsume(queue: queueName,
                                        autoAck: false,
                                        consumer: consumer);

            return consumer;
        }
    }
}
