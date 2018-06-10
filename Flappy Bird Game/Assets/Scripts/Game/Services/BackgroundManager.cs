using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BackgroundManager : MonoBehaviour
{
	[SerializeField] private BackgroundGameView _backgroundGameViewPrefab;

	private void Start()
	{
		Instantiate(_backgroundGameViewPrefab);
	}
}
