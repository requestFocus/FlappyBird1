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
			if (_factoryInstance == null)
			{
				_factoryInstance = new Singleton<TFactory>();
			}
			return _factoryInstance;
		}
	}

	private Singleton() { }
}
