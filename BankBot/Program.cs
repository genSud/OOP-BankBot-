using System;

namespace BankBot
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Client curClient = new Client();
			UIClass curUI = new UIClass();
			curUI.HelloMessage();
			curClient.chooseAction();

		}
	}
}
