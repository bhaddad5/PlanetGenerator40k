using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDefenseForceData
{
	public List<ArmyData> Armies = new List<ArmyData>();

	public PlanetDefenseForceData(PlanetDefenseForceGenerator defensesGen)
	{
		foreach (ArmyGenerator armyGen in defensesGen.PlanetaryArmies())
		{
			Armies.Add(new ArmyData(armyGen));
		}
	}
}

public abstract class PlanetDefenseForceGenerator
{
	public virtual int NumArmies => 1;

	protected virtual List<ArmyGenerator> ArmyTypes => new List<ArmyGenerator>()
	{
		new GuardArmyGenerator(),
	};

	public List<ArmyGenerator> PlanetaryArmies()
	{
		List<ArmyGenerator> armies = new List<ArmyGenerator>();
		for (int i = 0; i < NumArmies; i++)
		{
			armies.Add(ArmyTypes[Random.Range(0, ArmyTypes.Count)]);
		}
		return armies;
	}
}

public class AgriWorldDefenseForceGenerator : PlanetDefenseForceGenerator
{
	public override int NumArmies => 1;
}

public class CivilizedWorldDefenseForceGenerator : PlanetDefenseForceGenerator
{
	public override int NumArmies => 2;
}

public class HiveWorldDefenseForceGenerator : PlanetDefenseForceGenerator
{
	public override int NumArmies => 4;

	protected override List<ArmyGenerator> ArmyTypes => new List<ArmyGenerator>()
	{
		new GuardArmyGenerator(),
		new GangArmyGenerator(),
		new TankArmyGenerator(),
	};
}

public class ForgeWorldDefenseForceGenerator : PlanetDefenseForceGenerator
{
	public override int NumArmies => 3;

	protected override List<ArmyGenerator> ArmyTypes => new List<ArmyGenerator>()
	{
		new TitanArmyGenerator(),
		new TankArmyGenerator(),
	};
}

public class FeudalWorldDefenseForceGenerator : PlanetDefenseForceGenerator
{
	public override int NumArmies => 1;

	protected override List<ArmyGenerator> ArmyTypes => new List<ArmyGenerator>()
	{
		new FeudalArmyGenerator(),
	};
}