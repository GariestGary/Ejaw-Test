using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class InputManager : MonoBehaviour
{
	[SerializeField] private Controls _controls = null;

	public Vector2 PointerPosition { get; private set; }

	private void Awake()
	{
		_controls.Player.Position.performed += ctx => PointerPosition = ctx.ReadValue<Vector2>();
	}

	public void InitializeControls()
	{
		_controls.Player.Click.performed += _ => GameManager.Instance.PlayerClicker.Click();
	}

	private void OnEnable()
	{
		_controls.Enable();
	}

	private void OnDisable()
	{
		_controls.Disable();
	}
}
