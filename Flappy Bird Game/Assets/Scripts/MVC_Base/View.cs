using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View<TModel, TController> : MonoBehaviour where TController : Controller<TModel>		// czy TController już wie, że jego parametryzowane typy dziedziczą po Controller? TAK, teraz wie 
{
	private TController _controller;
	private TModel _model;

	public TController Controller
	{
		get { return _controller; }

		set { _controller = value; }
	}

	public TModel Model
	{
		get { return _model; }

		set
		{
			_model = value;

			if (_controller == null)
			{
				_controller = (TController)Activator.CreateInstance(typeof(TController));
				_controller.Model = value;                     
			}
		}
	}
}
