using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Planet
{
	public virtual string GetName => NameBuilder.GetName("PlanetName");
	public virtual string GetPlanetTypeName => "";
	public virtual string GetRuler => NameBuilder.GetName("PlanetRulerName");
	public virtual PlanetDefenseForce GetDefenses => new CivilizedWorldDefenseForce();
	public virtual PlanetBiomeOptions PlanetBiome => new CivilizedWorldBiomeOptions();
	public virtual string Population => "";
}

public class AgriWorld : Planet
{
	public override string GetPlanetTypeName => "Agri World";
	public override PlanetDefenseForce GetDefenses => new AgriWorldDefenseForce();
	public override PlanetBiomeOptions PlanetBiome => new AgriWorldBiomeOptions();
	public override string Population => NumberBuilder.GetNumberString(500000, 100000000);
}

public class HiveWorld : Planet
{
	public override string GetPlanetTypeName => "Hive World";
	public override PlanetDefenseForce GetDefenses => new HiveWorldDefenseForce();
	public override PlanetBiomeOptions PlanetBiome => new HiveWorldBiomeOptions();
	public override string Population => NumberBuilder.GetNumberString(5000000000, 100000000000);
}

public class CivilizedWorld : Planet
{
	public override string GetPlanetTypeName => "Civilized World";
	public override PlanetBiomeOptions PlanetBiome => new CivilizedWorldBiomeOptions();
	public override string Population => NumberBuilder.GetNumberString(5000000, 1000000000);
}

public class FeudalWorld : Planet
{
	public override string GetRuler => NameBuilder.GetName("FeudalPlanetRuler");
	public override string GetPlanetTypeName => "Feudal World";
	public override PlanetDefenseForce GetDefenses => new FeudalWorldDefenseForce();
	public override PlanetBiomeOptions PlanetBiome => new FeudaleWorldBiomeOptions();
	public override string Population => NumberBuilder.GetNumberString(5000000, 100000000);
}

public class ForgeWorld : Planet
{
	public override string GetPlanetTypeName => "Forge World";
	public override PlanetDefenseForce GetDefenses => new ForgeWorldDefenseForce();
	public override PlanetBiomeOptions PlanetBiome => new ForgeWorldBiomeOptions();
	public override string Population => NumberBuilder.GetNumberString(5000000, 10000000000);
}

public class MiningWorld : Planet
{
	public override string GetPlanetTypeName => "Mining World";
	public override PlanetDefenseForce GetDefenses => new AgriWorldDefenseForce();
	public override PlanetBiomeOptions PlanetBiome => new MiningWorldBiomeOptions();
	public override string Population => NumberBuilder.GetNumberString(500000, 100000000);
}