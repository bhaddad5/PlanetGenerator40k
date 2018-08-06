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

	public PlanetGenerator planetGen;

	public void DisplayPlanet(Planet planet)
	{
		var biome = planet.PlanetBiome.GetPlanetBiome();
		PlanetName.text = planet.GetName + " (" + biome.Descriptor + ")";
		PlanetTypeName.text = planet.GetPlanetTypeName;
		PlanetPopulation.text = "Population: " + planet.Population;
		RulerName.text = "Ruler: " + planet.GetRuler;

		foreach (Transform child in ArmyDisplayParent.transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		foreach (Army army in planet.GetDefenses.PlanetaryArmies())
		{
			var armyDisplay = Instantiate(ArmyInfoDisplayPrefab);
			armyDisplay.transform.SetParent(ArmyDisplayParent);
			armyDisplay.DisplayArmy(army);
		}

		PlanetVisualizer.SetupBiome(biome);
	}
}
