using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationData
{
	public string LocationType;
	public string LocationName;
	public long LocationPopulation;
	public string LocationPopulationString;

	public LocationData(LocationGenerator locGen)
	{
		LocationType = locGen.LocationType;
		LocationName = locGen.LocationName;
		LocationPopulation = locGen.LocationPopulation;

		LocationPopulationString = locGen.LocationPopulationString(LocationPopulation);
	}
}

public abstract class LocationGenerator
{
	public virtual string LocationType => "";
	public virtual string LocationName => NameBuilder.GetName("GuardArmy");
	public virtual long LocationPopulation => 0;
	public virtual string LocationPopulationString(long pop) => "";
}

public class HiveCityGenerator : LocationGenerator
{
	public override string LocationType => "Hive City";
	public override string LocationName => NameBuilder.GetName("HiveCity");
	public override long LocationPopulation => NumberBuilder.GetRandomNumber(10000, 1000000);
	public override string LocationPopulationString(long pop) => NumberBuilder.GetNumberString(pop);
}
