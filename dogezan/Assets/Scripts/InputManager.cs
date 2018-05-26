using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class InputManager : MonoBehaviour {
		void Start() {
			var inputs = GetComponentsInChildren<doge.Input>();
			Debug.Assert(inputs.Length == 2);

			foreach (var i in inputs)
			{
				switch (i.PlayerID)
				{
					case PlayerID.P1:
						P1 = i;
						break;

					case PlayerID.P2:
						P2 = i;
						break;
				}
			}
		}

		void Update() {
		}

		public Input get(PlayerID playerID)
		{
			switch (playerID)
			{
				case PlayerID.Unknown:
					Debug.Assert(false);
					break;
				case PlayerID.P1:
					return P1;
				case PlayerID.P2:
					return _P2;
			}
			return null;
		}

		private Input _P1;
		public Input P1
		{
			get { return _P1; }
			set
			{
				Debug.Assert(_P1 == null);
				_P1 = value;
				Debug.Log("Set P1 input.");
			}
		}

		private Input _P2;
		public Input P2
		{
			get { return _P2; }
			set
			{
				Debug.Assert(_P2 == null);
				_P2 = value;
				Debug.Log("Set P2 input.");
			}
		}
	}
}
