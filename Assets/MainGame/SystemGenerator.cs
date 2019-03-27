using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.WSA;
using Application = UnityEngine.Application;

public class SystemGenerator : MonoBehaviour
{
	public PlanetVisualizer PlanetPrefab;

	public List<PlanetData> Planets = new List<PlanetData>();
	public List<PlanetData> Moons = new List<PlanetData>();
	
	// Use this for initialization
	void Start ()
	{
		foreach (string file in Directory.GetFiles(Path.Combine(Application.streamingAssetsPath, "Planets")))
		{
			if (file.EndsWith(".txt"))
			{
				string contents = File.ReadAllText(file);
				var parsedPlanet = JsonUtility.FromJson<PlanetData>(contents);
				if(parsedPlanet.Moon)
					Moons.Add(parsedPlanet);
				else
					Planets.Add(parsedPlanet);
			}
		}

		int numPlanets = Random.Range(3, 6);
		
		for (int i = 0; i < numPlanets; i++)
		{
			var planet = BuildSolarBody(Planets[Random.Range(0, Planets.Count)], Random.Range(4f, 12f), Vector3.zero);
			int numPlanetMoons = Random.Range(0, 3);
			for (int j = 0; j < numPlanetMoons; j++)
			{
				BuildSolarBody(Moons[Random.Range(0, Moons.Count)], Random.Range(2f, 3f), planet.transform.position);
			}
		}
	}

	private GameObject BuildSolarBody(PlanetData data, float distanceFromParent, Vector3 parentPos)
	{
		var newPlanet = GameObject.Instantiate(PlanetPrefab);
		newPlanet.Setup(data);
		newPlanet.transform.position = parentPos;
		newPlanet.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
		newPlanet.transform.position += newPlanet.transform.forward * distanceFromParent;

		return newPlanet.gameObject;
	}
}
