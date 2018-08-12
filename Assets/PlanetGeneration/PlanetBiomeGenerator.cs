using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBiomeData
{
	public BiomeGenerator BiomeGenerator;

	public PlanetBiomeData(PlanetBiomeGenerator biomeGen)
	{
		BiomeGenerator = biomeGen.GetPlanetBiomeGenerator();
	}
}

public abstract class PlanetBiomeGenerator
{
	protected virtual List<BiomeGenerator> BiomeOptions => new List<BiomeGenerator>() { new Continental() };

	public BiomeGenerator GetPlanetBiomeGenerator()
	{
		return BiomeOptions[Random.Range(0, BiomeOptions.Count)];
	}
}

public class AgriWorldBiomeGenerator : PlanetBiomeGenerator
{
	protected override List<BiomeGenerator> BiomeOptions => new List<BiomeGenerator>()
	{
		new Continental(),
	};
}

public class CivilizedWorldBiomeGenerator : PlanetBiomeGenerator
{
	protected override List<BiomeGenerator> BiomeOptions => new List<BiomeGenerator>()
	{
		new Continental(),
		new Arid(),
		new Jungle(),
		new Alpine(),
	};
}

public class HiveWorldBiomeGenerator : PlanetBiomeGenerator
{
	protected override List<BiomeGenerator> BiomeOptions => new List<BiomeGenerator>()
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
	protected override List<BiomeGenerator> BiomeOptions => new List<BiomeGenerator>()
	{
		new Arid(),
		new Dead(),
		new Molten(),
	};
}

public class MiningWorldBiomeGenerator : PlanetBiomeGenerator
{
	protected override List<BiomeGenerator> BiomeOptions => new List<BiomeGenerator>()
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
	protected override List<BiomeGenerator> BiomeOptions => new List<BiomeGenerator>()
	{
		new Continental(),
		new Alpine(),
	};
}