using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject BranchPrefab;
	public GUIGamePlayView GUIGamePlayView;

	private enum _intervalLockStates
	{
		Unlocked,
		Locked
	};
	private _intervalLockStates _intervalLock;

	private int _currentScore;
	public int CurrentScore
	{
		get
		{
			return _currentScore;
		}
		set
		{
			_currentScore += value;
			_intervalLock = _intervalLockStates.Locked;
		}
	}

	private float _timeIntervalForCoroutine;
	public float TimeIntervalForCoroutine
	{
		get
		{
			return _timeIntervalForCoroutine;
		}
		set
		{
			_timeIntervalForCoroutine = value;
		}
	}

	private const float _intervalStep = 0.3f;



	private void Start()
	{
		TimeIntervalForCoroutine = 3.0f;											// 3.0f jako wartosc startowa

		StartCoroutine(CreateObstacle());                                           //InvokeRepeating("CreateObstacle", 3.0f, 3.0f);
	}


	private IEnumerator CreateObstacle()								// tworzy obstacle'a, czy to serwis?
	{
		while (true)
		{
			yield return new WaitForSeconds(CalculateTimeIntervalForObstacles());
			Instantiate(BranchPrefab);
		}
	}



	public float CalculateTimeIntervalForObstacles()					// SERWIS, wylicza (skraca) czas między pojawianiem się kolejnych przeszkód
	{
		if (CurrentScore != 0 && CurrentScore % 10 == 0 && TimeIntervalForCoroutine > 1.0f && _intervalLock == _intervalLockStates.Locked)
		{
			TimeIntervalForCoroutine = TimeIntervalForCoroutine - _intervalStep;
		}
		_intervalLock = _intervalLockStates.Unlocked;
		return _timeIntervalForCoroutine;
	}



	public bool AchievementToUnlock()									// SERWIS, weryfikuje i przyznaje achievementy
	{
		if (CurrentScore == 10)
		{
			if (!PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete10)   // nie ma jeszcze achievementu
			{
				PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete10 = true;
				return true;
			}
		}
		if (CurrentScore == 25)
		{
			if (!PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete25)   // nie ma jeszcze achievementu
			{
				PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete25 = true;
				return true;
			}
		}
		if (CurrentScore == 50)
		{
			if (!PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete50)   // nie ma jeszcze achievementu
			{
				PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete50 = true;
				return true;
			}
		}

		return false;                                                                                       // brak achievementu do odblokowania, już posiada wszystko, co się należy
	}
}


/*
 * WIDOK 
 * player i przeszkoda jednym widokiem działającym w widoku drugim
 * elementy gui gameplayu drugim widokiem
 * elementy gui summary trzecim widokiem
 * 
 * MODEL - playername zapisany w CurrentProfile
 *       - highscore zapisany w CurrentProfile
 *       - achievements zapisany w CurrentProfile do sprawdzania podczas trwania gry czy został unlockowany achievement (sam stan nie jest nigdzie wyświetlany podczas gry)
 *
 *KONTROLER - po skończonej grze zapisuje nowy wynik w MODELU 
 *			 - w przypadku DontRepeat dane w WIDOKACH MENU zaktualizują się same podczas przełączania sceny
 *			 - w przypadku Repeat dane w WIDOKACH GAME muszą zostać zaktualizowane ręcznie - subskrypcja?==============
 *			 - jeśli highscore nie został poprawiony, nie ma potrzeby zapisywania danych modelu (hint: jeśli nie poprawiono highscore'a to na pewno nie unlockowano też nowych achievmentów)  
 *			 - jeśli widok nie zmienia modelu to nie potrzebuje dostępu do kontrolera
 */
