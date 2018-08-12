using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
	public static T Oneof<T>(params T[] options)
	{
		return options[Random.Range(0, options.Length)];
	}
}
