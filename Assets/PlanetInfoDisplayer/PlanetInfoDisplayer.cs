using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetInfoDisplayer : MonoBehaviour
{
	public ArmyInfoDisplayer ArmyInfoDisplayPrefab;
	public Transform ArmyDisplayParent;

	public TMP_Text PlanetName;
	public TMP_Text PlanetTypeName;
	public TMP_Text RulerName;

	public PlanetGenerator planetGen;

	public void DisplayPlanet(Planet planet)
	{
		PlanetName.text = planet.Name;
		PlanetTypeName.text = planet.PlanetTypeName;
		RulerName.text = planet.Ruler;

		for (int i = 0; i < ArmyDisplayParent.childCount; i++)
		{
			Destroy(ArmyDisplayParent.GetChild(i));
		}

		foreach (Army army in planet.Defenses.PlanetaryArmies())
		{
			var armyDisplay = Instantiate(ArmyInfoDisplayPrefab);
			armyDisplay.transform.SetParent(ArmyDisplayParent);
			armyDisplay.DisplayArmy(army);
		}
	}
}
