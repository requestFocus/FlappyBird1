using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<TFactory> : MonoBehaviour where TFactory : MonoBehaviour
{
	private static TFactory _factoryInstance;

	public static TFactory FactoryInstance
	{
		get
		{
			_factoryInstance = FindObjectOfType<TFactory>();
			if (_factoryInstance == null)
			{
				GameObject singleton = new GameObject(typeof(TFactory) + "SingletonGeneric");
				_factoryInstance = singleton.AddComponent<TFactory>();                        
			}
			return _factoryInstance;
		}
	}
}
