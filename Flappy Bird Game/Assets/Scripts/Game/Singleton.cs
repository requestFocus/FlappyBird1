using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<TFactory> : MonoBehaviour
{
	private static TFactory _factoryInstance;

	public static TFactory FactoryInstance
	{
		get
		{
			if (_factoryInstance == null)
			{
				_factoryInstance = (TFactory)Activator.CreateInstance(typeof(TFactory));        // WARNING: createinstance wykonane, ale "You are trying to create a MonoBehaviour using the 'new' keyword"
			}
			return _factoryInstance;
		}
	}
}
