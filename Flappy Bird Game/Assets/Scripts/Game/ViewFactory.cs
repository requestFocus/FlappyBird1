using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewFactory : MonoBehaviour 
{
	[Inject]
	private GUIGamePlayView _GUIGamePlayViewPrefab;

	[Inject]
	private GUISuccessSummaryView _GUISuccessSummaryViewPrefab;

	[Inject]
	private GUIFailureSummaryView _GUIFailureSummaryViewPrefab;

	[Inject]
	private CurrentPlayerData _currentPlayerData;

	[Inject]
	private DiContainer container;

	public GUIGamePlayView ConcreteGUIGamePlayView()
	{
		GUIGamePlayView guiGamePlayViewInstance = Instantiate(_GUIGamePlayViewPrefab);
		container.Inject(guiGamePlayViewInstance);
		return guiGamePlayViewInstance;
	}

	public GUISuccessSummaryView ConcreteGUISuccessSummaryView(GUIGamePlayView gamePlayView)
	{
		GUISuccessSummaryView guiSuccessSummaryViewInstance = Instantiate(_GUISuccessSummaryViewPrefab);
		container.Inject(guiSuccessSummaryViewInstance);
		return guiSuccessSummaryViewInstance;
	}

	public GUIFailureSummaryView ConcreteGUIFailureSummaryView(GUIGamePlayView gamePlayView)
	{
		GUIFailureSummaryView guiFailureSummaryViewInstance = Instantiate(_GUIFailureSummaryViewPrefab);
		container.Inject(guiFailureSummaryViewInstance);
		return guiFailureSummaryViewInstance;
	}
}
