﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public BiomeData(BiomeGenerator generator)
	{
		Description = generator.Descriptor;
		Heights = generator.GetHeights;
		Details = generator.GetDetails;
		FrostLevel = generator.FrostLevel;
		WaterLevel = generator.WaterLevel;
		VegitationColor = generator.GetVegitationColor;
		WaterColor = generator.GetWaterColor;
		AtmosphereColor = generator.GetAtmosphereColor;
		EmissiveWater = generator.EmissiveWater;
		Size = generator.Size;
	}
}

public abstract class BiomeGenerator
{
	protected float fullFrost = .34f;
	protected float normalFrost = .112f;

	protected float noWater = .55f;
	protected float regularWater = .709f;

	public virtual string Descriptor => "PlanetType";
	public virtual bool EmissiveWater => false;
	public virtual float FrostLevel => Random.Range(0, normalFrost);
	public virtual float WaterLevel => Random.Range(noWater, regularWater);
	public virtual float Size => Random.Range(.25f, .65f);

	public virtual PlanetAssetLookup.PlanetTextures GetHeights => Helpers.Oneof(PlanetAssetLookup.PlanetTextures.HeightsContinental);
	public virtual PlanetAssetLookup.DetailsTextures GetDetails => Helpers.Oneof(PlanetAssetLookup.DetailsTextures.DetailsFlatter, PlanetAssetLookup.DetailsTextures.DetailsRegular);
	public virtual PlanetAssetLookup.VegitationColors GetVegitationColor => Helpers.Oneof(PlanetAssetLookup.VegitationColors.AridDarkBrown);
	public virtual PlanetAssetLookup.WaterColors GetWaterColor => Helpers.Oneof(PlanetAssetLookup.WaterColors.LightBlueWater, PlanetAssetLookup.WaterColors.DarkBlueWater);
	public virtual PlanetAssetLookup.AtmosphereColors GetAtmosphereColor => Helpers.Oneof(PlanetAssetLookup.AtmosphereColors.LightAtmosphere);
	
}

public class Continental : BiomeGenerator
{
	public override string Descriptor => "Continental";

	public override float FrostLevel => Random.Range(normalFrost - .05f, normalFrost + .05f);
	public override float WaterLevel => Random.Range(regularWater - .05f, regularWater + .05f);

	public override PlanetAssetLookup.PlanetTextures GetHeights => Helpers.Oneof(
		PlanetAssetLookup.PlanetTextures.HeightsRegular,
		PlanetAssetLookup.PlanetTextures.HeightsContinental
	);

	public override PlanetAssetLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		PlanetAssetLookup.VegitationColors.PlainsGreenish,
		PlanetAssetLookup.VegitationColors.PlainsYellowish,
		PlanetAssetLookup.VegitationColors.JungleLightGreen
	);
}

public class Desert : BiomeGenerator
{
	public override string Descriptor => "Desert";

	public override float FrostLevel => Random.Range(0, normalFrost);
	public override float WaterLevel => Random.Range(noWater, noWater + .045f);

	public override PlanetAssetLookup.PlanetTextures GetHeights => Helpers.Oneof(
		PlanetAssetLookup.PlanetTextures.HeightsRegular,
		PlanetAssetLookup.PlanetTextures.HeightsContinental
	);

	public override PlanetAssetLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		PlanetAssetLookup.VegitationColors.AridLightBrown,
		PlanetAssetLookup.VegitationColors.DesertWhite,
		PlanetAssetLookup.VegitationColors.DesertYellow
	);
}

public class Dead : BiomeGenerator
{
	public override string Descriptor => "Dead";

	public override float FrostLevel => Random.Range(0, fullFrost - .22f);
	public override float WaterLevel => 0;
	public override float Size => .1f;

	public override PlanetAssetLookup.PlanetTextures GetHeights => Helpers.Oneof(
		PlanetAssetLookup.PlanetTextures.HeightsCraters
	);

