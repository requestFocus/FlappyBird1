using System.Collections.Generic;

public class ProjectData
{
	public List<PlayerProfile> EntireList;
	public int CurrentID;
	public bool BackFromGamePlay;

	public ProjectData()
	{
		EntireList = new List<PlayerProfile>();
	}
}