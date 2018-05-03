using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonViewFactory : MonoBehaviour
{
	private static ViewFactory _singletonViewFactoryInstance;

	public static ViewFactory SingletonViewFactoryInstance
	{
		get
		{
			if (_singletonViewFactoryInstance == null)
			{
				GameObject singleton = new GameObject(typeof(ViewFactory) + "SingletonExternal");
				_singletonViewFactoryInstance = singleton.AddComponent<ViewFactory>();
			}
			return _singletonViewFactoryInstance;
		}
	}
}