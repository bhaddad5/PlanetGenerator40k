using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSpawner : MonoBehaviour
{
	public List<NameTable> Tables = new List<NameTable>();

	void Awake()
	{
		foreach (NameTable table in Tables)
		{
			var go = Instantiate(table.gameObject);

			foreach (NameTable nameTable in go.GetComponentsInChildren<NameTable>(true))
			{
				NameBuilder.AddTable(nameTable);
			}
		}

		NameBuilder.ValidateNameReferences();
	}
}
