using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFactory
{
	public GUIGamePlayModel ConcreteGUIGamePlayModel()
	{
		return new GUIGamePlayModel();
	}
}
