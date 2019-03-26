using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlanetData
{
	public string Name;
}

[Serializable]
public class PlanetLocation
{
	public string Name;
}

[Serializable]
public class BiomeData
{
	public string Description;
	public PlanetAssetLookup.PlanetTextures Heights;
	public PlanetAssetLookup.DetailsTextures Details;
	public float FrostLevel;
	public float WaterLevel;
	public PlanetAssetLookup.VegitationColors VegitationColor;
	public PlanetAssetLookup.WaterColors WaterColor;
	public PlanetAssetLookup.AtmosphereColors AtmosphereColor;
	public bool EmissiveWater;
	public float Size;
	public int Seed;
}