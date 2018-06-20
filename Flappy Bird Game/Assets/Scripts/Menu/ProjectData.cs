using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectData
{
	public List<PlayerProfile> EntireList;
	public int CurrentID;
	public string Tekst;

	public ProjectData()
	{
		Debug.Log("======================konstruktor ProjectData zostaje wywołany======================");
		EntireList = new List<PlayerProfile>();
		//Tekst = "tekst oryginalny";
	}
}