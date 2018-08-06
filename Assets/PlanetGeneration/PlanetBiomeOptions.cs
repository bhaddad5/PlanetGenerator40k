using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlanetBiomeOptions
{
	protected virtual List<Biome> BiomeOptions => new List<Biome>() { new Continental() };

	public Biome GetPlanetBiome()
	{
		return BiomeOptions[Random.Range(0, BiomeOptions.Count)];
	}
}

public class AgriWorldBiomeOptions : PlanetBiomeOptions
{
	protected override List<Biome> BiomeOptions => new List<Biome>()
	{
		new Continental(),
	};
}

public class CivilizedWorldBiomeOptions : PlanetBiomeOptions
{
	protected override List<Biome> BiomeOptions => new List<Biome>()
	{
		new Continental(),
		new Arid(),
		new Jungle(),
		new Alpine(),
	};
}

public class HiveWorldBiomeOptions : PlanetBiomeOptions
{
	protected override List<Biome> BiomeOptions => new List<Biome>()
	{
		new Continental(),
		new Arid(),
		new Jungle(),
		new Desert(),
		new Arctic(),
		new Alpine(),
	};
}

public class ForgeWorldBiomeOptions : PlanetBiomeOptions
{
	protected override List<Biome> BiomeOptions => new List<Biome>()
	{
		new Arid(),
		new Dead(),
		new Molten(),
	};
}

public class FeudaleWorldBiomeOptions : PlanetBiomeOptions
{
	protected override List<Biome> BiomeOptions => new List<Biome>()
	{
		new Continental(),
		new Alpine(),
	};
}