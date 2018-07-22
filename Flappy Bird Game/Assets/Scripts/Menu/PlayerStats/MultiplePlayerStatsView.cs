using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class MultiplePlayerStatsView : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	[Inject]
	private DiContainer _container;

	[Inject]
	private SinglePlayerStatsView _singlePlayerStatsView;

	private ProjectData _dataToDisplay;

	private List<SinglePlayerStatsView> _listOfContainers = new List<SinglePlayerStatsView>();

	private Vector3 _playerNameLabelPos;
	private Vector3 _highscoreLabelPos;
	private Vector3 _achievementsLabelPos;

	private Vector3 _startPos;
	private Vector3 _delta;
	private Vector2 _deltaValue;
	private Vector3 _movement;

	private int _containerGap;
	private int _currentTopEntry;
	private const int _scope = 7;
	private int _elementsToDisplayOnStart;                                        // playerów w pamięci może być mniej niż _scope, dlatego to jest ostateczna ilość playerów do wyswietlenia w Start()

	private void Start()
	{
		_playerNameLabelPos = new Vector3(300, 330, 0);						
		_highscoreLabelPos = new Vector3(400, 330, 0);
		_achievementsLabelPos = new Vector3(520, 330, 0);

		FillContainersOnStart();
	}

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        _deltaValue = Vector2.zero;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        _deltaValue += eventData.delta;

        for (int i = 0; i < _scope; i++)
        {
            if (_deltaValue.y < 0)
            {
                ScrollDataFilledContainersDown(i);
            }
            else if (_deltaValue.y > 0)
            {
                ScrollDataFilledContainersUp(i);
            }
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        _deltaValue = Vector2.zero;
    }

	public void CreateEmptyContainers(ProjectData projectData)                  // tyle ile kontenerów ma byc w hierarchii, widocznych oraz niewidocznych
	{
		_dataToDisplay = projectData;                                           // funkcja CreateEmptyContainers wywoływana jest z poziomu innej klasy i wymaga zestawu danych jako argumentu

		for (int i = 0; i < _scope; i++)
		{
			SinglePlayerStatsView singlePlayerStatsViewInstance = Instantiate(_singlePlayerStatsView);            // tworzy puste obiekty w hierarchii
			_container.Inject(singlePlayerStatsViewInstance);
			singlePlayerStatsViewInstance.transform.SetParent(gameObject.transform);
			singlePlayerStatsViewInstance.name = "SinglePlayerViewInstance" + i;
			_listOfContainers.Add(singlePlayerStatsViewInstance);
		}
	}

	private void FillContainersOnStart()										// wypełnia tyle kontenerów, ile znajduje się w hierarchii
	{
		if (_dataToDisplay.EntireList.Count < _scope)
			_elementsToDisplayOnStart = _dataToDisplay.EntireList.Count;
		else
			_elementsToDisplayOnStart = _scope;

		for (int i = 0; i < _elementsToDisplayOnStart; i++)
		{
			_listOfContainers[i].CreateSinglePlayerStatsView(_dataToDisplay.EntireList[i], _playerNameLabelPos, _highscoreLabelPos, _achievementsLabelPos);       

			_playerNameLabelPos.y -= 40;
			_highscoreLabelPos.y -= 40;
			_achievementsLabelPos.y -= 40;
		}
	}

    /* 
     * istotne jest, by sprawdzać polożenie ostatniego kontenera, 
     * czyli po tym jak WSZYSTKIE kontenery zmienią położenie
     */

	private void ScrollDataFilledContainersDown(int index)					  // delta ujemna = scrolluje w dół
	{
		_containerGap = 40;

        // dopoki ostatni kontener nie zawiera ostatniego elementu listy playerów oraz Y-pozycja ostatniego kontenera jest wieksza niz 135
		if (!(_listOfContainers[_scope - 1].PlayerName.text.ToString().Equals(_dataToDisplay.EntireList[_dataToDisplay.EntireList.Count - 1].PlayerName) && _listOfContainers[_scope - 1].PlayerName.transform.position.y > 135))
		{
			_movement = new Vector3(_listOfContainers[index].transform.position.x, _listOfContainers[index].transform.position.y - _deltaValue.y / 10, 0);      // dziele przez X, żeby skok nie był tak duży
			_listOfContainers[index].transform.position = _movement;                                                                                            // przesuniecie kontenera we wskazanym kierunku

            // sprawdza czy pozycja aktualnie znajdująca na poczatku listy umożliwia wypisanie scope-elementów bez rzucania wyjątkiem oraz czy Y-pozycja pierwszego kontenera wykracza poza górną granicę listy
			if (_currentTopEntry < (_dataToDisplay.EntireList.Count - _scope) && _listOfContainers[0].AchievementSingleEntryViewInstance.Complete10Inactive.transform.position.y > 350)
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

	private void ScrollDataFilledContainersUp(int index)                      // delta dodatnia = scrolluje w gore
	{
		_containerGap = 40;

        // dopoki pierwszy kontener nie zawiera pierwszego elementu listy playerów oraz Y-pozycja ostatniego kontenera jest mniejsza niż 60
        if (!(_listOfContainers[0].PlayerName.text.ToString().Equals(_dataToDisplay.EntireList[0].PlayerName) && _listOfContainers[_scope - 1].PlayerName.transform.position.y < 60))
        {
            _movement = new Vector3(_listOfContainers[index].transform.position.x, _listOfContainers[index].transform.position.y - (int)_deltaValue.y / 10, 0);     // dziele przez X, żeby skok nie był tak duży
            _listOfContainers[index].transform.position = _movement;                                                                                                // przesuniecie kontenera we wskazanym kierunku

            // sprawdza czy pozycja aktualnie znajdująca na poczatku listy nie jest jeszcze pierwszym elementem oraz czy Y-pozycja pierwszego kontenera wykracza poza dolną granicę listy
            if (_currentTopEntry > 0 && _listOfContainers[0].AchievementSingleEntryViewInstance.Complete10Inactive.transform.position.y < 310)
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
			}
			else
			{
				startingEntry++;
				continue;
			}
			if (_dataToDisplay.EntireList[startingEntry].Complete25)
			{
				_listOfContainers[i].AchievementSingleEntryViewInstance.Complete25Active.gameObject.SetActive(true);
			}
			else
			{
				startingEntry++;
				continue;
			}
			if (_dataToDisplay.EntireList[startingEntry].Complete50)
			{
				_listOfContainers[i].AchievementSingleEntryViewInstance.Complete50Active.gameObject.SetActive(true);
			}

			startingEntry++;
		}
	}
}
