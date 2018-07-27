using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGeneratorTest : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < 20; i++)
		{
			Debug.Log(NameBuilder.GetName("PlanetName"));
		}
	}
}
