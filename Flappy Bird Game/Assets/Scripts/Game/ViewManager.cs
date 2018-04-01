using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour {

	[SerializeField] private GUIGamePlayView GUIGamePlayViewPrefab;
	[SerializeField] private GUIGamePlayView GUIGamePlayViewInstance;
	[SerializeField] private GUISummaryView GUISummaryViewPrefab;
	[SerializeField] private GUISummaryView GUISummaryViewInstance;
	
	public void CreateGUIGamePlayView()							// ten widok powstaje zawsze jako pierwszy z dwóch
	{
		GUIGamePlayViewInstance = Instantiate(GUIGamePlayViewPrefab, gameObject.transform);
		GUIGamePlayViewInstance.Model = new GUIGamePlayModel()
		{
			PlayersProfilesLoadedToModel = PlayersProfiles.Instance
		};
	}

	public void CreateGUISummaryView()							// ten widok powstaje zawsze jako drugi z dwóch
	{
		GUISummaryViewInstance = Instantiate(GUISummaryViewPrefab, gameObject.transform);
		GUISummaryViewInstance.Model = new GUISummaryModel()
		{
			PlayersProfilesSentFromGamePlay = GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel
		};
	}
}
