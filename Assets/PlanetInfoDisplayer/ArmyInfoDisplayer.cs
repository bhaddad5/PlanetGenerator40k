using TMPro;
using UnityEngine;

public class ArmyInfoDisplayer : MonoBehaviour
{
	public TMP_Text ArmyName;
	public TMP_Text ArmyStrength;

	public void DisplayArmy(ArmyData armyData)
	{
		ArmyName.text = armyData.ArmyName + " (" + armyData.ArmyType + ")";
		ArmyStrength.text = armyData.ArmyStrengthString;

		if (armyData.HostileArmy)
		{
			ArmyName.color = Color.red;
			ArmyStrength.color = Color.red;
		}
	}
}
