using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectData
{
	public List<PlayerProfile> EntireList;
	public int CurrentID;

	public ProjectData()
	{
		EntireList = new List<PlayerProfile>();
		CurrentID = -1;
	}
}
