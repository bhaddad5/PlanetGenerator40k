using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetInfoDisplayer : MonoBehaviour
{
	public LocationInfoDisplayer LocationInfoDisplayer;
	public RectTransform LocationDisplayParent;
	public ArmyInfoDisplayer ArmyInfoDisplayPrefab;
	public RectTransform ArmyDisplayParent;
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

		PlanetVisualizer.SetupBiome(planetData.BiomeData);

		foreach (Transform child in LocationDisplayParent.transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		foreach (LocationData location in planetData.LocationsData.Locations)
		{
			var locationDisplay = Instantiate(LocationInfoDisplayer);
			locationDisplay.transform.SetParent(LocationDisplayParent);
			locationDisplay.DisplayLocationInfo(location);
		}

		LocationDisplayParent.sizeDelta = new Vector2(LocationInfoDisplayer.Size.x, (LocationInfoDisplayer.Size.y + LocationDisplayParent.GetComponent<VerticalLayoutGroup>().spacing) * planetData.LocationsData.Locations.Count);

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

		ArmyDisplayParent.sizeDelta = new Vector2(ArmyInfoDisplayPrefab.Size.x, (ArmyInfoDisplayPrefab.Size.y + LocationDisplayParent.GetComponent<VerticalLayoutGroup>().spacing) * planetData.DefensesData.Armies.Count);
	}
}
