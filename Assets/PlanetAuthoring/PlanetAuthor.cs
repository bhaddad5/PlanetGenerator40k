using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAuthor : MonoBehaviour
{
	public PlanetInfoDisplayer PlanetDisplayer;

	void Start()
	{
		GeneratePlanet();
	}

	public void GeneratePlanet()
	{
		BiomeData planetData = GetPlanet();

		PlanetDisplayer.DisplayPlanet(planetData);
	}

	private List<BiomeGenerator> PlanetTypes = new List<BiomeGenerator>()
	{
		new Continental(),
		new Arid(),
		new Jungle(),
		new Desert(),
		new Arctic(),
		new Alpine(),
		new Dead(),
		new Molten(),
	};

	private BiomeData GetPlanet()
	{
		return PlanetTypes[Random.Range(0, PlanetTypes.Count)].GenerateBiome();
	}
	
}
