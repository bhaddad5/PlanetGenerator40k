using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

public static class NumberBuilder
{
	public static string GetNumberString(long number)
	{
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

	public static long GetRandomNumber(long min, long max)
	{
		return LongRandom(min, max + 1, new Random(UnityEngine.Random.Range(0, 1000)));
	}

	private static long LongRandom(long min, long max, Random rand)
	{
		byte[] buf = new byte[8];
		rand.NextBytes(buf);
		long longRand = BitConverter.ToInt64(buf, 0);

		return (Math.Abs(longRand % (max - min)) + min);
	}
}
