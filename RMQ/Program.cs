using System;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;


namespace RMQ
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Receive r = new Receive();
			r.Main();
			//Worker bw1 = new Worker();


			/*switch (r.message)
			{
				case "1":
					Console.WriteLine("currency");
					break;

				case "2":
					Console.WriteLine("location");
					break;
					
				case "3":
					Console.WriteLine("loan");
					break;
			}*/
		}
	}

}


