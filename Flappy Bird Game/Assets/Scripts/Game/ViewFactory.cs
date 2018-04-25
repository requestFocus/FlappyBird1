using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFactory : MonoBehaviour
{
	[SerializeField] private GUIGamePlayView GUIGamePlayViewPrefab;
	[SerializeField] private GUIGamePlayView GUIGamePlayViewInstance;
	[SerializeField] private GUISuccessSummaryView GUISuccessSummaryViewPrefab;
	[SerializeField] private GUISuccessSummaryView GUISuccessSummaryViewInstance;

	[SerializeField] private GUIFailureSummaryView GUIFailureSummaryViewPrefab;
	[SerializeField] private GUIFailureSummaryView GUIFailureSummaryViewInstance;

	private ISummaryView _summaryView;

	public void ConcreteGUIGamePlayView()
	{
		GUIGamePlayViewInstance = Instantiate(GUIGamePlayViewPrefab);
		GUIGamePlayViewInstance.transform.SetParent(FindObjectOfType<GUIMain>().transform);
		GUIGamePlayViewInstance.Model = new GUIGamePlayModel();
	}

	public ISummaryView ConcreteGUISummaryView()
	{
		GUISuccessSummaryViewInstance = Instantiate(GUISuccessSummaryViewPrefab);
		GUIGamePlayViewInstance.transform.SetParent(FindObjectOfType<GUIMain>().transform);
		GUISuccessSummaryViewInstance.Model = new GUISuccessSummaryModel(GUIGamePlayViewInstance.Model);
		_summaryView = GUISuccessSummaryViewInstance;
		return _summaryView;
	}

	public ISummaryView ConcreteGUIFailureSummaryView()
	{
		GUIFailureSummaryViewInstance = Instantiate(GUIFailureSummaryViewPrefab);
		GUIGamePlayViewInstance.transform.SetParent(FindObjectOfType<GUIMain>().transform);
		GUIFailureSummaryViewInstance.Model = new GUIFailureSummaryModel(GUIGamePlayViewInstance.Model);
		_summaryView = GUIFailureSummaryViewInstance;
		return _summaryView;
	}
}
