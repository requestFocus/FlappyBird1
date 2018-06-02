using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewFactory : Singleton<ViewFactory>
{
	[Inject]
	private GUIGamePlayView _guiGamePlayViewPrefab;
	[Inject]
	private GUIGamePlayModel _guiGamePlayModel;

	[Inject]
	private GUISuccessSummaryView _guiSuccessSummaryViewPrefab;
	[Inject]
	private GUISuccessSummaryModel _guiSuccessSummaryModel;

	[Inject]
	private GUIFailureSummaryView _guiFailureSummaryViewPrefab;
	[Inject]
	private GUIFailureSummaryModel _guiFailureSummaryModel;

	public GUIGamePlayView ConcreteGUIGamePlayView()
	{
		GUIGamePlayView guiGamePlayViewInstance = Instantiate(_guiGamePlayViewPrefab);
		guiGamePlayViewInstance.Model = _guiGamePlayModel;
		return guiGamePlayViewInstance;
	}

	public ISummaryView ConcreteGUISuccessSummaryView(GUIGamePlayView gamePlayView)
	{
		ISummaryView summaryViewInstance = Instantiate(_guiSuccessSummaryViewPrefab);
		_guiSuccessSummaryModel.SetGUISuccessSummaryModel(gamePlayView.Model);
		((GUISuccessSummaryView)summaryViewInstance).Model = _guiSuccessSummaryModel;
		return summaryViewInstance;
	}

	public ISummaryView ConcreteGUIFailureSummaryView(GUIGamePlayView gamePlayView)
	{
		ISummaryView summaryViewInstance = Instantiate(_guiFailureSummaryViewPrefab);
		_guiFailureSummaryModel.SetGUIFailureSummaryModel(gamePlayView.Model);
		((GUIFailureSummaryView)summaryViewInstance).Model = _guiFailureSummaryModel;
		return summaryViewInstance;
	}
}
