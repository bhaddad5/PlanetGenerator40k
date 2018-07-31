using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMaterialLookup : MonoBehaviour
{
	[SerializeField] private Material Arid;
	[SerializeField] private Material Arctic;
	[SerializeField] private Material Continental;
	[SerializeField] private Material Desert;
	[SerializeField] private Material Dead;
	[SerializeField] private Material Jungle;
	[SerializeField] private Material Molten;

	public Material GetBiomeMaterial(Biome biome)
	{
		if (biome is Arid)
			return Arid;
		if (biome is Jungle)
			return Jungle;
		if (biome is Arctic)
			return Arctic;
		if (biome is Desert)
			return Desert;
		if (biome is Dead)
			return Dead;
		if (biome is Continental)
			return Continental;
		if (biome is Molten)
			return Molten;

		return Continental;
	}
}
