using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	public Clicker PlayerClicker { get; private set; }
	public InputManager PlayerInput { get; private set; }
	

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

		if (PlayerInput == null)
		{
			Debug.LogError("Needs an InputManager attached to GameManager");
		}
	}

	public void InitializePlayer(Clicker player)
	{
		PlayerClicker = player;

		PlayerInput.InitializeControls();
	}
}
