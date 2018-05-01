﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFactory : MonoBehaviour
{
	[SerializeField] private GUIGamePlayView GUIGamePlayViewPrefab;
	[SerializeField] private GUISuccessSummaryView GUISuccessSummaryViewPrefab;
	[SerializeField] private GUIFailureSummaryView GUIFailureSummaryViewPrefab;

	private static ViewFactory _factoryInstance;

	public static ViewFactory FactoryInstance
	{
		get
		{
			_factoryInstance = FindObjectOfType<ViewFactory>();
			if (_factoryInstance == null)
			{
				GameObject singleton = new GameObject(typeof(ViewFactory) + "Singleton");
				_factoryInstance = singleton.AddComponent<ViewFactory>();
			}
			return _factoryInstance;
		}
	}

	public string Tekst = "tekst";

	public GUIGamePlayView ConcreteGUIGamePlayView()
	{
		GUIGamePlayViewPrefab = Resources.Load("Prefabs/GUIGamePlayView", typeof(GUIGamePlayView)) as GUIGamePlayView;
		GUIGamePlayView GUIGamePlayViewInstance = Instantiate(GUIGamePlayViewPrefab);
		GUIGamePlayViewInstance.Model = new GUIGamePlayModel();
		return GUIGamePlayViewInstance;
	}

	public ISummaryView ConcreteGUISuccessSummaryView(GUIGamePlayView gamePlayView)
	{
		GUISuccessSummaryViewPrefab = Resources.Load("Prefabs/GUISuccessSummaryView", typeof(GUISuccessSummaryView)) as GUISuccessSummaryView;
		ISummaryView SummaryView = Instantiate(GUISuccessSummaryViewPrefab);
		((GUISuccessSummaryView)SummaryView).Model = new GUISuccessSummaryModel(gamePlayView.Model);
		return SummaryView;
	}

	public ISummaryView ConcreteGUIFailureSummaryView(GUIGamePlayView gamePlayView)
	{
		GUIFailureSummaryViewPrefab = Resources.Load("Prefabs/GUIFailureSummaryView", typeof(GUIFailureSummaryView)) as GUIFailureSummaryView;
		ISummaryView SummaryView = Instantiate(GUIFailureSummaryViewPrefab);
		((GUIFailureSummaryView)SummaryView).Model = new GUIFailureSummaryModel(gamePlayView.Model);
		return SummaryView;
	}
}
