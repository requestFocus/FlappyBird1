using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<TFactory> : MonoBehaviour
{
	private static Singleton<TFactory> _factoryInstance;

	public static Singleton<TFactory> FactoryInstance
	{
		get
		{
			_factoryInstance = FindObjectOfType<Singleton<TFactory>>();
			if (_factoryInstance == null)
			{
				GameObject singleton = new GameObject(typeof(Singleton<TFactory>) + "SingletonGeneric");
				_factoryInstance = singleton.AddComponent<Singleton<TFactory>>();
			}
			return _factoryInstance;
		}
	}
}
