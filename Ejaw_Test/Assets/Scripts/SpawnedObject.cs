using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SpawnedObject : MonoBehaviour
{
	[SerializeField] private string _objectType = "";
    private Material _material = null;
	private Color _currentColor = Color.white;
	private int _clicksCount = 0;
	private IDisposable _colorSwitchObserver = null;

	private void Awake()
	{
		_material = GetComponent<MeshRenderer>().material;
		_material.color = _currentColor; //Initializing object with white color

		StartSwitchColors();
	}

	private void StartSwitchColors()
	{
		_colorSwitchObserver = Observable.Interval(new TimeSpan(0, 0, GameManager.Instance.Data.ObservableTimeSeconds)).Subscribe(_ =>
		{
			_currentColor = UnityEngine.Random.ColorHSV(0, 1, 0, 1, 0, 1);
			_material.color = _currentColor;
		});
	}

	public void Click()
	{
		_clicksCount++;

		for (int i = 0; i < GameManager.Instance.GeometryData.ClickData.Count; i++)
		{
			if (GameManager.Instance.GeometryData.ClickData[i].ObjectType == _objectType)
			{
				for (int j = 0; j < GameManager.Instance.GeometryData.ClickData[i].ClickColors.Count; j++)
				{
					if (_clicksCount >= GameManager.Instance.GeometryData.ClickData[i].ClickColors[j].MinClicksCount && _clicksCount <= GameManager.Instance.GeometryData.ClickData[i].ClickColors[j].MaxClicksCount)
					{
						_currentColor = GameManager.Instance.GeometryData.ClickData[i].ClickColors[j].Color;
						_material.color = _currentColor;
						return;
					}
				}
			}
		}
	}

	private void OnDestroy()
	{
		_colorSwitchObserver.Dispose();
	}
}
