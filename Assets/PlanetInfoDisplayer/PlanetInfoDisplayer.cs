using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetInfoDisplayer : MonoBehaviour
{
	public TMP_Text PlanetName;
	public TMP_Text PlanetTypeName;
	public TMP_Text RulerName;

	public PlanetGenerator planetGen;

	public void DisplayPlanet(Planet planet)
	{
		PlanetName.text = planet.Name;
		PlanetTypeName.text = planet.PlanetTypeName;
		RulerName.text = planet.Ruler;
	}
}
