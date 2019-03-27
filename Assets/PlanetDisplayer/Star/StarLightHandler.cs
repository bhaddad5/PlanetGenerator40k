using UnityEngine;

public class StarLightHandler : MonoBehaviour
{
	// Use this for initialization
	void Awake ()
	{
		Color c = GetComponentInChildren<MeshRenderer>().material.color;
		GetComponentInChildren<Light>().color = c;
		RenderSettings.ambientSkyColor = c * .5f;
	}
}
