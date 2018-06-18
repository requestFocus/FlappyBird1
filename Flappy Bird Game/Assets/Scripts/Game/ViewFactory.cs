using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewFactory : MonoBehaviour 
{
	[Inject]
	private GUIGamePlayView _guiGamePlayViewPrefab;

	[Inject]
	private GUISuccessSummaryView _guiSuccessSummaryViewPrefab;

	[Inject]
	private GUIFailureSummaryView _guiFailureSummaryViewPrefab;

	[Inject]
	private CurrentPlayerData _currentPlayerData;

	[Inject]
	private DiContainer container;

	public GUIGamePlayView ConcreteGUIGamePlayView()
	{
		GUIGamePlayView guiGamePlayViewInstance = Instantiate(_guiGamePlayViewPrefab);
		container.Inject(guiGamePlayViewInstance);
		return guiGamePlayViewInstance;
	}

	public GUISuccessSummaryView ConcreteGUISuccessSummaryView(GUIGamePlayView gamePlayView)
	{
		GUISuccessSummaryView guiSuccessSummaryViewInstance = Instantiate(_guiSuccessSummaryViewPrefab);
		container.Inject(guiSuccessSummaryViewInstance);
		return guiSuccessSummaryViewInstance;
	}

	public GUIFailureSummaryView ConcreteGUIFailureSummaryView(GUIGamePlayView gamePlayView)
	{
		GUIFailureSummaryView guiFailureSummaryViewInstance = Instantiate(_guiFailureSummaryViewPrefab);
		container.Inject(guiFailureSummaryViewInstance);
		return guiFailureSummaryViewInstance;
	}
}
