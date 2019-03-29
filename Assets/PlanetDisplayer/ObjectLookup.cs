using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookup : MonoBehaviour
{
	[Header("Environmental Doodads")]
	public List<GameObject> PineForests;

	[Header("District Levels")]
	public List<GameObject> HiveCity0;
	public List<GameObject> Refinery0;

	public GameObject GetByIdAndLevel(string id, int lvl)
	{
		if (id == "PineForest")
			return PineForests.GetRandom();

		if (id == "HiveCity" && lvl == 0)
			return HiveCity0.GetRandom();
		if (id == "Refinery" && lvl == 0)
			return Refinery0.GetRandom();

		return null;
	}
}
