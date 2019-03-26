using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetInfoDisplayer : MonoBehaviour
{
	public PlanetVisualDisplayController PlanetVisualizer;

	public void DisplayPlanet(BiomeData planetData)
	{
		PlanetVisualizer.SetupBiome(planetData);
	}
}
