using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {

	private Model _model;

	public virtual void SetModel(Model model)
	{
		_model = model;
	}
}
