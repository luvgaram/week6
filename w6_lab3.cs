using System;

namespace w6_lab3
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Palindrome (Input()));
		}
	
		public static string Input ()
		{
			Console.Write ("Input word : ");
			string input = Console.ReadLine ();
			return input;
		}
		public static string Palindrome (string input)
		{
			string palindrome = "T";
			while (palindrome == "T" && input.Length > 2){
				if (input [0] == input [input.Length - 1]) {
					input = input.Substring (1, input.Length - 2);
					Palindrome (input);
				} else {
					palindrome = "F";
				}
			}
			return palindrome;
		} 

		/*
		public static void Palindrome ()
		{
			Console.Write ("Input word like 'm i l k', 'm o m' : ");
			String[] input = Console.ReadLine ().Split (' ');
			string palindrome = "T";
			for (int i = 0; i < (input.Length / 2) && palindrome == "T"; i++) {
				if (input [i] != input [input.Length - i - 1]) {
					palindrome = "F";
				}
			}
			Console.WriteLine (palindrome);
		}*/
	}
}
