using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
	private void Awake()
	{
		GameManager.Instance.InitializePlayer(this);
	}

	public void Click()
	{
		Ray ray = Camera.main.ScreenPointToRay(GameManager.Instance.PlayerInput.PointerPosition);

		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			SpawnedObject spawnedobj = hit.transform.GetComponent<SpawnedObject>();

			if (spawnedobj == null)
			{
				Spawn(hit.point, Quaternion.identity);
			}
			else
			{
				ClickOnObject(spawnedobj);
			}
		}
	}

	private void Spawn(Vector3 position, Quaternion rotation)
	{
			GameObject obj = Resources.Load<GameObject>("Prefabs/" + Database.Instance.FetchObjectNameById(Random.Range(0, Database.Instance.ObjectNamesCount)));
			Instantiate(obj, position, rotation);
	}

	private void ClickOnObject(SpawnedObject obj)
	{
		obj.Click();
	}

}
