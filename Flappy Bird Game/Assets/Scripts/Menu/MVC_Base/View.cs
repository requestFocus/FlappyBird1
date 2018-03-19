﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View<TModel, TController> : MonoBehaviour
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
			if (_controller != null)
				_model = value;
			//else
			// _controller = TController;
			// _controller = new Controller();
			// _controller = new TController();
		}
	}
}
