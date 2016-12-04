using System;
using RabbitMQ.Client;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace BankBot
{
	public class Client
	{
		public string action;
		public string arguments;
		public Dictionary <string, string> queryDictionary;  

		public void chooseAction()
		{			
			action = Console.ReadLine();
			arguments = Console.ReadLine();

			queryDictionary = new Dictionary<string, string>();
			queryDictionary.Add(action, arguments);

			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "BankQueue",
									 durable: false);


				// convert to JSON
				string queryJSON = JsonConvert.SerializeObject(queryDictionary);
				Console.WriteLine(queryJSON);

				var body = Encoding.UTF8.GetBytes(queryJSON);
				//var body = queryDictionary;

				channel.BasicPublish(exchange: "",
				                     routingKey: "BankQueue",
					 				 basicProperties: null,
				                     body: body);



				Console.WriteLine(" You've chosen {0} ", queryDictionary[action]);
			}

			Console.WriteLine(" Press [enter] to exit.");
			Console.ReadLine();
		}
	}
}