	public override PlanetAssetLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		PlanetAssetLookup.VegitationColors.MoltonAshDark,
		PlanetAssetLookup.VegitationColors.MoltonAshLight,
		PlanetAssetLookup.VegitationColors.DeadGray,
		PlanetAssetLookup.VegitationColors.DeadRust
	);
}

public class Jungle : BiomeGenerator
{
	public override string Descriptor => "Jungle";

	public override float FrostLevel => Random.Range(0, normalFrost);
	public override float WaterLevel => Random.Range(regularWater - .05f, regularWater + .05f);

	public override PlanetAssetLookup.PlanetTextures GetHeights => Helpers.Oneof(
		PlanetAssetLookup.PlanetTextures.HeightsRegular,
		PlanetAssetLookup.PlanetTextures.HeightsContinental
	);

	public override PlanetAssetLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		PlanetAssetLookup.VegitationColors.JungleDarkGreen,
		PlanetAssetLookup.VegitationColors.JungleLightGreen
	);
}

public class Arid : BiomeGenerator
{
	public override string Descriptor => "Arid";

	public override float FrostLevel => Random.Range(0, normalFrost);
	public override float WaterLevel => Random.Range(noWater, noWater + .075f);

	public override PlanetAssetLookup.PlanetTextures GetHeights => Helpers.Oneof(
		PlanetAssetLookup.PlanetTextures.HeightsRegular,
		PlanetAssetLookup.PlanetTextures.HeightsHigher
	);

	public override PlanetAssetLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		PlanetAssetLookup.VegitationColors.AridDarkBrown,
		PlanetAssetLookup.VegitationColors.AridLightBrown,
		PlanetAssetLookup.VegitationColors.AridMediumBrown
	);
}

public class Arctic : BiomeGenerator
{
	public override string Descriptor => "Arctic";

	public override float FrostLevel => Random.Range(fullFrost - .12f, fullFrost);
	public override float WaterLevel => Random.Range(regularWater - .05f, regularWater + .05f);

	public override PlanetAssetLookup.PlanetTextures GetHeights => Helpers.Oneof(
		PlanetAssetLookup.PlanetTextures.HeightsRegular,
		PlanetAssetLookup.PlanetTextures.HeightsCraters
	);

	public override PlanetAssetLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		PlanetAssetLookup.VegitationColors.ArcticWhite,
		PlanetAssetLookup.VegitationColors.ArcticBluishWhite
	);
}

public class Molten : BiomeGenerator
{
	public override string Descriptor => "Molten";

	public override float FrostLevel => 0;
	public override float WaterLevel => Random.Range(regularWater - .05f, regularWater + .05f);
	public override bool EmissiveWater => true;

	public override PlanetAssetLookup.PlanetTextures GetHeights => Helpers.Oneof(
		PlanetAssetLookup.PlanetTextures.HeightsRegular,
		PlanetAssetLookup.PlanetTextures.HeightsContinental,
		PlanetAssetLookup.PlanetTextures.HeightsHigher
	);

	public override PlanetAssetLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		PlanetAssetLookup.VegitationColors.MoltonAshDark,
		PlanetAssetLookup.VegitationColors.MoltonAshLight
	);

	public override PlanetAssetLookup.WaterColors GetWaterColor => Helpers.Oneof(
		PlanetAssetLookup.WaterColors.DarkLava,
		PlanetAssetLookup.WaterColors.LightLava
	);

	public override PlanetAssetLookup.AtmosphereColors GetAtmosphereColor => PlanetAssetLookup.AtmosphereColors.LavaAtmosphere;
}

public class Alpine : BiomeGenerator
{
	public override string Descriptor => "Alpine";

	public override float FrostLevel => Random.Range(fullFrost - .2f, fullFrost - .12f);
	public override float WaterLevel => Random.Range(regularWater - .05f, regularWater + .05f);

	public override PlanetAssetLookup.PlanetTextures GetHeights => Helpers.Oneof(
		PlanetAssetLookup.PlanetTextures.HeightsRegular,
		PlanetAssetLookup.PlanetTextures.HeightsContinental
	);

	public override PlanetAssetLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		PlanetAssetLookup.VegitationColors.AlpineForest
	);
}