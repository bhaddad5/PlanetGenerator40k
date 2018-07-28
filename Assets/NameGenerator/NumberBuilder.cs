using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NumberBuilder
{
	public static string GetNumberString(int min, int max)
	{
		int number = Random.Range(min, max + 1);
		int numDigits = number.ToString().Length;

		if (numDigits <= 3)
			return number.ToString();
		else if (numDigits <= 6)
			return (number / 1000).ToString() + " thousand";
		else if (numDigits <= 9)
			return (number / 1000000).ToString() + " million";
		else if (numDigits <= 12)
			return (number / 1000000000).ToString() + " billion";
		else if (numDigits <= 15)
			return (number / 1000000000000).ToString() + " trillion";
		else return number.ToString();
	}
}
