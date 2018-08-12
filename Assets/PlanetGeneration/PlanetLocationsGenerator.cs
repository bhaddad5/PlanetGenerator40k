using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLocationsData
{
	public List<LocationData> Locations = new List<LocationData>();

	public PlanetLocationsData(PlanetLocationsGenerator planetLocsGen)
	{
		foreach (LocationGenerator location in planetLocsGen.PlanetaryLocations())
		{
			Locations.Add(new LocationData(location));
		}
	}
}

public abstract class PlanetLocationsGenerator
{
	public virtual int NumLocations => 1;

	protected virtual List<LocationGenerator> LocationTypes => new List<LocationGenerator>()
	{
		new HiveCityGenerator(),
	};

	public List<LocationGenerator> PlanetaryLocations()
	{
		List<LocationGenerator> locations = new List<LocationGenerator>();
		for (int i = 0; i < NumLocations; i++)
		{
			locations.Add(LocationTypes[Random.Range(0, LocationTypes.Count)]);
		}
		return locations;
	}
}

public class HiveWorldLocationsGenerator : PlanetLocationsGenerator
{
	public override int NumLocations => 3;
}