using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AssetLookup : MonoBehaviour
{
	public static AssetLookup Instance;

	public MaterialLookup MaterialLookup;
	public ObjectLookup ObjectLookup;

	void Awake()
	{
		Instance = this;
	}
}