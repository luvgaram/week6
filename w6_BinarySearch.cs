using System;

namespace ch3_BinarySearch
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int i;
			int j;
			int m;
			int location;
			// array setting and print
			int [] Search = {100, 200, 300, 400, 500, 600};
			for(int s=0; s < Search.Length; s++){
				Console.Write("{0} ", Search[s]);
			}
			Console.WriteLine ();

			// get user's number input
			Console.Write ("Enter your number : ");
			int SearchNum = int.Parse(Console.ReadLine ());
			Console.WriteLine();

			i = 0;
			j = Search.Length - 1;

			while (i < (j)) {
				m = ((i + (j)) / 2);
				Console.WriteLine ("now binary point is {0}.", m+1);
				if (SearchNum > Search [m]) {
					Console.WriteLine ("Your number {0} > {1}.", SearchNum, Search[m]);
					i = m + 1;
					Console.WriteLine ("Next search area is {0} ~ {1}.", i + 1, j + 1);
				} else {
					Console.WriteLine ("Your number {0} <= {1}.", SearchNum, Search[m]);
					j = m;
					Console.WriteLine ("Next search area is {0} ~ {1}.", i + 1, j + 1);
				}
			}
			if (SearchNum == Search [i]) {
				location = i + 1;
			} else {
				location = 0;
			}
			Console.WriteLine ("your number is located in {0}.", location);
		}
	}
}
