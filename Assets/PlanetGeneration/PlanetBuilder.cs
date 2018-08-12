using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBuilder : MonoBehaviour
{
	public PlanetInfoDisplayer PlanetDisplayer;

	void Start()
	{
		GeneratePlanet();
	}

	public void GeneratePlanet()
	{
		PlanetData planetData = GetPlanet();

		PlanetDisplayer.DisplayPlanet(planetData);
	}

	private List<PlanetDataGenerator> PlanetTypes = new List<PlanetDataGenerator>()
	{
		new HiveWorld(),
		new AgriWorld(),
		new CivilizedWorld(),
		new FeudalWorld(),
		new ForgeWorld(),
		new MiningWorld(),
	};

	private PlanetData GetPlanet()
	{
		return new PlanetData(PlanetTypes[Random.Range(0, PlanetTypes.Count)]);
	}
	
}
