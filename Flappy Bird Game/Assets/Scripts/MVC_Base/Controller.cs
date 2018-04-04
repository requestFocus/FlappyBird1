using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller<TModel>
{
	private TModel _model;

	public TModel Model
	{
		get { return _model; }

		set { _model = value; }
	}
}
