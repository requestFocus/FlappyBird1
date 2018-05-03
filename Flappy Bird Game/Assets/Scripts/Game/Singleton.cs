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
				//GameObject singleton = new GameObject(typeof(TFactory) + "SingletonGeneric");
				//_factoryInstance = singleton.AddComponent<TFactory>();						// nie można dodać komponentu w ten sposób

				_factoryInstance = (TFactory)Activator.CreateInstance(typeof(TFactory));        // WARNING: createinstance wykonane, ale "You are trying to create a MonoBehaviour using the 'new' keyword"
			}
			return _factoryInstance;
		}
	}
}


// jak stworzyc dziedziczący po monobehaviour obiekt singletona na podstawie typu generycznego?