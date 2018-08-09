using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
	public PlanetInfoDisplayer PlanetDisplayer;

	void Start()
	{
		GeneratePlanet();
	}

	public void GeneratePlanet()
	{
		Planet planet = GetPlanet();

		PlanetDisplayer.DisplayPlanet(planet);
	}

	private List<Planet> PlanetTypes = new List<Planet>()
	{
		new HiveWorld(),
		new AgriPlanet(),
		new CivilizedWorld(),
		new FeudalWorld(),
		new ForgeWorld(),
		new MiningWorld(),
	};

	private Planet GetPlanet()
	{
		return PlanetTypes[Random.Range(0, PlanetTypes.Count)];
	}
	
}
