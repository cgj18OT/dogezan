using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class MissGenerator : MonoBehaviour {
		public GameObject missPrefab;
		public GameObject canvas;

		void Start() {
			Debug.Assert(missPrefab != null);
			Debug.Assert(canvas != null);
		}

		void Update() {
		}

		public void generate(PlayerID playerID)
		{
			var h = (playerID == PlayerID.P1) ? Random.Range(-388.0f, -118.0f) : Random.Range(118.0f, 388.0f);
			//h += 500;
			var v = Random.Range(65, 217);// + 300;

			var pos = new Vector3(h, v, 0);
			var rot = Quaternion.identity;
			var go = (GameObject)Instantiate(missPrefab, canvas.transform);
			go.transform.localPosition = pos;
		}
	}
}
