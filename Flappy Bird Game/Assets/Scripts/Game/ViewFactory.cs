using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewFactory : MonoBehaviour //Singleton<ViewFactory>
{
	[Inject]
	private GUIGamePlayView _GUIGamePlayViewPrefab;
	[Inject]
	private GUIGamePlayModel _GUIGamePlayModel;

	[Inject]
	private GUISuccessSummaryView _GUISuccessSummaryViewPrefab;
	[Inject]
	private GUISuccessSummaryModel _GUISuccessSummaryModel;

	[Inject]
	private GUIFailureSummaryView _GUIFailureSummaryViewPrefab;
	[Inject]
	private GUIFailureSummaryModel _GUIFailureSummaryModel;

	[Inject]
	private DiContainer _container;

	public void ConcreteGUIGamePlayView()
	{
		GUIGamePlayView guiGamePlayViewInstance = Instantiate(_GUIGamePlayViewPrefab);
		_container.Inject(guiGamePlayViewInstance);
	}

	public void ConcreteGUISuccessSummaryView()
	{ 
		GUISuccessSummaryView guiSuccessSummaryViewInstance = Instantiate(_GUISuccessSummaryViewPrefab);
		_container.Inject(guiSuccessSummaryViewInstance);
	}

	public void ConcreteGUIFailureSummaryView()
	{
		GUIFailureSummaryView guiFailureSummaryViewInstance = Instantiate(_GUIFailureSummaryViewPrefab);
		_container.Inject(guiFailureSummaryViewInstance);
	}
}
