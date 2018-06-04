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

	public GUIGamePlayView ConcreteGUIGamePlayView()
	{
		GUIGamePlayView guiGamePlayViewInstance = Instantiate(_GUIGamePlayViewPrefab);
		guiGamePlayViewInstance.Model = _GUIGamePlayModel;
		return guiGamePlayViewInstance;
	}

	public ISummaryView ConcreteGUISuccessSummaryView(GUIGamePlayView gamePlayView)
	{
		ISummaryView summaryViewInstance = Instantiate(_GUISuccessSummaryViewPrefab);
		_GUISuccessSummaryModel.SetGUISuccessSummaryModel(gamePlayView.Model);
		((GUISuccessSummaryView)summaryViewInstance).Model = _GUISuccessSummaryModel;
		return summaryViewInstance;
	}

	public ISummaryView ConcreteGUIFailureSummaryView(GUIGamePlayView gamePlayView)
	{
		ISummaryView summaryViewInstance = Instantiate(_GUIFailureSummaryViewPrefab);
		_GUIFailureSummaryModel.SetGUIFailureSummaryModel(gamePlayView.Model);
		((GUIFailureSummaryView)summaryViewInstance).Model = _GUIFailureSummaryModel;
		return summaryViewInstance;
	}
}
