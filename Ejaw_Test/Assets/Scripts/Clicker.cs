using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
	private void Awake()
	{
		GameManager.Instance.InitializePlayer(this);
	}

	public void SpawnObject()
	{
		Ray ray = Camera.main.ScreenPointToRay(GameManager.Instance.PlayerInput.PointerPosition);

		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			//TODO: prefab names from json
			SpawnedObject spawnedobj = hit.transform.GetComponent<SpawnedObject>();

			if (spawnedobj == null)
			{
				GameObject obj = Resources.Load<GameObject>("Prefabs/Cube");
				Instantiate(obj, hit.point, Quaternion.identity);
			}
			else
			{
				
			}
		}
	}

}
