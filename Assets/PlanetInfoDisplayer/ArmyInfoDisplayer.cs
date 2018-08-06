using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArmyInfoDisplayer : MonoBehaviour
{
	public TMP_Text ArmyName;
	public TMP_Text ArmyStrength;

	public void DisplayArmy(Army army)
	{
		ArmyName.text = army.ArmyName + " (" + army.ArmyType + ")";
		ArmyStrength.text = army.ArmyStrength;

		if (army.Hostile)
		{
			ArmyName.color = Color.red;
			ArmyStrength.color = Color.red;
		}
	}
}
