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
	}

	public void SetupBiome(Biome biome)
	{
		var displayInfo = MatLookup.GetBiomeDisplayInfo(biome);

		planet.HeightMap = displayInfo.Heights.Heights;
		planet.NormalsMap = displayInfo.Heights.HeightsNormal;
		planet.DetailsMap = displayInfo.Details;
		planet.Frost = displayInfo.FrostLevel;
		planet.VegetationColor = displayInfo.VegitationColor;
		planet.WaterLevel = displayInfo.WaterLevel;
		planet.AtmosphereColor = displayInfo.AtmosphereColor;
		planet.LiquidColor = displayInfo.WaterColor;
		planet.EmissiveWater = displayInfo.EmissiveWater;
		planet.Size = Random.Range(.25f, .65f);

		GetComponent<HPlanet>().RandomSeed = Random.Range(0, 1000);
	}
}
