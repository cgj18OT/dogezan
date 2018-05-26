using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class DogeBehavior : MonoBehaviour {
		[HideInInspector]
		[System.NonSerialized]
		public InputManager InputManager;

		virtual protected void Start()
		{
			InputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
			Debug.Assert(InputManager != null);
		}
	}
}
