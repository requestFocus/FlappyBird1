using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
	[SerializeField] private ViewFactory ViewFactory;

	public void SwitchView()
	{
		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				ViewFactory.ConcreteGUIGamePlayView();
				break;

			case CurrentGameStateService.GameStates.Summary:
				ViewFactory.ConcreteGUISummaryView();
				break;
		}
	}
}
