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
	private CurrentPlayerData _currentPlayerData;

	[Inject]
	private DiContainer container;

	//public delegate void InjectMethod(GUIGamePlayView instance);
	//public InjectMethod InjectMethodDel;

	public GUIGamePlayView ConcreteGUIGamePlayView()
	{
		GUIGamePlayView guiGamePlayViewInstance = Instantiate(_GUIGamePlayViewPrefab);
		container.Inject(guiGamePlayViewInstance);
		//InjectMethodDel(guiGamePlayViewInstance);
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
