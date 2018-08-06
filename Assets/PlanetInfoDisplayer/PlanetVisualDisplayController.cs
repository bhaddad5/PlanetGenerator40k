using System.Collections;
using System.Collections.Generic;
using PlanetGen;
using UnityEngine;

public class PlanetVisualDisplayController : MonoBehaviour
{
	[SerializeField] private PlanetAssetLookup MatLookup;

	public void SetupBiome(Biome biome)
	{
		var displayInfo = MatLookup.GetBiomeDisplayInfo(biome);
		var planet = GetComponent<HPlanet>();

		planet.HeightMap = displayInfo.Heights.Heights;
		planet.NormalsMap = displayInfo.Heights.HeightsNormal;
		planet.DetailsMap = displayInfo.Details;
		planet.Frost = displayInfo.FrostLevel;
		planet.VegetationColor = displayInfo.VegitationColor;
		planet.WaterLevel = displayInfo.WaterLevel;
		planet.AtmosphereColor = displayInfo.AtmosphereColor;
		planet.LiquidColor = displayInfo.WaterColor;
		planet.EmissiveWater = displayInfo.EmissiveWater;

		GetComponent<HPlanet>().RandomSeed = Random.Range(0, 1000);
		GetComponent<HPlanet>().UpdateDetailsGradientMap();
		GetComponent<HPlanet>().UpdateHeightGradientMap();
	}
}
