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

	[Header("Colors")]
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

	private float fullFrost = .34f;
	private float normalFrost = .112f;

	private float noWater = .55f;
	private float regularWater = .709f;

	public BiomeDisplayInfo GetBiomeDisplayInfo(Biome biome)
	{
		Texture details = oneof(DetailsFlatter, DetailsRegular);
		if (biome is Arid)
			return new BiomeDisplayInfo()
			{
				Heights = oneof(HeightsCraters, HeightsHigher),
				Details = details,
				FrostLevel = Random.Range(0, normalFrost),
				WaterLevel = Random.Range(noWater, noWater + .075f),
				VegitationColor = oneof(AridLightBrown, AridDarkBrown, AridMediumBrown)
			};
		if (biome is Jungle)
			return new BiomeDisplayInfo()
			{
				Heights = oneof(HeightsRegular, HeightsContinental),
				Details = details,
				FrostLevel = Random.Range(0, normalFrost),
				WaterLevel = Random.Range(regularWater-.05f, regularWater + .05f),
				VegitationColor = oneof(JungleDarkGreen, JungleLightGreen)
			};
		if (biome is Arctic)
			return new BiomeDisplayInfo()
			{
				Heights = oneof(HeightsRegular, HeightsCraters),
				Details = details,
				FrostLevel = Random.Range(fullFrost - .12f, fullFrost),
				WaterLevel = Random.Range(regularWater - .05f, regularWater + .05f),
				VegitationColor = oneof(ArcticWhite, ArcticBluishWhite)
			};
		if (biome is Desert)
			return new BiomeDisplayInfo()
			{
				Heights = oneof(HeightsRegular, HeightsContinental),
				Details = details,
				FrostLevel = Random.Range(0, normalFrost),
				WaterLevel = Random.Range(noWater, noWater + .045f),
				VegitationColor = oneof(AridLightBrown, DesertYellow, DesertWhite)
			};
		if (biome is Continental)
			return new BiomeDisplayInfo()
			{
				Heights = oneof(HeightsRegular, HeightsContinental),
				Details = details,
				FrostLevel = Random.Range(normalFrost-.05f, normalFrost+.05f),
				WaterLevel = Random.Range(regularWater - .05f, regularWater + .05f),
				VegitationColor = oneof(PlainsGreenish, PlainsYellowish, JungleLightGreen)
			};
		if (biome is Alpine)
			return new BiomeDisplayInfo()
			{
				Heights = oneof(HeightsRegular, HeightsContinental),
				Details = details,
				FrostLevel = Random.Range(fullFrost - .2f, fullFrost - .12f),
				WaterLevel = Random.Range(regularWater - .05f, regularWater + .05f),
				VegitationColor = oneof(AlpineForest)
			};
		if (biome is Molten)
			return new BiomeDisplayInfo()
			{
				Heights = oneof(HeightsRegular, HeightsContinental),
				Details = details,
			};
		if (biome is Dead)
			return new BiomeDisplayInfo()
			{
				Heights = oneof(HeightsCraters),
				Details = details,
			};

		return new BiomeDisplayInfo()
		{
			Heights = oneof(HeightsRegular, HeightsContinental),
			Details = details,
		};
	}

	private T oneof<T>(params T[] options)
	{
		return options[Random.Range(0, options.Length)];
	}
}
