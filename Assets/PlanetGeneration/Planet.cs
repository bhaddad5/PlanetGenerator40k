using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Planet
{
	public string Name => NameBuilder.GetName("PlanetName");
	public virtual string PlanetTypeName => "";
	public string Ruler => "Ruler: " + NameBuilder.GetName("PlanetRulerName");
	public virtual PlanetDefenseForce Defenses => new CivilizedWorldDefenseForce();
}

public class AgriPlanet : Planet
{
	public override string PlanetTypeName => "Agri World";
}

public class HiveWorld : Planet
{
	public override string PlanetTypeName => "Hive World";
	public override PlanetDefenseForce Defenses => new HiveWorldDefenseForce();
}

public class CivilizedWorld : Planet
{
	public override string PlanetTypeName => "Civilized World";
}

public class FeudalWorld : Planet
{
	public override string PlanetTypeName => "Feudal World";
	public override PlanetDefenseForce Defenses => new FeudalWorldDefenseForce();
}

public class ForgeWorld : Planet
{
	public override string PlanetTypeName => "Forge World";
	public override PlanetDefenseForce Defenses => new ForgeWorldDefenseForce();
}