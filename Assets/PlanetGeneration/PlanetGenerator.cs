using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
	public PlanetInfoDisplayer PlanetDisplayer;

	public void GeneratePlanet()
	{
		Planet planet = GetPlanet();

		PlanetDisplayer.DisplayPlanet(planet);
	}

	public List<Planet> PlanetTypes = new List<Planet>()
	{
		new HiveWorld(),
		new AgriPlanet(),
		new CivilizedWorld(),
	};

	public Planet GetPlanet()
	{
		return PlanetTypes[Random.Range(0, PlanetTypes.Count)];
	}
	
}
