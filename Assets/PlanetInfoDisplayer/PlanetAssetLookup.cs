using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BiomeDisplayInfo
{
	public TexNormalPair Heights;
	public Texture Details;
	public float FrostLevel;
	public float WaterLevel;
	public Color VegitationColor;
	public Color WaterColor;
	public Color AtmosphereColor;
	public bool EmissiveWater;
}

[Serializable]
public class TexNormalPair
{
	[SerializeField] public Texture Heights;
	[SerializeField] public Texture HeightsNormal;
}

public class PlanetAssetLookup : MonoBehaviour
{
	[Header("Heights")]
	[SerializeField] private TexNormalPair HeightsSpiral;
	[SerializeField] private TexNormalPair HeightsRegular;
	[SerializeField] private TexNormalPair HeightsContinental;
	[SerializeField] private TexNormalPair HeightsCraters;
	[SerializeField] private TexNormalPair HeightsHigher;

	[Header("Details")]
	[SerializeField] private Texture DetailsFlatter;
	[SerializeField] private Texture DetailsRegular;

	[Header("Vegitation Colors")]
	[SerializeField] private Color AridLightBrown;
	[SerializeField] private Color AridDarkBrown;
	[SerializeField] private Color AridMediumBrown;

	[SerializeField] private Color DesertYellow;
	[SerializeField] private Color DesertWhite;

	[SerializeField] private Color JungleLightGreen;
	[SerializeField] private Color JungleDarkGreen;

	[SerializeField] private Color ArcticWhite;
	[SerializeField] private Color ArcticBluishWhite;

	[SerializeField] private Color PlainsGreenish;
	[SerializeField] private Color PlainsYellowish;

	[SerializeField] private Color AlpineForest;

	[SerializeField] private Color MoltonAshDark;
	[SerializeField] private Color MoltonAshLight;

	[SerializeField] private Color DeadGray;

	[Header("Water Colors")]
	[SerializeField] private Color LightBlueWater;
	[SerializeField] private Color DarkBlueWater;

	[SerializeField] private Color LightLava;
	[SerializeField] private Color DarkLava;

	[Header("Atmosphere Colors")]
	[SerializeField] private Color LightAtmosphere;

	[SerializeField] private Color LavaAtmosphere;

	private float fullFrost = .34f;
	private float normalFrost = .112f;

	private float noWater = .55f;
	private float regularWater = .709f;

	public BiomeDisplayInfo GetBiomeDisplayInfo(Biome biome)
	{
		var defaultInfo = new BiomeDisplayInfo()
		{
			Details = oneof(DetailsFlatter, DetailsRegular),
			WaterColor = oneof(LightBlueWater, DarkBlueWater),
			AtmosphereColor = LightAtmosphere,
			EmissiveWater = false,
		};


		if (biome is Arid)
		{
			defaultInfo.Heights = oneof(HeightsRegular, HeightsHigher);
			defaultInfo.FrostLevel = Random.Range(0, normalFrost);
			defaultInfo.WaterLevel = Random.Range(noWater, noWater + .075f);
			defaultInfo.VegitationColor = oneof(AridLightBrown, AridDarkBrown, AridMediumBrown);
		}
		if (biome is Jungle)
		{
			defaultInfo.Heights = oneof(HeightsRegular, HeightsContinental);
			defaultInfo.FrostLevel = Random.Range(0, normalFrost);
			defaultInfo.WaterLevel = Random.Range(regularWater - .05f, regularWater + .05f);
			defaultInfo.VegitationColor = oneof(JungleDarkGreen, JungleLightGreen);
		}
		if (biome is Arctic)
		{
			defaultInfo.Heights = oneof(HeightsRegular, HeightsCraters);
			defaultInfo.FrostLevel = Random.Range(fullFrost - .12f, fullFrost);
			defaultInfo.WaterLevel = Random.Range(regularWater - .05f, regularWater + .05f);
			defaultInfo.VegitationColor = oneof(ArcticWhite, ArcticBluishWhite);
		}
		if (biome is Desert)
		{
			defaultInfo.Heights = oneof(HeightsRegular, HeightsContinental);
			defaultInfo.FrostLevel = Random.Range(0, normalFrost);
			defaultInfo.WaterLevel = Random.Range(noWater, noWater + .045f);
			defaultInfo.VegitationColor = oneof(AridLightBrown, DesertYellow, DesertWhite);
		}
		if (biome is Continental)
		{
			defaultInfo.Heights = oneof(HeightsRegular, HeightsContinental);
			defaultInfo.FrostLevel = Random.Range(normalFrost - .05f, normalFrost + .05f);
			defaultInfo.WaterLevel = Random.Range(regularWater - .05f, regularWater + .05f);
			defaultInfo.VegitationColor = oneof(PlainsGreenish, PlainsYellowish, JungleLightGreen);
		}
		if (biome is Alpine)
		{
			defaultInfo.Heights = oneof(HeightsRegular, HeightsContinental);
			defaultInfo.FrostLevel = Random.Range(fullFrost - .2f, fullFrost - .12f);
			defaultInfo.WaterLevel = Random.Range(regularWater - .05f, regularWater + .05f);
			defaultInfo.VegitationColor = oneof(AlpineForest);
		}
		if (biome is Molten)
		{
			defaultInfo.Heights = oneof(HeightsRegular, HeightsContinental);
			defaultInfo.FrostLevel = 0;
			defaultInfo.WaterLevel = Random.Range(regularWater - .05f, regularWater + .05f);
			defaultInfo.VegitationColor = oneof(MoltonAshDark, MoltonAshLight);
			defaultInfo.WaterColor = oneof(LightLava, DarkLava);
			defaultInfo.AtmosphereColor = LavaAtmosphere;
			defaultInfo.EmissiveWater = true;
		}
		if (biome is Dead)
		{
			defaultInfo.Heights = oneof(HeightsRegular, HeightsCraters, HeightsCraters, HeightsCraters, HeightsHigher);
			defaultInfo.FrostLevel = Random.Range(0, fullFrost - .22f);
			defaultInfo.VegitationColor = oneof(MoltonAshDark, MoltonAshLight, DeadGray);
			defaultInfo.WaterLevel = 0;
		}

		return defaultInfo;
	}

	private T oneof<T>(params T[] options)
	{
		return options[Random.Range(0, options.Length)];
	}
}
