namespace Task1
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
	internal class Program
	{
		static void Main(string[] args)
		{			
			try
			{
				Console.Write("Введите первое число: ");
					
				if (!double.TryParse(Console.ReadLine(), out double firstNumber))
					throw new FormatException();

				Console.Write("Введите второе число: ");

				if (!double.TryParse(Console.ReadLine(), out double secondNumber))
					throw new FormatException();

				ICalculate calculate = new Calculate();
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