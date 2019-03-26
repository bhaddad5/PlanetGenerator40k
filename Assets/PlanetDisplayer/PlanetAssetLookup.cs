using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

	public enum PlanetTextures
	{
		HeightsSpiral,
		HeightsRegular,
		HeightsContinental,
		HeightsCraters,
		HeightsHigher,
	}

	public TexNormalPair GetPlanetTexture(PlanetTextures val)
	{
		switch (val)
		{
			case PlanetTextures.HeightsSpiral: return HeightsSpiral;
			case PlanetTextures.HeightsRegular: return HeightsRegular;
			case PlanetTextures.HeightsContinental: return HeightsContinental;
			case PlanetTextures.HeightsCraters: return HeightsCraters;
			case PlanetTextures.HeightsHigher: return HeightsHigher;
		}
		return HeightsContinental;
	}

	[Header("Details")]
	[SerializeField] private Texture DetailsFlatter;
	[SerializeField] private Texture DetailsRegular;

	public enum DetailsTextures
	{
		DetailsFlatter,
		DetailsRegular,
	}

	public Texture GetDetailsTexture(DetailsTextures val)
	{
		switch (val)
		{
			case DetailsTextures.DetailsFlatter: return DetailsFlatter;
			case DetailsTextures.DetailsRegular: return DetailsRegular;
		}
		return DetailsRegular;
	}

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
	[SerializeField] private Color DeadRust;

	public enum VegitationColors
	{
		AridLightBrown,
		AridDarkBrown,
		AridMediumBrown,
		DesertYellow,
		DesertWhite,
		JungleLightGreen,
		JungleDarkGreen,
		ArcticWhite,
		ArcticBluishWhite,
		PlainsGreenish,
		PlainsYellowish,
		AlpineForest,
		MoltonAshDark,
		MoltonAshLight,
		DeadGray,
		DeadRust,
	}

	public Color GetVegitationColor(VegitationColors val)
	{
		switch (val)
		{
			case VegitationColors.AridLightBrown: return AridLightBrown;
			case VegitationColors.AridDarkBrown: return AridDarkBrown;
			case VegitationColors.AridMediumBrown: return AridMediumBrown;
			case VegitationColors.DesertYellow: return DesertYellow;
			case VegitationColors.DesertWhite: return DesertWhite;
			case VegitationColors.JungleLightGreen: return JungleLightGreen;
			case VegitationColors.JungleDarkGreen: return JungleDarkGreen;
			case VegitationColors.ArcticWhite: return ArcticWhite;
			case VegitationColors.ArcticBluishWhite: return ArcticBluishWhite;
			case VegitationColors.PlainsGreenish: return PlainsGreenish;
			case VegitationColors.PlainsYellowish: return PlainsYellowish;
			case VegitationColors.AlpineForest: return AlpineForest;
			case VegitationColors.MoltonAshDark: return MoltonAshDark;
			case VegitationColors.MoltonAshLight: return MoltonAshLight;
			case VegitationColors.DeadGray: return DeadGray;
			case VegitationColors.DeadRust: return DeadRust;
		}
		return AridLightBrown;
	}

	[Header("Water Colors")]
	[SerializeField] private Color LightBlueWater;
	[SerializeField] private Color DarkBlueWater;

	[SerializeField] private Color LightLava;
	[SerializeField] private Color DarkLava;

	public enum WaterColors
	{
		LightBlueWater,
		DarkBlueWater,
		LightLava,
		DarkLava,
	}

	public Color GetWaterColor(WaterColors val)
	{
		switch (val)
		{
			case WaterColors.LightBlueWater: return LightBlueWater;
			case WaterColors.DarkBlueWater: return DarkBlueWater;
			case WaterColors.LightLava: return LightLava;
			case WaterColors.DarkLava: return DarkLava;
		}
		return LightBlueWater;
	}

	[Header("Atmosphere Colors")]
	[SerializeField] private Color LightAtmosphere;

	[SerializeField] private Color LavaAtmosphere;

	public enum AtmosphereColors
	{
		LightAtmosphere,
		LavaAtmosphere,
	}

	public Color GetAtmosphereColor(AtmosphereColors val)
	{
		switch (val)
		{
			case AtmosphereColors.LavaAtmosphere: return LavaAtmosphere;
			case AtmosphereColors.LightAtmosphere: return LightAtmosphere;
		}
		return LightAtmosphere;
	}
}
