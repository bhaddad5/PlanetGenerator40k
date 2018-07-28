using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Planet
{
	public string Name => NameBuilder.GetName("PlanetName");
	public virtual string PlanetTypeName => "";
}

public class AgriPlanet : Planet
{
	public override string PlanetTypeName => "Agri World";
}

public class HiveWorld : Planet
{
	public override string PlanetTypeName => "Hive World";
}

public class CivilizedWorld : Planet
{
	public override string PlanetTypeName => "Hive World";
}