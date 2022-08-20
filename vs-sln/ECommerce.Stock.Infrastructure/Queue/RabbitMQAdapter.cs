using ECommerce.Stock.Domain;
using System.Threading.Channels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ECommerce.Stock.Infrastructure.Queue;

public sealed class RabbitMQAdapter : IQueue
{
    //IConnection connection;

    public RabbitMQAdapter() {}

    public async Task Connect()
    {
        //ConnectionFactory factory = new ConnectionFactory();
        //factory.Uri = new Uri("amqp://localhost");
        //connection = factory.CreateConnection();
        await Task.CompletedTask;
    }

    public async Task Close()
    {
	    //connection.Close();
        await Task.CompletedTask;
    }

    public async Task Consume<T>(String eventName, Action<T> callback)
    {
        //const channel = await this.connection.createChannel();
        //await channel.assertQueue(eventName, { durable: true });
        //await channel.consume(eventName, async function(msg: any) {
        //    if (msg)
        //    {
        //        const input = JSON.parse(msg.content.toString());
        //        await callback(input);
        //        channel.ack(msg);
        //    }
        //});
        await Task.CompletedTask;
    }

    public async Task Publish(DomainEvent domainEvent)
    {
        //const channel = await this.connection.createChannel();
        //await channel.assertQueue(domainEvent.name, { durable: true });
        //channel.sendToQueue(domainEvent.name, Buffer.from(JSON.stringify(domainEvent)));
        await Task.CompletedTask;
    }
}
