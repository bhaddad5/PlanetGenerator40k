using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class PlanetAuthor : MonoBehaviour
{
	public PlanetVisualizer PlanetPrefab;
	private PlanetVisualizer currPlanet;

	public TMP_Dropdown BiomeDropdown;
	public TMP_InputField NameInputField;
	public TMP_InputField SizeInputField;
	public TMP_InputField RotSpeedInputField;

	private PlanetData currentPlanetData;

	public void GeneratePlanet()
	{
		if(currPlanet != null)
			GameObject.Destroy(currPlanet.gameObject);

		currentPlanetData = new PlanetData();
		currentPlanetData.Id = NameInputField.text;
		currentPlanetData.BiomeData = GetPlanet();

		float size = Single.Parse(SizeInputField.text);
		float rotSpeed = Single.Parse(RotSpeedInputField.text);

		currentPlanetData.GeoData = new PlanetGeoData(){RotationSpeed = rotSpeed, Size = size};

		currPlanet = GameObject.Instantiate(PlanetPrefab);
		currPlanet.Setup(currentPlanetData);
	}

	public void SavePlanet()
	{
		string newPath = Path.Combine(Application.streamingAssetsPath, Path.Combine("Planets", currentPlanetData.Id)) + ".txt";
		var file = File.Create(newPath);
		file.Close();
		string planetJson = JsonUtility.ToJson(currentPlanetData);
		File.WriteAllText(newPath, planetJson);
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

			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				var tmpObject = GameObject.Instantiate(TmpPlacementPrefab);
				tmpObject.transform.SetParent(currPlanet.transform.GetChild(0));
				tmpObject.transform.position = hit.point;
				tmpObject.transform.LookAt(currPlanet.transform.GetChild(0));
				tmpObject.transform.eulerAngles += new Vector3(-90, 0, 0);
			}
		}
	}

	private BiomeData GetPlanet()
	{
		string dropdownVal = BiomeDropdown.options[BiomeDropdown.value].text;
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
