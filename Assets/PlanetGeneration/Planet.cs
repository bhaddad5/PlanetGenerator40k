using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Planet
{
	public virtual string GetName => NameBuilder.GetName("PlanetName");
	public virtual string GetPlanetTypeName => "";
	public virtual string GetRuler => NameBuilder.GetName("PlanetRulerName");
	public virtual PlanetDefenseForce GetDefenses => new CivilizedWorldDefenseForce();
}

public class AgriPlanet : Planet
{
	public override string GetPlanetTypeName => "Agri World";
	public override PlanetDefenseForce GetDefenses => new AgriWorldDefenseForce();
}

public class HiveWorld : Planet
{
	public override string GetPlanetTypeName => "Hive World";
	public override PlanetDefenseForce GetDefenses => new HiveWorldDefenseForce();
}

public class CivilizedWorld : Planet
{
	public override string GetPlanetTypeName => "Civilized World";
}

public class FeudalWorld : Planet
{
	public override string GetRuler => NameBuilder.GetName("FeudalPlanetRuler");
	public override string GetPlanetTypeName => "Feudal World";
	public override PlanetDefenseForce GetDefenses => new FeudalWorldDefenseForce();
}

public class ForgeWorld : Planet
{
	public override string GetPlanetTypeName => "Forge World";
	public override PlanetDefenseForce GetDefenses => new ForgeWorldDefenseForce();
}