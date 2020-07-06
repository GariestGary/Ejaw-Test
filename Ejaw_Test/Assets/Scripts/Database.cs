using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System;

public class Database : MonoBehaviour
{
	public static Database Instance { get; private set; }
	public int ObjectNamesCount => _objectNames.Count;

	private List<string> _objectNames = new List<string>();


    private JArray data;

	private void Awake()
	{
		if(Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		ConstructDatabase();
	}

	private void ConstructDatabase()
	{
		data = JsonConvert.DeserializeObject<JArray>(Resources.Load<TextAsset>("objects").text);

		for (int i = 0; i < data.Count; i++)
		{
			_objectNames.Add(data[i]["Name"].ToString());
		}
	}

	public string FetchObjectNameById(int id)
	{
		if (id >= 0 && id < _objectNames.Count)
		{
			return _objectNames[id];
		}
		else
		{
			return null;
		}
	}
}
