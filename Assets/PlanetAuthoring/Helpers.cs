using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
	public static T Oneof<T>(params T[] options)
	{
		return options[Random.Range(0, options.Length)];
	}

	public static T GetRandom<T>(this List<T> list)
	{
		return list[Random.Range(0, list.Count)];
	}
}
