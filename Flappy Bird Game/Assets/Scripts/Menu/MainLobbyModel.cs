using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobbyModel
{
	public List<PlayerProfile> EntireList = PlayersProfiles.Instance.ListOfProfiles;
	public PlayerProfile CurrentListEntry = LoginViewService.PlayerProfile;						// ten jeden wybrany, który albo znaleziono na liście albo dodano, jeśli wcześniej nie istniał

}
