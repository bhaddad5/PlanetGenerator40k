using System.Collections;
using System.Collections.Generic;
using PlanetGen;
using UnityEngine;

public class PlanetVisualDisplayController : MonoBehaviour
{
	[SerializeField] private PlanetAssetLookup MatLookup;

	private HPlanet planet;

	void Start()
	{
		planet = GetComponent<HPlanet>();

		GetComponent<MeshRenderer>().material = new Material(Shader.Find("Human Unit/Planet Simple"));
		planet.PlanetMaterial = GetComponent<MeshRenderer>().material;

		//Setup values that won't change
		planet.Size = .65f;
		planet.ShoresContrast = 1f;
		planet.OceanOpacity = 1f;
		planet.Specularity = .655f;
		planet.FrostContrast = 1f;
		planet.Heat = 0f;
		planet.Fertility = .9f;
		planet.VegetationContrast = .5f;
		planet.VegetationFrostResistance = .57f;
		planet.Ambient = .652f;
		planet.Relief = 1f;
		planet.AtmosphereBrightness = .05f;
	}

	public void SetupBiome(BiomeData biome)
	{

		planet.HeightMap = MatLookup.GetPlanetTexture(biome.Heights).Heights;
		planet.NormalsMap = MatLookup.GetPlanetTexture(biome.Heights).HeightsNormal;
		planet.DetailsMap = MatLookup.GetDetailsTexture(biome.Details);
		planet.Frost = biome.FrostLevel;
		planet.WaterLevel = biome.WaterLevel;
		planet.VegetationColor = MatLookup.GetVegitationColor(biome.VegitationColor);
		planet.AtmosphereColor = MatLookup.GetAtmosphereColor(biome.AtmosphereColor);
		planet.LiquidColor = MatLookup.GetWaterColor(biome.WaterColor);
		planet.EmissiveWater = biome.EmissiveWater;
		planet.Size = biome.Size;
		planet.RandomSeed = biome.Seed;
	}
}
