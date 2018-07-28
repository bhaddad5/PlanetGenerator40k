using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Army
{
	public virtual string ArmyName => NameBuilder.GetName("GuardArmy");
	public virtual string LeaderName => NameBuilder.GetName("EmpireArmyLeader");
	public virtual string ArmyStrength => "";
	public virtual bool Hostile => false;
}

public class GuardArmy : Army
{
	public override string ArmyStrength => NumberBuilder.GetNumberString(10000, 1000000) + " guardsmen";
}

public class ScoutArmy : Army
{
	public override string ArmyStrength => NumberBuilder.GetNumberString(1000, 10000) + " guardsmen";
}

public class TankArmy : Army
{
	public override string ArmyStrength => NumberBuilder.GetNumberString(500, 10000) + " tanks";
}

public class FeudalArmy : Army
{
	public override string ArmyStrength => NumberBuilder.GetNumberString(10000, 100000) + " levies";
}

public class GangArmy : Army
{
	public override string ArmyStrength => NumberBuilder.GetNumberString(500, 10000) + " gangers";
	public override bool Hostile => true;
}

public class MechanicusArmy : Army
{
	public override string ArmyStrength => NumberBuilder.GetNumberString(1000, 10000) + " skitarii";
}

public class TitanArmy : Army
{
	public override string ArmyName => NameBuilder.GetName("TitanArmy");
	public override string ArmyStrength => NumberBuilder.GetNumberString(5, 50) + " titans";
}