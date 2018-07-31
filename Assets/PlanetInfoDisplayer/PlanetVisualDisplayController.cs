using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetVisualDisplayController : MonoBehaviour
{
	[SerializeField] private PlanetMaterialLookup MatLookup;

	public void SetupBiome(Biome biome)
	{
		var mat = MatLookup.GetBiomeMaterial(biome);
		GetComponent<MeshRenderer>().material = mat;
	}
}
