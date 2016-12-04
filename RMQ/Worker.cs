using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Practices.Unity;

namespace RMQ
{
	public class Worker
	{
		public Worker()
		{
		}
		public List<string> operations = new List<string>();
		public List<string> arguments = new List<string>();
		public string op;
		public string arg;

		public void GetString(string mystring)
		{
			Console.WriteLine("I'm in Getstring");
			Console.WriteLine(mystring);

			//deserialize from JSON back to Dictionary
			var query = JsonConvert.DeserializeObject<Dictionary<string, string>>(mystring);


			foreach (KeyValuePair<string, string> pair in query)
			{
				operations.Add(pair.Key);
				arguments.Add(pair.Value);
				using (var container = new UnityContainer())
				{
					Bootstrapper.SetupContainer(container);
					PerformParseGetter(pair.Key, container);
					PerformParseGetter(pair.Key, container);
					PerformParseGetter(pair.Key, container);
					PerformParseGetter(pair.Key, container);

				}


				Console.WriteLine(pair.Key+ "  -  " + pair.Value);
				

			}

		}

		void PerformParseGetter(string key, UnityContainer container)
		{
			Console.WriteLine("I'm in Performparsegetter");
			DataParser dp1 = new DataParser();
			dp1.GetParser(key);
			var dataparser = container.Resolve<IParse>();
			string[] mydata = dataparser.ParseData(key);
			foreach (string s in mydata)
			{
				Console.WriteLine(s + "        ");
			}

		}
}
}