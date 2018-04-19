using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFactory
{
	public GUIGamePlayModel ConcreteGUIGamePlayModel()
	{
		return new GUIGamePlayModel();
	}

	public GUISummaryModel ConcreteGUISummaryModel(GUIGamePlayModel model)
	{
		return new GUISummaryModel(model);
	}
}
