using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	[SerializeField] private BackgroundGameView _backgroundGameViewPrefab;
	[SerializeField] private ColumnView _columnViewPrefab;

	public override void InstallBindings()
	{
		Container.Bind<BackgroundGameView>().FromComponentInNewPrefab(_backgroundGameViewPrefab).AsSingle();

		Container.Bind<ColumnView>().FromComponentInNewPrefab(_columnViewPrefab).AsTransient().Lazy();
	}
}
