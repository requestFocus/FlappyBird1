using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View<T> : MonoBehaviour {


	/* 
	 * Widoki, które nie posiadają Modelu nie dziedziczą po View<T>, tylko bezpośrednio po MonoBehaviour
	 */ 

	protected T _Model;

	public void SetModel(T model)
	{
		_Model = model;
	}
}
