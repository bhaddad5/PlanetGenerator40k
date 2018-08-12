using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBiomeData
{
	public Biome Biome;

	public PlanetBiomeData(PlanetBiomeGenerator biomeGen)
	{
		Biome = biomeGen.GetPlanetBiome();
	}
}

public abstract class PlanetBiomeGenerator
{
	protected virtual List<Biome> BiomeOptions => new List<Biome>() { new Continental() };

	public Biome GetPlanetBiome()
	{
		return BiomeOptions[Random.Range(0, BiomeOptions.Count)];
	}
}

public class AgriWorldBiomeGenerator : PlanetBiomeGenerator
{
	protected override List<Biome> BiomeOptions => new List<Biome>()
	{
		new Continental(),
	};
}

public class CivilizedWorldBiomeGenerator : PlanetBiomeGenerator
{
	protected override List<Biome> BiomeOptions => new List<Biome>()
	{
		new Continental(),
		new Arid(),
		new Jungle(),
		new Alpine(),
	};
}

public class HiveWorldBiomeGenerator : PlanetBiomeGenerator
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

public class ForgeWorldBiomeGenerator : PlanetBiomeGenerator
{
	protected override List<Biome> BiomeOptions => new List<Biome>()
	{
		new Arid(),
		new Dead(),
		new Molten(),
	};
}

public class MiningWorldBiomeGenerator : PlanetBiomeGenerator
{
	protected override List<Biome> BiomeOptions => new List<Biome>()
	{
		new Arid(),
		new Arctic(),
		new Desert(),
		new Dead(),
		new Molten(),
	};
}

public class FeudaleWorldBiomeGenerator : PlanetBiomeGenerator
{
	protected override List<Biome> BiomeOptions => new List<Biome>()
	{
		new Continental(),
		new Alpine(),
	};
}