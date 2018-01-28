using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SingletonTest {

	private static SingletonTest _instance;

	private SingletonTest() {}

	public static SingletonTest Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SingletonTest();
			}
			return _instance;
		}
	}

	public string TestStringMenu = "testowy string z singletona MENU";
	public string TestStringGame = "testowy string z singletona GAME";
}
