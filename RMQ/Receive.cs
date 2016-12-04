using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RMQ
{

	class Receive
	{
		
		public void Main()
		{
			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "BankQueue",
									 durable: false);

				var consumer = new EventingBasicConsumer();
				consumer.Received += (model, ea) =>
				{
					var body = ea.Body;
					var message = Encoding.UTF8.GetString(body);
					Console.WriteLine(" [x] Received {0}", message);

					Worker worker = new Worker();
					Console.WriteLine("I'm in here!");
					worker.GetString(message);
				};

				channel.BasicConsume(queue: "BankQueue",
									 noAck: true,
									 filter: null,
									 consumer: consumer);

				Console.WriteLine(" Press [enter] to exit.");
				//Console.ReadLine();

			}
		}
	}
}
