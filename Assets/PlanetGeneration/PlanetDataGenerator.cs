using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetData
{
	public string Name;
	public string TypeName;
	public string Ruler;
	public long Population;
	public string PopulationString;
	public PlanetDefenseForceData DefensesData;
	public PlanetLocationsData LocationsData;
	public BiomeData BiomeData;

	public PlanetData(PlanetDataGenerator planetGen)
	{
		Name = planetGen.GetName;
		TypeName = planetGen.GetPlanetTypeName;
		Ruler = planetGen.GetRuler;
		Population = planetGen.GetPopulation;

		PopulationString = planetGen.GetPopulationString(Population);
		DefensesData = new PlanetDefenseForceData(planetGen.GetDefenses);
		LocationsData = new PlanetLocationsData(planetGen.LocationsGen, Population);
		BiomeData = new BiomeData(planetGen.PlanetBiome.GetPlanetBiomeGenerator());
	}
}

public abstract class PlanetDataGenerator
{
	public virtual string GetName => NameBuilder.GetName("PlanetName");
	public virtual string GetPlanetTypeName => "";
	public virtual string GetRuler => NameBuilder.GetName("PlanetRulerName");
	public virtual PlanetDefenseForceGenerator GetDefenses => new CivilizedWorldDefenseForceGenerator();
	public virtual PlanetBiomeGenerator PlanetBiome => new CivilizedWorldBiomeGenerator();
	public virtual PlanetLocationsGenerator LocationsGen => new HiveWorldLocationsGenerator();
	public virtual long GetPopulation => 0;
	public virtual string GetPopulationString(long pop) => NumberBuilder.GetNumberString(pop);
}

public class AgriWorld : PlanetDataGenerator
{
	public override string GetPlanetTypeName => "Agri World";
	public override PlanetDefenseForceGenerator GetDefenses => new AgriWorldDefenseForceGenerator();
	public override PlanetBiomeGenerator PlanetBiome => new AgriWorldBiomeGenerator();
	public override PlanetLocationsGenerator LocationsGen => new AgriWorldLocationsGenerator();
	public override long GetPopulation => NumberBuilder.GetRandomNumber(500000, 100000000);
}

public class HiveWorld : PlanetDataGenerator
{
	public override string GetPlanetTypeName => "Hive World";
	public override PlanetDefenseForceGenerator GetDefenses => new HiveWorldDefenseForceGenerator();
	public override PlanetBiomeGenerator PlanetBiome => new HiveWorldBiomeGenerator();
	public override PlanetLocationsGenerator LocationsGen => new HiveWorldLocationsGenerator();
	public override long GetPopulation => NumberBuilder.GetRandomNumber(5000000000, 100000000000);
}

public class CivilizedWorld : PlanetDataGenerator
{
	public override string GetPlanetTypeName => "Civilized World";
	public override PlanetBiomeGenerator PlanetBiome => new CivilizedWorldBiomeGenerator();
	public override PlanetLocationsGenerator LocationsGen => new CivilizedWorldLocationsGenerator();
	public override long GetPopulation => NumberBuilder.GetRandomNumber(5000000, 1000000000);
}

public class FeudalWorld : PlanetDataGenerator
{
	public override string GetRuler => NameBuilder.GetName("FeudalPlanetRuler");
	public override string GetPlanetTypeName => "Feudal World";
	public override PlanetDefenseForceGenerator GetDefenses => new FeudalWorldDefenseForceGenerator();
	public override PlanetBiomeGenerator PlanetBiome => new FeudaleWorldBiomeGenerator();
	public override PlanetLocationsGenerator LocationsGen => new FeudalWorldLocationsGenerator();
	public override long GetPopulation => NumberBuilder.GetRandomNumber(5000000, 100000000);
}

public class ForgeWorld : PlanetDataGenerator
{
	public override string GetPlanetTypeName => "Forge World";
	public override PlanetDefenseForceGenerator GetDefenses => new ForgeWorldDefenseForceGenerator();
	public override PlanetBiomeGenerator PlanetBiome => new ForgeWorldBiomeGenerator();
	public override PlanetLocationsGenerator LocationsGen => new ForgeWorldLocationsGenerator();
	public override long GetPopulation => NumberBuilder.GetRandomNumber(5000000, 10000000000);
}

public class MiningWorld : PlanetDataGenerator
{
	public override string GetPlanetTypeName => "Mining World";
	public override PlanetDefenseForceGenerator GetDefenses => new AgriWorldDefenseForceGenerator();
	public override PlanetBiomeGenerator PlanetBiome => new MiningWorldBiomeGenerator();
	public override PlanetLocationsGenerator LocationsGen => new MiningWorldLocationsGenerator();
	public override long GetPopulation => NumberBuilder.GetRandomNumber(500000, 100000000);
}