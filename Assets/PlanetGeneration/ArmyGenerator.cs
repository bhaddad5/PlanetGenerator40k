using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyData
{
	public string ArmyType;
	public string ArmyName;
	public long ArmyStrength;
	public string ArmyStrengthString;
	public bool HostileArmy;

	public ArmyData(ArmyGenerator armyGen)
	{
		ArmyName = armyGen.ArmyName;
		ArmyType = armyGen.ArmyType;
		ArmyStrength = armyGen.ArmyStrength;
		HostileArmy = armyGen.Hostile;

		ArmyStrengthString = armyGen.ArmyStrengthString(ArmyStrength);
	}
}

public abstract class ArmyGenerator
{
	public virtual string ArmyType => "";
	public virtual string ArmyName => NameBuilder.GetName("GuardArmy");
	public virtual long ArmyStrength => 0;
	public virtual string ArmyStrengthString(long strength) => "";
	public virtual bool Hostile => false;
}

public class GuardArmyGenerator : ArmyGenerator
{
	public override string ArmyName => NameBuilder.GetName("GuardArmy");
	public override string ArmyType => "Imperial Guard";
	public override long ArmyStrength => NumberBuilder.GetRandomNumber(10000, 1000000);
	public override string ArmyStrengthString(long strength) => NumberBuilder.GetNumberString(strength) + " guardsmen";
}

public class ScoutArmyGenerator : ArmyGenerator
{
	public override string ArmyName => NameBuilder.GetName("ScoutArmy");
	public override string ArmyType => "Light Infantry";
	public override long ArmyStrength => NumberBuilder.GetRandomNumber(1000, 10000);
	public override string ArmyStrengthString(long strength) => NumberBuilder.GetNumberString(strength) + " guardsmen";
}

public class TankArmyGenerator : ArmyGenerator
{
	public override string ArmyName => NameBuilder.GetName("MechanizedArmy");
	public override string ArmyType => "Armored Corps";
	public override long ArmyStrength => NumberBuilder.GetRandomNumber(500, 10000);
	public override string ArmyStrengthString(long strength) => NumberBuilder.GetNumberString(strength) + " tanks";
}

public class FeudalArmyGenerator : ArmyGenerator
{
	public override string ArmyName => NameBuilder.GetName("FeudalArmy");
	public override string ArmyType => "Feudal Levies";
	public override long ArmyStrength => NumberBuilder.GetRandomNumber(10000, 100000);
	public override string ArmyStrengthString(long strength) => NumberBuilder.GetNumberString(strength) + " men-at-arms";
}

public class GangArmyGenerator : ArmyGenerator
{
	public override string ArmyName => NameBuilder.GetName("GangArmy");
	public override string ArmyType => "Gang";
	public override long ArmyStrength => NumberBuilder.GetRandomNumber(500, 10000);
	public override string ArmyStrengthString(long strength) => NumberBuilder.GetNumberString(strength) + " gangers";
	public override bool Hostile => true;
}

public class TitanArmyGenerator : ArmyGenerator
{
	public override string ArmyType => "Titan Legion";
	public override string ArmyName => NameBuilder.GetName("TitanArmy");
	public override long ArmyStrength => NumberBuilder.GetRandomNumber(5, 50);
	public override string ArmyStrengthString(long strength) => NumberBuilder.GetNumberString(strength) + " titans";
}