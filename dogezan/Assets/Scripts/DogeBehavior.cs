using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class DogeBehavior : MonoBehaviour {
		public InputManager InputManager;

		void Awake()
		{
			InputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
		}

		void Start() {
		}

		void Update() {
		}
	}
}
