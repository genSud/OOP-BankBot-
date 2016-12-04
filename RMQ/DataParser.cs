using System;
using Microsoft.Practices.Unity;

namespace RMQ
{
	public interface IParserGetter
	{
		IParse GetParser(string data);
	}

	public class DataParser : IParserGetter
	{


		private readonly IUnityContainer _container;

		public DataParser()
		{
		}

		public DataParser(IUnityContainer container)
		{
			_container = container;
		}

		public IParse GetParser(string data)
		{
			Console.WriteLine("I'm in GETPARSER");
			
			switch (data)
			{
				case "1":
					Console.WriteLine("I'm in case1");
					return _container.Resolve<IParse1>();
					
				case "2":
					return _container.Resolve<IParse2>();
					
				case "3":
					return _container.Resolve<IParse3>();
					
				default:
					throw new NotImplementedException();
			}
		}

	}

	public interface IParse
	{
		string[] ParseData(string data);
	}

	public interface IParse1 : IParse
	{
	}
	public interface IParse2 : IParse
	{
	}
	public interface IParse3 : IParse
	{
	}

	public class ParserCurrency : IParse1
	{
		public string[] ParseData(string data)
		{

			Console.WriteLine("I'm in parsedata!");
			string[] subStrings = data.Split('_');
			return subStrings;
		}

	}

	public class ParserLocation : IParse2
	{
		public string[] ParseData(string data)
		{
			Console.WriteLine("I'm in parselocation!");
			string[] subStrings = data.Split(',');
			return subStrings;
		}

	}
	public class ParserLoan : IParse3
	{
		public string[] ParseData(string data)
		{

			Console.WriteLine("I'm in parseloan!");
			string[] subStrings = data.Split(' ');
			return subStrings;
		}

	}
}