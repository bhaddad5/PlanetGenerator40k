using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetInfoDisplayer : MonoBehaviour
{
	public ArmyInfoDisplayer ArmyInfoDisplayPrefab;
	public Transform ArmyDisplayParent;
	public PlanetVisualDisplayController PlanetVisualizer;

	public TMP_Text PlanetName;
	public TMP_Text PlanetTypeName;
	public TMP_Text PlanetPopulation;
	public TMP_Text RulerName;

	public PlanetBuilder planetGen;

	public void DisplayPlanet(PlanetData planetData)
	{
		PlanetName.text = planetData.Name;
		PlanetTypeName.text = planetData.TypeName + " (" + planetData.BiomeData.Descriptor + ")";
		PlanetPopulation.text = "Population: " + planetData.PopulationString;
		RulerName.text = "Ruler: " + planetData.Ruler;

		foreach (Transform child in ArmyDisplayParent.transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		foreach (ArmyData army in planetData.DefensesData.Armies)
		{
			var armyDisplay = Instantiate(ArmyInfoDisplayPrefab);
			armyDisplay.transform.SetParent(ArmyDisplayParent);
			armyDisplay.DisplayArmy(army);
		}

		PlanetVisualizer.SetupBiome(planetData.BiomeData);
	}
}
