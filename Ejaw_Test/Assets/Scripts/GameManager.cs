using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	public Clicker PlayerClicker { get; private set; }
	public InputManager PlayerInput { get; private set; }
	public GameData Data { get; private set; }
	public GeometryObjectData GeometryData { get; private set; }
	

	void Awake()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		PlayerInput = GetComponent<InputManager>();

		Data = Resources.Load<GameData>("ScriptableObjects/Game Data");
		GeometryData = Resources.Load<GeometryObjectData>("ScriptableObjects/Geometry Data");
	}

	public void InitializePlayer(Clicker player)
	{
		PlayerClicker = player;

		PlayerInput.InitializeControls();
	}
}
