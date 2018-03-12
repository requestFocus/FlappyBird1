using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGUIStyleViewService
{
	public GUIStyle LabelStyle;
	public GUIContent LabelContent;
	public string DarkGreyFont;
	public string LightGreyFont;

	private Font Font;

	public void SetGUIStyle()
	{
		Font = (Font)Resources.Load("Fonts/Bungee-Regular");

		LabelStyle = new GUIStyle
		{
			font = Font,
			fontSize = 14,
			alignment = TextAnchor.MiddleCenter
		};

		LabelContent = new GUIContent
		{
			text = "asd"
		};

		DarkGreyFont = "686868";                                     // dark grey
		LightGreyFont = "3f6a84";                                     // light grey
	}
}
