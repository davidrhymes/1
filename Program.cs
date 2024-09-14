using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehog
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] population = { 0, 10, 1 }; // enter amount of hedgehogs r,g,b
			int stepsCount = 0; // amount of steps to reach target color

			Console.WriteLine("[r,g,b]\n[" + string.Join(",", population) + "]");
			if (!CheckData(population))
			{
				return;
			}

			Console.WriteLine("Enter target color.");
			int targetColor = int.Parse(Console.ReadLine()); // color you wanna transform to 0,1,2
			Console.WriteLine("Target color: " + targetColor);

			stepsCount = CheckSteps(population, targetColor);
			switch(stepsCount)
			{
				case 0:
					Console.WriteLine("Hedgehogs are already in target color");
					break;
				case -1:
					Console.WriteLine("Unable to transform hedgehogs to target color");
					break;
				default:
					Console.WriteLine("Transformation will take " + stepsCount + " steps");
					break;
			}
		}

		public static bool CheckData(int[] population)
		{
			if (population.Any(x => x < 0))
			{
				Console.WriteLine("Enter valid data!");
				return false;
			}
			if (population.Sum() == 0)
			{
				Console.WriteLine("Enter valid data!");
				return false;
			}
			return true;
		}

		public static int CheckSteps(int[] population, int targetColor)
		{
			int red = population[0];
			int green = population[1];
			int blue = population[2];
			int max;

			switch(targetColor)
			{
				case 0:
					if (green == blue || green == 0 && blue == 0)
					{
						return green;
					}
					if (CanTransform(green, blue))
					{
						max = Math.Max(green, blue);
						return max;
					}
					return -1;
				case 1:
					if (red == blue || red == 0 && blue == 0)
					{
						return red;
					}
					if (CanTransform(red, blue))
					{
						max = Math.Max(red, blue);
						return max;
					}
					return -1;
				case 2:
					if (red == green || red == 0 && green == 0)
					{
						return red;
					}
					if (CanTransform(red, green))
					{
						max = Math.Max(red, green);
						return max;
					}
					return -1;
				default:
					return -1;
			}
		}

		public static bool CanTransform(int color1, int color2)
		{
			if ((color1 - color2) % 3 == 0)
			{
				return true;
			}
			return false;
		}
	}
}
