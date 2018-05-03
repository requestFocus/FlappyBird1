using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonViewFactory : MonoBehaviour
{
	private static ViewFactory _singletonViewFactoryInstance;
	private static ViewFactory ViewFactoryPrefab;

	public static ViewFactory SingletonViewFactoryInstance
	{
		get
		{
			if (_singletonViewFactoryInstance == null)
			{
				GameObject singleton = new GameObject(typeof(ViewFactory) + "SingletonExternal");
				_singletonViewFactoryInstance = singleton.AddComponent<ViewFactory>();

				//ViewFactoryPrefab = Resources.Load("Prefabs/ViewFactory", typeof(ViewFactory)) as ViewFactory;
				//_singletonViewFactoryInstance = Instantiate(ViewFactoryPrefab);
			}
			return _singletonViewFactoryInstance;
		}
	}
}