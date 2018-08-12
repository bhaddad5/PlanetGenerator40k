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

	public LocationData(LocationGenerator locGen)
	{
		LocationType = locGen.LocationType;
		LocationName = locGen.LocationName;
		LocationPopulationPrimary = locGen.LocationPopulation;
		LocationPopulationSecondary = locGen.LocationPopulationSecondary;

		LocationPopulationString = locGen.LocationPopulationString(LocationPopulationPrimary, LocationPopulationSecondary);
	}
}

public abstract class LocationGenerator
{
	public virtual string LocationType => "";
	public virtual string LocationName => NameBuilder.GetName("HiveCity");
	public virtual long LocationPopulation => 0;
	public virtual long LocationPopulationSecondary => 0;
	public virtual string LocationPopulationString(long pop, long popSecondary) => "";
}

public class HiveCityGenerator : LocationGenerator
{
	public override string LocationType => "Hive City";
	public override string LocationName => NameBuilder.GetName("HiveCity");
	public override long LocationPopulation => NumberBuilder.GetRandomNumber(10000000, 1000000000);
	public override string LocationPopulationString(long pop, long popSecondary) => NumberBuilder.GetNumberString(pop) + " hivers";
}

public class FeudalCastleGenerator : LocationGenerator
{
	public override string LocationType => "Castle";
	public override string LocationName => NameBuilder.GetName("FeudalCastle");
	public override long LocationPopulation => NumberBuilder.GetRandomNumber(20, 200);
	public override long LocationPopulationSecondary => NumberBuilder.GetRandomNumber(10000, 500000);
	public override string LocationPopulationString(long pop, long popSecondary) => NumberBuilder.GetNumberString(pop) + " nobles, " + NumberBuilder.GetNumberString(popSecondary) + " serfs";
}

public class ManufactorumGenerator : LocationGenerator
{
	public override string LocationType => "Manufactorum";
	public override string LocationName => NameBuilder.GetName("Factory");
	public override long LocationPopulation => NumberBuilder.GetRandomNumber(2000, 10000);
	public override long LocationPopulationSecondary => NumberBuilder.GetRandomNumber(500000, 5000000);
	public override string LocationPopulationString(long pop, long popSecondary) => NumberBuilder.GetNumberString(pop) + " tech priests, " + NumberBuilder.GetNumberString(popSecondary) + " indentured lavorers";
}

public class CathedralGenerator : LocationGenerator
{
	public override string LocationType => "Cathedral";
	public override string LocationName => NameBuilder.GetName("Cathedral");
	public override long LocationPopulation => NumberBuilder.GetRandomNumber(10000, 20000);
	public override long LocationPopulationSecondary => NumberBuilder.GetRandomNumber(500, 5000);
	public override string LocationPopulationString(long pop, long popSecondary) => NumberBuilder.GetNumberString(pop) + " ministronium priests, " + NumberBuilder.GetNumberString(popSecondary) + " sisters of battle";
}

public class MineGenerator : LocationGenerator
{
	public override string LocationType => "Mine";
	public override string LocationName => NameBuilder.GetName("Mine");
	public override long LocationPopulation => NumberBuilder.GetRandomNumber(10000, 1000000);
	public override string LocationPopulationString(long pop, long popSecondary) => NumberBuilder.GetNumberString(pop) + " indentured miners";
}