using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	[SerializeField] private Controls _controls = null;

	public Vector2 PointerPosition { get; private set; }

	public void InitializeControls()
	{
		_controls.Player.Position.performed += ctx => PointerPosition = ctx.ReadValue<Vector2>();
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
