using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationData
{
	public string LocationType;
	public string LocationName;
	public long LocationPopulationPrimary;
	public long LocationPopulationSecondary;
	public string LocationPopulationString;

	public LocationData(LocationGenerator locGen, long maxPop)
	{
		LocationType = locGen.LocationType;
		LocationName = locGen.LocationName;
		LocationPopulationPrimary = locGen.LocationPopulation(maxPop);
		LocationPopulationSecondary = locGen.LocationPopulationSecondary(maxPop);

		LocationPopulationString = locGen.LocationPopulationString(LocationPopulationPrimary, LocationPopulationSecondary);
	}
}

public abstract class LocationGenerator
{
	public virtual string LocationType => "";
	public virtual string LocationName => NameBuilder.GetName("HiveCity");
	public virtual long LocationPopulation(long maxPop) => 0;
	public virtual long LocationPopulationSecondary(long maxPop) => 0;
	public virtual string LocationPopulationString(long pop, long popSecondary) => "";
}

public class HiveCityGenerator : LocationGenerator
{
	public override string LocationType => "Hive City";
	public override string LocationName => NameBuilder.GetName("HiveCity");
	public override long LocationPopulation(long maxPop) => NumberBuilder.GetRandomNumber(Math.Min(100000000, maxPop/2), Math.Min(10000000000, maxPop));
	public override string LocationPopulationString(long pop, long popSecondary) => NumberBuilder.GetNumberString(pop) + " hivers";
}

public class FeudalCastleGenerator : LocationGenerator
{
	public override string LocationType => "Castle";
	public override string LocationName => NameBuilder.GetName("FeudalCastle");
	public override long LocationPopulation(long maxPop) => NumberBuilder.GetRandomNumber(20, 200);
	public override long LocationPopulationSecondary(long maxPop) => NumberBuilder.GetRandomNumber(Math.Min(maxPop, 10000), Math.Min(maxPop, 500000));
	public override string LocationPopulationString(long pop, long popSecondary) => NumberBuilder.GetNumberString(pop) + " nobles, " + NumberBuilder.GetNumberString(popSecondary) + " serfs";
}

public class ManufactorumGenerator : LocationGenerator
{
	public override string LocationType => "Manufactorum";
	public override string LocationName => NameBuilder.GetName("Factory");
	public override long LocationPopulation(long maxPop) => NumberBuilder.GetRandomNumber(2000, 10000);
	public override long LocationPopulationSecondary(long maxPop) => NumberBuilder.GetRandomNumber(Math.Min(maxPop, 500000), Math.Min(maxPop, 5000000));
	public override string LocationPopulationString(long pop, long popSecondary) => NumberBuilder.GetNumberString(pop) + " tech priests, " + NumberBuilder.GetNumberString(popSecondary) + " indentured laborers";
}

public class CathedralGenerator : LocationGenerator
{
	public override string LocationType => "Cathedral";
	public override string LocationName => NameBuilder.GetName("Cathedral");
	public override long LocationPopulation(long maxPop) => NumberBuilder.GetRandomNumber(10000, 20000);
	public override long LocationPopulationSecondary(long maxPop) => NumberBuilder.GetRandomNumber(500, 5000);
	public override string LocationPopulationString(long pop, long popSecondary) => NumberBuilder.GetNumberString(pop) + " ministronium priests, " + NumberBuilder.GetNumberString(popSecondary) + " sisters of battle";
}

public class MineGenerator : LocationGenerator
{
	public override string LocationType => "Mine";
	public override string LocationName => NameBuilder.GetName("Mine");
	public override long LocationPopulation(long maxPop) => NumberBuilder.GetRandomNumber(Math.Min(maxPop, 10000), Math.Min(maxPop, 1000000));
	public override string LocationPopulationString(long pop, long popSecondary) => NumberBuilder.GetNumberString(pop) + " indentured miners";
}

public class FarmGenerator : LocationGenerator
{
	public override string LocationType => NameBuilder.GetName("FarmType");
	public override string LocationName => NameBuilder.GetName("Farm");
	public override long LocationPopulation(long maxPop) => NumberBuilder.GetRandomNumber(Math.Min(maxPop, 100000), Math.Min(maxPop, 1000000));
	public override string LocationPopulationString(long pop, long popSecondary) => NumberBuilder.GetNumberString(pop) + " serfs";
}