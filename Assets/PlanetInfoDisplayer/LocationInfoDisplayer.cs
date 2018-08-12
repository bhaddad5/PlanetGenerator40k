using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocationInfoDisplayer : MonoBehaviour
{
	public Vector2 Size;
	public TMP_Text LocationName;
	public TMP_Text LocationPopulation;

	public void DisplayLocationInfo(LocationData location)
	{
		LocationName.text = location.LocationName + " (" + location.LocationType + ")";
		LocationPopulation.text = location.LocationPopulationString;
	}
}
