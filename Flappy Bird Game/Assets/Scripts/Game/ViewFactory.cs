using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFactory : MonoBehaviour
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
		ISummaryView SummaryView = Instantiate(GUISuccessSummaryViewPrefab);
		((GUISuccessSummaryView)SummaryView).Model = new GUISuccessSummaryModel(gamePlayView.Model);
		return SummaryView;
	}

	public ISummaryView ConcreteGUIFailureSummaryView(GUIGamePlayView gamePlayView)
	{
		ISummaryView SummaryView = Instantiate(GUIFailureSummaryViewPrefab);
		((GUIFailureSummaryView)SummaryView).Model = new GUIFailureSummaryModel(gamePlayView.Model);
		return SummaryView;
	}
}
