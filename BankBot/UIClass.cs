using System;
namespace BankBot
{
	public class UIClass
	{
		public UIClass()
		{
		}
		public void HelloMessage()
		{
			Console.WriteLine("We are happy to see you as our client, please choose the number of command");
			Console.WriteLine("1 - currency, 2 - location, 3 - loan");
		}
	}
}
