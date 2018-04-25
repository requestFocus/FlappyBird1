using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISummaryView
{
	void DisplayGUISummaryView();
	void SetSummaryScreen(bool state);
	void RepeatGame();
	void BackToMenu();
}
