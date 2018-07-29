using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Army
{
	public virtual string ArmyType => "";
	public virtual string ArmyName => NameBuilder.GetName("GuardArmy");
	public virtual string LeaderName => NameBuilder.GetName("EmpireArmyLeader");
	public virtual string ArmyStrength => "";
	public virtual bool Hostile => false;
}

public class GuardArmy : Army
{
	public override string ArmyType => "Imperial Guard";
	public override string ArmyStrength => NumberBuilder.GetNumberString(10000, 1000000) + " guardsmen";
}

public class ScoutArmy : Army
{
	public override string ArmyType => "Imperial Guard";
	public override string ArmyStrength => NumberBuilder.GetNumberString(1000, 10000) + " guardsmen";
}

public class TankArmy : Army
{
	public override string ArmyType => "Imperial Guard";
	public override string ArmyStrength => NumberBuilder.GetNumberString(500, 10000) + " tanks";
}

public class FeudalArmy : Army
{
	public override string ArmyName => NameBuilder.GetName("FeudalArmy");
	public override string LeaderName => NameBuilder.GetName("FeudalPlanetRuler");
	public override string ArmyType => "Feudal Levies";
	public override string ArmyStrength => NumberBuilder.GetNumberString(10000, 100000) + " men-at-arms";
}

public class GangArmy : Army
{
	public override string ArmyName => NameBuilder.GetName("GangArmy");
	public override string ArmyType => "Gang";
	public override string ArmyStrength => NumberBuilder.GetNumberString(500, 10000) + " gangers";
	public override bool Hostile => true;
}

public class MechanicusArmy : Army
{
	public override string ArmyType => "Mechanicus Army";
	public override string ArmyStrength => NumberBuilder.GetNumberString(1000, 10000) + " skitarii";
}

public class TitanArmy : Army
{
	public override string ArmyType => "Titan Legion";
	public override string ArmyName => NameBuilder.GetName("TitanArmy");
	public override string ArmyStrength => NumberBuilder.GetNumberString(5, 50) + " titans";
}