using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewFactory : Singleton<ViewFactory>
{
	[SerializeField] private GUIGamePlayView GUIGamePlayViewPrefab;
	[SerializeField] private GUISuccessSummaryView GUISuccessSummaryViewPrefab;
	[SerializeField] private GUIFailureSummaryView GUIFailureSummaryViewPrefab;

	public GUIGamePlayView ConcreteGUIGamePlayView()
	{
		GUIGamePlayView GUIGamePlayViewInstance = Instantiate(GUIGamePlayViewPrefab);
		GUIGamePlayViewInstance.Model = new GUIGamePlayModel();
		return GUIGamePlayViewInstance;
	}

	public ISummaryView ConcreteGUISuccessSummaryView(GUIGamePlayView gamePlayView)
	{
		ISummaryView SummaryViewInstance = Instantiate(GUISuccessSummaryViewPrefab);
		((GUISuccessSummaryView)SummaryViewInstance).Model = new GUISuccessSummaryModel(gamePlayView.Model);
		return SummaryViewInstance;
	}

	public ISummaryView ConcreteGUIFailureSummaryView(GUIGamePlayView gamePlayView)
	{
		ISummaryView SummaryViewInstance = Instantiate(GUIFailureSummaryViewPrefab);
		((GUIFailureSummaryView)SummaryViewInstance).Model = new GUIFailureSummaryModel(gamePlayView.Model);
		return SummaryViewInstance;
	}
}
