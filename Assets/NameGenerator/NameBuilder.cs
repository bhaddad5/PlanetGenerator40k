using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NameBuilder
{
	private static Dictionary<string, List<string>> nameTables = new Dictionary<string, List<string>>();

	public static string GetName(string tableName)
	{
		if (!nameTables.ContainsKey(tableName))
			throw new Exception("Could not find table: " + tableName);

		var table = nameTables[tableName];
		string foundTableEntry = table[UnityEngine.Random.Range(0, table.Count)];

		var split = foundTableEntry.Split(new []{'{', '}'});

		string result = "";
		for (int i = 0; i < split.Length; i++)
		{
			if (i % 2 == 1)
				result += GetName(split[i]);
			else result += split[i];
		}

		return result;
	}

	public static void AddTable(NameTable nameTable)
	{
		nameTables[nameTable.TableName] = nameTable.GetNameOptions();
	}
}
