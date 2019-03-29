using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlanetData
{
	public string Id;
	public bool Moon;
	public BiomeData BiomeData;
	public PlanetGeoData GeoData;
	public List<PlanetDistrictData> Districts;
	public List<PlanetObjectData> Objects;
}

[Serializable]
public class PlanetDistrictData
{
	public string Id;
	public Vector3 AngleToDistrict;
	public string DistrictTypeId;
	public int DistrictLevel;
}

[Serializable]
public class PlanetObjectData
{
	public string ObjectId;
	public Vector3 AngleToObject;
}

[Serializable]
public class PlanetGeoData
{
	public float Size = 1f;
	public float RotationSpeed = 1f;
}

[Serializable]
public class BiomeData
{
	public string Description;
	public MaterialLookup.PlanetTextures Heights;
	public MaterialLookup.DetailsTextures Details;
	public float FrostLevel;
	public float WaterLevel;
	public MaterialLookup.VegitationColors VegitationColor;
	public MaterialLookup.WaterColors WaterColor;
	public MaterialLookup.AtmosphereColors AtmosphereColor;
	public bool EmissiveWater;
	public float Size;
	public int Seed;
}