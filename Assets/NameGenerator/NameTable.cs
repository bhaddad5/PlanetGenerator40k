using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NameTable : MonoBehaviour
{
	public string TableName = "";
	[TextArea(5, 80)]
	public string Names;

	public List<string> GetNameOptions()
	{
		return Names.Replace("\n", "").Split(',').ToList();
	}
}