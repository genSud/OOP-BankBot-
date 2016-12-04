using System;
using Microsoft.Practices.Unity;

namespace RMQ
{
	public class Bootstrapper
	{
		public static void SetupContainer(IUnityContainer unityContainer)
		{
			unityContainer
				.RegisterType<IParserGetter, DataParser>()
				.RegisterType<IParse1, ParserCurrency>()
				.RegisterType<IParse2, ParserLocation>()
				.RegisterType<IParse3, ParserLoan>();
		}
	}
}
