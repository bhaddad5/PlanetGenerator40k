using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Biome
{
	public virtual string Descriptor => "PlanetType";
}

public class Continental : Biome
{
	public override string Descriptor => "Continental";
}

public class Desert : Biome
{
	public override string Descriptor => "Desert";
}

public class Dead : Biome
{
	public override string Descriptor => "Dead";
}

public class Jungle : Biome
{
	public override string Descriptor => "Jungle";
}

public class Arid : Biome
{
	public override string Descriptor => "Arid";
}

public class Arctic : Biome
{
	public override string Descriptor => "Arctic";
}

public class Molten : Biome
{
	public override string Descriptor => "Molten";
}