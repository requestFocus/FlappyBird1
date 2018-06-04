using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	public static T Instance
	{
		get
		{
			_instance = FindObjectOfType<T>();
			if (_instance == null)
			{
				GameObject singleton = new GameObject(typeof(T) + "SingletonGeneric");
				_instance = singleton.AddComponent<T>();                        
			}
			return _instance;
		}
	}
}
