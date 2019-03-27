using System.Collections;
using System.Collections.Generic;
using PlanetGen;
using UnityEngine;

public class PlanetVisualizer : MonoBehaviour
{
	private HPlanet biomeVis;
	public void Setup(PlanetData data)
	{
		biomeVis = transform.GetChild(0).GetComponent<HPlanet>();
		SetupDefaultBiomeValues();
		SetupBiome(data.BiomeData);
		SetupGeoData(data.GeoData);
	}

	private void SetupGeoData(PlanetGeoData data)
	{
		biomeVis.GetComponent<PlanetRotator>().RotationSpeed = data.RotationSpeed;
		biomeVis.transform.localScale = Vector3.one * data.Size;
	}

	//Setup values that won't change
	private void SetupDefaultBiomeValues()
	{
		biomeVis.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Human Unit/Planet Simple"));
		biomeVis.PlanetMaterial = biomeVis.GetComponent<MeshRenderer>().material;

		biomeVis.ShoresContrast = 1f;
		biomeVis.OceanOpacity = 1f;
		biomeVis.Specularity = .655f;
		biomeVis.FrostContrast = 1f;
		biomeVis.Heat = 0f;
		biomeVis.Fertility = .9f;
		biomeVis.VegetationContrast = .5f;
		biomeVis.VegetationFrostResistance = .57f;
		biomeVis.Ambient = .652f;
		biomeVis.Relief = 1f;
		biomeVis.AtmosphereBrightness = .05f;
	}

	private void SetupBiome(BiomeData biome)
	{
		var matLookup = AssetLookup.Instance.PlanetAssetLookup;
		biomeVis.HeightMap = matLookup.GetPlanetTexture(biome.Heights).Heights;
		biomeVis.NormalsMap = matLookup.GetPlanetTexture(biome.Heights).HeightsNormal;
		biomeVis.DetailsMap = matLookup.GetDetailsTexture(biome.Details);
		biomeVis.Frost = biome.FrostLevel;
		biomeVis.WaterLevel = biome.WaterLevel;
		biomeVis.VegetationColor = matLookup.GetVegitationColor(biome.VegitationColor);
		biomeVis.AtmosphereColor = matLookup.GetAtmosphereColor(biome.AtmosphereColor);
		biomeVis.LiquidColor = matLookup.GetWaterColor(biome.WaterColor);
		biomeVis.EmissiveWater = biome.EmissiveWater;
		biomeVis.Size = biome.Size;
		biomeVis.RandomSeed = biome.Seed;
	}
}
