using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	[SerializeField] private BackgroundGameView _backgroundGameViewPrefab;
	[SerializeField] private ColumnView _columnViewPrefab;
	[SerializeField] private GUIGamePlayView _guiGamePlayViewPrefab;
	[SerializeField] private GUISuccessSummaryView _guiSuccessSummaryViewPrefab;
	[SerializeField] private GUIFailureSummaryView _guiFailureSummaryViewPrefab;
	[SerializeField] private ViewFactory _viewFactoryPrefab;

	[SerializeField] private CurrentPlayerData _currentPlayerData;

	//public override void Start()
	//{
		//_viewFactoryPrefab.InjectMeDel = InjectToDel;
	//}

	public override void InstallBindings()
	{
		Container.Bind<BackgroundGameView>().FromComponentInNewPrefab(_backgroundGameViewPrefab).AsSingle().NonLazy();

		Container.Bind<ColumnView>().FromInstance(_columnViewPrefab).AsTransient().Lazy();

		Container.Bind<GUIGamePlayView>().FromInstance(_guiGamePlayViewPrefab).AsSingle().Lazy();
		Container.Bind<GUIGamePlayModel>().FromNew().AsSingle().Lazy();

		Container.Bind<GUISuccessSummaryView>().FromInstance(_guiSuccessSummaryViewPrefab).AsSingle().Lazy();
		Container.Bind<GUISuccessSummaryModel>().FromNew().AsSingle().Lazy();

		Container.Bind<GUIFailureSummaryView>().FromInstance(_guiFailureSummaryViewPrefab).AsSingle().Lazy();
		Container.Bind<GUIFailureSummaryModel>().FromNew().AsSingle().Lazy();

		Container.Bind<ViewFactory>().FromComponentInNewPrefab(_viewFactoryPrefab).AsSingle().NonLazy();

		Container.Bind<CurrentPlayerData>().FromNew().AsSingle().Lazy();
	}

	//public GameObject InjectToDel(GUIGamePlayView prefab)
	//{
	//	return Container.InstantiatePrefab(prefab);
	//}
}
