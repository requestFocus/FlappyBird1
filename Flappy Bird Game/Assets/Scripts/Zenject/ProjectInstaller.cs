using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private SoundService _soundService;
    [SerializeField] private MusicService _musicService;

	public override void InstallBindings()
	{
		Container.Bind<ProjectData>().FromNew().AsSingle().NonLazy();
        Container.Bind<SoundService>().FromComponentInNewPrefab(_soundService).AsSingle().NonLazy();
        Container.Bind<MusicService>().FromComponentInNewPrefab(_musicService).AsSingle().NonLazy();
	}
}
