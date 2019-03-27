using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class PlanetAuthor : MonoBehaviour
{
	public PlanetInfoDisplayer PlanetDisplayer;

	public TMP_Dropdown Dropdown;
	public TMP_InputField NameInputField;

	private BiomeData currentBiomeData;

	public void GeneratePlanet()
	{
		currentBiomeData = GetPlanet();
		PlanetDisplayer.DisplayPlanet(currentBiomeData);
	}

	public void SavePlanet()
	{
		string newPath = Path.Combine(Application.streamingAssetsPath, Path.Combine("Planets", NameInputField.text)) + ".txt";
		var file = File.Create(newPath);
		file.Close();
		string biomeJson = JsonUtility.ToJson(currentBiomeData);
		File.WriteAllText(newPath, biomeJson);
	}

	public GameObject Cursor;
	public Camera MainCamera;


	public GameObject TmpPlacementPrefab;
	public void Update()
	{
		var ray = MainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			Cursor.transform.position = hit.point;
		}
	}

	private BiomeData GetPlanet()
	{
		string dropdownVal = Dropdown.options[Dropdown.value].text;
		BiomeGenerator biomeGen = new Continental();
		if (dropdownVal == "Continental")
			biomeGen = new Continental();
		if (dropdownVal == "Arid")
			biomeGen = new Arid();
		if (dropdownVal == "Jungle")
			biomeGen = new Jungle();
		if (dropdownVal == "Desert")
			biomeGen = new Desert();
		if (dropdownVal == "Arctic")
			biomeGen = new Arctic();
		if (dropdownVal == "Alpine")
			biomeGen = new Alpine();
		if (dropdownVal == "Dead")
			biomeGen = new Dead();
		if (dropdownVal == "Molten")
			biomeGen = new Molten();

		return biomeGen.GenerateBiome();
	}
	
}
