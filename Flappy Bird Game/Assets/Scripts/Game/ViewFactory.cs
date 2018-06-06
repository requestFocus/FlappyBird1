using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewFactory : MonoBehaviour //Singleton<ViewFactory>
{
	[Inject]
	private GUIGamePlayView _GUIGamePlayView;
	[Inject]
	private GUIGamePlayModel _GUIGamePlayModel;

	[Inject]
	private GUISuccessSummaryView _GUISuccessSummaryView;
	[Inject]
	private GUISuccessSummaryModel _GUISuccessSummaryModel;

	[Inject]
	private GUIFailureSummaryView _GUIFailureSummaryView;
	[Inject]
	private GUIFailureSummaryModel _GUIFailureSummaryModel;

	public GUIGamePlayView ConcreteGUIGamePlayView()
	{
		_GUIGamePlayView.gameObject.SetActive(true);
		_GUIGamePlayView.Model = _GUIGamePlayModel;
		return _GUIGamePlayView;
	}

	public GUISuccessSummaryView ConcreteGUISuccessSummaryView()
	{
		_GUIGamePlayView.gameObject.SetActive(false);
		_GUISuccessSummaryView.gameObject.SetActive(true);
		//_GUISuccessSummaryModel.SetGUISuccessSummaryModel(gamePlayView.Model);
		_GUISuccessSummaryView.Model = _GUISuccessSummaryModel;
		return _GUISuccessSummaryView;
	}

	public GUIFailureSummaryView ConcreteGUIFailureSummaryView()
	{
		_GUIGamePlayView.gameObject.SetActive(false);
		_GUIFailureSummaryView.gameObject.SetActive(true);
		//_GUIFailureSummaryModel.SetGUIFailureSummaryModel(gamePlayView.Model);
		_GUIFailureSummaryView.Model = _GUIFailureSummaryModel;
		return _GUIFailureSummaryView;
	}
}
