using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIGamePlayModel
{
	/*
	 * Model potrzebuje dostepu do:
	 * całego singletona, bo GUISummaryController będzie zapisywał wszystkie zmiany z GUIGamePlayView do PlayerPrefs i struktura jsona musi się zgadzać
	 */

	//public PlayerProfile CurrentProfile;
	public PlayersProfiles PlayersProfilesLoadedToModel;
	public bool AchievementIsUnlocked;

	/*
	 * jesli możliwe będzie przekonwertowanie projektu z C# 4.0 na C# 6.0
	 * będę mógł stworzyć klasę tworzącą parę {nazwa_achievementu, czy_zdobyty_podczas_gry}
	 * co pozwoli mi tworzenie Listy achievementów odblokowanych PODCZAS gry
	 * a następnie wyświelenie ich w SummaryView
	 */ 
}
