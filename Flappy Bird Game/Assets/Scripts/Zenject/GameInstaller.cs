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

	public override void InstallBindings()
	{
		Container.Bind<BackgroundGameView>().FromComponentInNewPrefab(_backgroundGameViewPrefab).AsSingle().NonLazy();

		Container.Bind<ColumnView>().FromInstance(_columnViewPrefab).AsTransient().Lazy();

		Container.Bind<GUIGamePlayView>().FromComponentInNewPrefab(_guiGamePlayViewPrefab).AsSingle().Lazy();
		Container.Bind<GUIGamePlayModel>().FromNew().AsSingle().Lazy();
		Container.Bind<GUISuccessSummaryView>().FromComponentInNewPrefab(_guiSuccessSummaryViewPrefab).AsSingle().Lazy();
		Container.Bind<GUISuccessSummaryModel>().FromNew().AsSingle().Lazy();
	}
}
