using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlanetDefenseForce
{
	public virtual int NumArmies => 2;

	protected virtual List<Army> ArmyTypes => new List<Army>()
	{
		new GuardArmy(),
	};

	public List<Army> PlanetaryArmies()
	{
		List<Army> armies = new List<Army>();
		for (int i = 0; i < NumArmies; i++)
		{
			armies.Add(ArmyTypes[Random.Range(0, ArmyTypes.Count)]);
		}
		return armies;
	}
}

public class CivilizedWorldDefenseForce : PlanetDefenseForce
{
	public override int NumArmies => 2;

	protected override List<Army> ArmyTypes => new List<Army>()
	{
		new GuardArmy(),
	};
}

public class HiveWorldDefenseForce : PlanetDefenseForce
{
	public override int NumArmies => 4;

	protected override List<Army> ArmyTypes => new List<Army>()
	{
		new GuardArmy(),
		new GangArmy(),
		new TankArmy(),
	};
}

public class ForgeWorldDefenseForce : PlanetDefenseForce
{
	public override int NumArmies => 3;

	protected override List<Army> ArmyTypes => new List<Army>()
	{
		new TitanArmy(),
		new MechanicusArmy(),
		new TankArmy(),
	};
}

public class FeudalWorldDefenseForce : PlanetDefenseForce
{
	public override int NumArmies => 3;

	protected override List<Army> ArmyTypes => new List<Army>()
	{
		new FeudalArmy(),
	};
}