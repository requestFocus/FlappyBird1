using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFactory : MonoBehaviour
{
	[SerializeField] private GUIGamePlayView GUIGamePlayViewPrefab;
	[SerializeField] private GUIGamePlayView GUIGamePlayViewInstance;
	[SerializeField] private GUISummaryView GUISummaryViewPrefab;
	[SerializeField] private GUISummaryView GUISummaryViewInstance;

	public void ConcreteGUIGamePlayView()
	{
		GUIGamePlayViewInstance = Instantiate(GUIGamePlayViewPrefab);
		GUIGamePlayViewInstance.transform.SetParent(FindObjectOfType<GUIMain>().transform);
		GUIGamePlayViewInstance.Model = new GUIGamePlayModel();
	}


	public void ConcreteGUISummaryView()
	{
		GUISummaryViewInstance = Instantiate(GUISummaryViewPrefab);
		GUIGamePlayViewInstance.transform.SetParent(FindObjectOfType<GUIMain>().transform);
		GUISummaryViewInstance.Model = new GUISummaryModel(GUIGamePlayViewInstance.Model);
	}
}
