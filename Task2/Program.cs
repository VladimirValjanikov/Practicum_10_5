namespace Task2
{
	interface ICalculate
	{
		double Sum(double num1, double num2);
	}
	public class Calculate : ICalculate
	{
		public double Sum(double num1, double num2)
		{
			return num1 + num2;
		}
	}
	public interface ILogger
	{
		void Event(string message);
		void Error(string message);
	}
	public class Logger : ILogger
	{
		public void Event(string message)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(message);
		}
		public void Error(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
		}
	}
	public interface ICallLogger
	{
		public void CallLog();
	}
	public class CallEvent : ICallLogger
	{
		ILogger Logger { get; }
		public CallEvent(ILogger logger)
		{
			Logger = logger;
		}
		public void CallLog()
		{
			Logger.Event("Произошло сложение чисел");
		}
	}
	public class CallError : ICallLogger
	{
		ILogger Logger { get; }
		public CallError(ILogger logger)
		{
			Logger = logger;
		}
		public void CallLog()
		{
			Logger.Error("Произошла ошибка");
		}
	}

	internal class Program
	{
		static ILogger Logger { get; set; }
		
		static void Main(string[] args)
		{
			Logger = new Logger();
			ICallLogger callEvent = new CallEvent(Logger);
			ICallLogger callError = new CallError(Logger);
		
			try
			{
				Console.Write("Введите первое число: ");

				if (!double.TryParse(Console.ReadLine(), out double firstNumber))
					throw new FormatException();

				Console.Write("Введите второе число: ");

				if (!double.TryParse(Console.ReadLine(), out double secondNumber))
					throw new FormatException();

				ICalculate calculate = new Calculate();
				callEvent.CallLog();
				Console.Write("Сумма чисел: ");
				Console.WriteLine(calculate.Sum(firstNumber, secondNumber));
			}
			catch (FormatException ex)
			{
				callError.CallLog();
				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();
		}
	}
}