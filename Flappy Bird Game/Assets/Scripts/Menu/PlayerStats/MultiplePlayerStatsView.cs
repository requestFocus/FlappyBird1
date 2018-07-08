﻿using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System;

public class MultiplePlayerStatsView : MonoBehaviour
{
	[Inject]
	private DiContainer _container;

	[Inject]
	private SinglePlayerStatsView _singlePlayerStatsView;

	//[Inject]
	private ProjectData _dataToDisplay;

	private List<SinglePlayerStatsView> _listOfContainers = new List<SinglePlayerStatsView>();

	private Vector3 _playerNameLabelPos;
	private Vector3 _highscoreLabelPos;
	private Vector3 _achievementsLabelPos;

	private Vector3 _startPos;
	private Vector3 _delta;
	private Vector3 _movement;

	private int _containerGap;
	private int _currentTopEntry;
	private const int _scope = 7;
	private int _elementsToDisplayOnStart;                                          // playerów w pamięci może być mniej niż _scope, dlatego to jest ostateczna ilość playerów do wyswietlenia
	private int _startingEntry;

	private void Start()
	{
		_playerNameLabelPos = new Vector3(317, 370, 0);
		_highscoreLabelPos = new Vector3(417, 370, 0);
		_achievementsLabelPos = new Vector3(537, 370, 0);

		FillContainersOnStart();
	}

	private void Update()
	{
		FollowMouse();
	}

	public void CreateEmptyContainers(ProjectData projectData)                  // tyle ile kontenerów ma byc w hierarchii, widocznych oraz niewidocznych
	{
		_dataToDisplay = projectData;                                           // ta funkcja wywoływana jest z poziomu innej klasy i wymaga zestawu danych jako argumentu

		for (int i = 0; i < _scope; i++)
		{
			SinglePlayerStatsView singlePlayerStatsViewInstance = Instantiate(_singlePlayerStatsView);                                          // tworzy puste obiekty w hierarchii, ktore...
			_container.Inject(singlePlayerStatsViewInstance);
			singlePlayerStatsViewInstance.transform.SetParent(gameObject.transform);
			singlePlayerStatsViewInstance.name = "SinglePlayerViewInstance" + i;
			_listOfContainers.Add(singlePlayerStatsViewInstance);
		}
	}

	private void FillContainersOnStart()                // wypełnia tyle kontenerów, ile znajduje się w hierarchii
	{
		if (_dataToDisplay.EntireList.Count < _scope)
			_elementsToDisplayOnStart = _dataToDisplay.EntireList.Count;
		else
			_elementsToDisplayOnStart = _scope;

		for (int i = 0; i < _elementsToDisplayOnStart; i++)
		{
			_listOfContainers[i].CreateSinglePlayerStatsView(_dataToDisplay.EntireList[i], _playerNameLabelPos, _highscoreLabelPos, _achievementsLabelPos);       // ...nastepnie wypełnia danymi playera

			_playerNameLabelPos.y -= 40;
			_highscoreLabelPos.y -= 40;
			_achievementsLabelPos.y -= 40;
		}
	}

	private void FollowMouse()
	{
		if (_dataToDisplay.EntireList.Count > _scope)                       // jeśli playerów na liście jest mniej niż kontenerów to nie ma sensu w ogóle odpalać Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				_startPos = Input.mousePosition;
			}
			else if (Input.GetMouseButton(0) && Input.mousePosition.x > 0 && Input.mousePosition.x < 800 && Input.mousePosition.y < 400 && Input.mousePosition.y > 0)
			{
				_delta = _startPos - Input.mousePosition;

				for (int i = 0; i < _scope; i++)
				{
					if (_delta.y < 0)
						MoveDataFilledContainersDown(i);
					else if (_delta.y > 0)
						MoveDataFilledContainersUp(i);
				}
			}
			else if (Input.GetMouseButtonUp(0))
			{
				_startPos = new Vector3(0, 0, 0);
			}
		}
	}

	// podejście 2
	private void MoveDataFilledContainersDown(int index)					// delta ujemna
	{
		_containerGap = 40;										

		if (_currentTopEntry < (_dataToDisplay.EntireList.Count - _scope))
		{
			_movement = new Vector3(_listOfContainers[index].transform.position.x, _listOfContainers[index].transform.position.y - _delta.y / 30, 0);          // dziele przez X, żeby skok nie był tak duży
			_listOfContainers[index].transform.position = _movement;                             // przesuniecie kontenera we wskazanym kierunku

			if (_listOfContainers[0].AchievementSingleEntryViewInstance.Complete10Inactive.transform.position.y > 350)         // gorna granica listy, wczytaj poprzednie elementy
			{
				for (int i = 0; i < _scope; i++)
				{
					_listOfContainers[i].transform.position = new Vector3(_listOfContainers[i].transform.position.x, (float)Math.Round(_listOfContainers[i].transform.position.y - _containerGap), 0);
				}
				_currentTopEntry++;
				ReplaceProfiles(_currentTopEntry);
			}
		}
	}

	private void MoveDataFilledContainersUp(int index)                      // delta dodatnia
	{
		_containerGap = 40;

		if (_currentTopEntry > 0)
		{
			_movement = new Vector3(_listOfContainers[index].transform.position.x, _listOfContainers[index].transform.position.y - _delta.y / 30, 0);          // dziele przez X, żeby skok nie był tak duży
			_listOfContainers[index].transform.position = _movement;                             // przesuniecie kontenera we wskazanym kierunku

			if (_listOfContainers[0].AchievementSingleEntryViewInstance.Complete10Inactive.transform.position.y < 280)         // dolna granica listy, wczytaj nastepne elementy
			{
				_currentTopEntry--;
				ReplaceProfiles(_currentTopEntry);
				for (int i = 0; i < _scope; i++)
				{
					_listOfContainers[i].transform.position = new Vector3(_listOfContainers[i].transform.position.x, (float)Math.Round(_listOfContainers[i].transform.position.y + _containerGap), 0);
				}

			}
		}
	}

	private void ReplaceProfiles(int startingEntry)
	{
		for (int i = 0; i < _scope; i++)
		{
			_listOfContainers[i].PlayerName.text = _dataToDisplay.EntireList[startingEntry].PlayerName;

			_listOfContainers[i].HighScore.text = _dataToDisplay.EntireList[startingEntry].HighScore.ToString();

			_listOfContainers[i].AchievementSingleEntryViewInstance.Complete10Active.gameObject.SetActive(false);
			_listOfContainers[i].AchievementSingleEntryViewInstance.Complete25Active.gameObject.SetActive(false);
			_listOfContainers[i].AchievementSingleEntryViewInstance.Complete50Active.gameObject.SetActive(false);

			if (_dataToDisplay.EntireList[startingEntry].Complete10)
			{
				_listOfContainers[i].AchievementSingleEntryViewInstance.Complete10Active.gameObject.SetActive(true);

				if (_dataToDisplay.EntireList[startingEntry].Complete25)
				{
					_listOfContainers[i].AchievementSingleEntryViewInstance.Complete25Active.gameObject.SetActive(true);

					if (_dataToDisplay.EntireList[startingEntry].Complete50)
					{
						_listOfContainers[i].AchievementSingleEntryViewInstance.Complete50Active.gameObject.SetActive(true);
					}
				}
			}

			startingEntry++;
		}
	}
}
