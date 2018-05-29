using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewFactory : Singleton<ViewFactory>
{
	[Inject]
	private GUIGamePlayModel _guiGamePlayModel;
	[Inject]
	private GUIGamePlayView _guiGamePlayView;

	//[Inject]
	//private GUISuccessSummaryModel _guiSuccessSummaryModel;
	//[Inject]
	//private GUISuccessSummaryView _guiSuccessSummaryView;

	[SerializeField] private GUIGamePlayView GUIGamePlayViewPrefab;
	[SerializeField] private GUISuccessSummaryView GUISuccessSummaryViewPrefab;
	[SerializeField] private GUIFailureSummaryView GUIFailureSummaryViewPrefab;

	public GUIGamePlayView ConcreteGUIGamePlayView()
	{
		//GUIGamePlayView GUIGamePlayViewInstance = Instantiate(GUIGamePlayViewPrefab);
		//GUIGamePlayViewInstance.Model = new GUIGamePlayModel();
		//return GUIGamePlayViewInstance;

		_guiGamePlayView.Model = _guiGamePlayModel;						//======================== w jaki sposób sprawić, żeby te instancje były faktycznie LAZY?
		return _guiGamePlayView;
	}

	public ISummaryView ConcreteGUISuccessSummaryView(GUIGamePlayView gamePlayView)
	{
		ISummaryView SummaryViewInstance = Instantiate(GUISuccessSummaryViewPrefab);
		((GUISuccessSummaryView)SummaryViewInstance).Model = new GUISuccessSummaryModel(gamePlayView.Model);
		return SummaryViewInstance;

		//_guiSuccessSummaryView.Model = _guiSuccessSummaryModel;         //======================== w jaki sposób sprawić, żeby te instancje były faktycznie LAZY?
		//return _guiSuccessSummaryView;
	}

	public ISummaryView ConcreteGUIFailureSummaryView(GUIGamePlayView gamePlayView)
	{
		ISummaryView SummaryViewInstance = Instantiate(GUIFailureSummaryViewPrefab);
		((GUIFailureSummaryView)SummaryViewInstance).Model = new GUIFailureSummaryModel(gamePlayView.Model);
		return SummaryViewInstance;
	}
}
