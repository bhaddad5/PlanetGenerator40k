using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public virtual MaterialLookup.PlanetTextures GetHeights => Helpers.Oneof(MaterialLookup.PlanetTextures.HeightsContinental);
	public virtual MaterialLookup.DetailsTextures GetDetails => Helpers.Oneof(MaterialLookup.DetailsTextures.DetailsFlatter, MaterialLookup.DetailsTextures.DetailsRegular);
	public virtual MaterialLookup.VegitationColors GetVegitationColor => Helpers.Oneof(MaterialLookup.VegitationColors.AridDarkBrown);
	public virtual MaterialLookup.WaterColors GetWaterColor => Helpers.Oneof(MaterialLookup.WaterColors.LightBlueWater, MaterialLookup.WaterColors.DarkBlueWater);
	public virtual MaterialLookup.AtmosphereColors GetAtmosphereColor => Helpers.Oneof(MaterialLookup.AtmosphereColors.LightAtmosphere);
	public int Seed => Random.Range(0, 1000);

	public BiomeData GenerateBiome()
	{
		return new BiomeData()
		{
			Description = Descriptor,
			Heights = GetHeights,
			Details = GetDetails,
			FrostLevel = FrostLevel,
			WaterLevel = WaterLevel,
			VegitationColor = GetVegitationColor,
			WaterColor = GetWaterColor,
			AtmosphereColor = GetAtmosphereColor,
			EmissiveWater = EmissiveWater,
			Size = Size,
			Seed = Seed,
	};
	}
}

public class Continental : BiomeGenerator
{
	public override string Descriptor => "Continental";

	public override float FrostLevel => Random.Range(normalFrost - .05f, normalFrost + .05f);
	public override float WaterLevel => Random.Range(regularWater - .05f, regularWater + .05f);

	public override MaterialLookup.PlanetTextures GetHeights => Helpers.Oneof(
		MaterialLookup.PlanetTextures.HeightsRegular,
		MaterialLookup.PlanetTextures.HeightsContinental
	);

	public override MaterialLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		MaterialLookup.VegitationColors.PlainsGreenish,
		MaterialLookup.VegitationColors.PlainsYellowish,
		MaterialLookup.VegitationColors.JungleLightGreen
	);
}

public class Desert : BiomeGenerator
{
	public override string Descriptor => "Desert";

	public override float FrostLevel => Random.Range(0, normalFrost);
	public override float WaterLevel => Random.Range(noWater, noWater + .045f);

	public override MaterialLookup.PlanetTextures GetHeights => Helpers.Oneof(
		MaterialLookup.PlanetTextures.HeightsRegular,
		MaterialLookup.PlanetTextures.HeightsContinental
	);

	public override MaterialLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		MaterialLookup.VegitationColors.AridLightBrown,
		MaterialLookup.VegitationColors.DesertWhite,
		MaterialLookup.VegitationColors.DesertYellow
	);
}

public class Dead : BiomeGenerator
{
	public override string Descriptor => "Dead";

	public override float FrostLevel => Random.Range(0, fullFrost - .22f);
	public override float WaterLevel => 0;
	public override float Size => .1f;

	public override MaterialLookup.PlanetTextures GetHeights => Helpers.Oneof(
		MaterialLookup.PlanetTextures.HeightsCraters
	);

	public override MaterialLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		MaterialLookup.VegitationColors.MoltonAshDark,
		MaterialLookup.VegitationColors.MoltonAshLight,
		MaterialLookup.VegitationColors.DeadGray,
		MaterialLookup.VegitationColors.DeadRust
	);
}

public class Jungle : BiomeGenerator
{
	public override string Descriptor => "Jungle";

	public override float FrostLevel => Random.Range(0, normalFrost);
	public override float WaterLevel => Random.Range(regularWater - .05f, regularWater + .05f);

	public override MaterialLookup.PlanetTextures GetHeights => Helpers.Oneof(
		MaterialLookup.PlanetTextures.HeightsRegular,
		MaterialLookup.PlanetTextures.HeightsContinental
	);

	public override MaterialLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		MaterialLookup.VegitationColors.JungleDarkGreen,
		MaterialLookup.VegitationColors.JungleLightGreen
	);
}

public class Arid : BiomeGenerator
{
	public override string Descriptor => "Arid";

	public override float FrostLevel => Random.Range(0, normalFrost);
	public override float WaterLevel => Random.Range(noWater, noWater + .075f);

	public override MaterialLookup.PlanetTextures GetHeights => Helpers.Oneof(
		MaterialLookup.PlanetTextures.HeightsRegular,
		MaterialLookup.PlanetTextures.HeightsHigher
	);

	public override MaterialLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		MaterialLookup.VegitationColors.AridDarkBrown,
		MaterialLookup.VegitationColors.AridLightBrown,
		MaterialLookup.VegitationColors.AridMediumBrown
	);
}

public class Arctic : BiomeGenerator
{
	public override string Descriptor => "Arctic";

	public override float FrostLevel => Random.Range(fullFrost - .12f, fullFrost);
	public override float WaterLevel => Random.Range(regularWater - .05f, regularWater + .05f);

	public override MaterialLookup.PlanetTextures GetHeights => Helpers.Oneof(
		MaterialLookup.PlanetTextures.HeightsRegular,
		MaterialLookup.PlanetTextures.HeightsCraters
	);

	public override MaterialLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		MaterialLookup.VegitationColors.ArcticWhite,
		MaterialLookup.VegitationColors.ArcticBluishWhite
	);
}

public class Molten : BiomeGenerator
{
	public override string Descriptor => "Molten";

	public override float FrostLevel => 0;
	public override float WaterLevel => Random.Range(regularWater - .05f, regularWater + .05f);
	public override bool EmissiveWater => true;

	public override MaterialLookup.PlanetTextures GetHeights => Helpers.Oneof(
		MaterialLookup.PlanetTextures.HeightsRegular,
		MaterialLookup.PlanetTextures.HeightsContinental,
		MaterialLookup.PlanetTextures.HeightsHigher
	);

	public override MaterialLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		MaterialLookup.VegitationColors.MoltonAshDark,
		MaterialLookup.VegitationColors.MoltonAshLight
	);

	public override MaterialLookup.WaterColors GetWaterColor => Helpers.Oneof(
		MaterialLookup.WaterColors.DarkLava,
		MaterialLookup.WaterColors.LightLava
	);

	public override MaterialLookup.AtmosphereColors GetAtmosphereColor => MaterialLookup.AtmosphereColors.LavaAtmosphere;
}

public class Alpine : BiomeGenerator
{
	public override string Descriptor => "Alpine";

	public override float FrostLevel => Random.Range(fullFrost - .2f, fullFrost - .12f);
	public override float WaterLevel => Random.Range(regularWater - .05f, regularWater + .05f);

	public override MaterialLookup.PlanetTextures GetHeights => Helpers.Oneof(
		MaterialLookup.PlanetTextures.HeightsRegular,
		MaterialLookup.PlanetTextures.HeightsContinental
	);

	public override MaterialLookup.VegitationColors GetVegitationColor => Helpers.Oneof(
		MaterialLookup.VegitationColors.AlpineForest
	);
}