using ECommerce.Stock.Domain;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ECommerce.Stock.Infrastructure.Queue;

public sealed class RabbitMQAdapter : IQueue
{
    private IBasicProperties BasicProperties;
    private IConnection Connection;
    private IModel Channel;

    public RabbitMQAdapter()
    {
        ConnectionFactory factory = new ConnectionFactory();
        factory.Uri = new Uri("amqp://localhost");
        Connection = factory.CreateConnection();
        Channel = Connection.CreateModel();
        BasicProperties = Channel.CreateBasicProperties();
    }

    public async Task Close()
    {
        Connection?.Close();
        await Task.CompletedTask;
    }

    public async Task Connect()
    {
        if (!Connection.IsOpen)
        {

        }
        await Task.CompletedTask;
    }

    public async Task Consume<T>(String eventName, Func<T, Task> callback)
    {
        Channel.QueueDeclare(queue: eventName, durable: true);

        var consumer = new AsyncEventingBasicConsumer(Channel);

        consumer.Received += async (model, ea) =>
        {
            var message = System.Text.Json.JsonSerializer.Deserialize<T>(ea.Body.Span);

            if (message is null)
            {
                // FAZER O QUE?
            }
            else
            {
                await callback(message);
                Channel.BasicAck(ea.DeliveryTag, multiple: false);
            }
        };
        Channel.BasicConsume(queue: eventName, autoAck: false, consumer: consumer);

        await Task.CompletedTask;
    }

    public void Dispose()
    {
        Channel?.Dispose();
        Connection?.Dispose();
    }

    public async Task Publish(DomainEvent domainEvent)  
    {
        var message = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(domainEvent, domainEvent.GetType());

        Channel.BasicPublish("", domainEvent.Name, true, BasicProperties, message);

        await Task.CompletedTask;
    }

}
