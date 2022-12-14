namespace Task2
{
	public interface ICalculate
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
	public interface IPainter
	{
		public void Paint();
	}
	public class Painter : IPainter
	{
		ILogger Logger { get; }
		public Painter(ILogger logger)
		{
			Logger = logger;
		}
		public void Paint()
		{
			//Logger.
		}
	}

	internal class Program
	{
		static ILogger Logger { get; set; }
		
		static void Main(string[] args)
		{
			Logger = new Logger();
			try
			{
				Console.Write("Введите первое число: ");

				if (!double.TryParse(Console.ReadLine(), out double firstNumber))
					throw new FormatException();

				Console.Write("Введите второе число: ");

				if (!double.TryParse(Console.ReadLine(), out double secondNumber))
					throw new FormatException();

				var calculate = new Calculate();
				Console.Write("Сумма чисел: ");
				Console.WriteLine(calculate.Sum(firstNumber, secondNumber));
			}
			catch (FormatException ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();
		}
	}
}