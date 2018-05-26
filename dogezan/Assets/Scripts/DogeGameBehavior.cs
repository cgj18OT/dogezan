using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class DogeGameBehavior : DogeBehavior
	{
		[HideInInspector]
		[System.NonSerialized]
		public Transform StateRoot;

		[HideInInspector]
		[System.NonSerialized]
		public MissGenerator MissGenerator;

		[HideInInspector]
		[System.NonSerialized]
		public Canvas CanvasRoot;

		[HideInInspector]
		[System.NonSerialized]
		public Player Player1;

		[HideInInspector]
		[System.NonSerialized]
		public Player Player2;

		override protected void Start()
		{
			base.Start();

			StateRoot = GameObject.Find("StateRoot").transform;
			Debug.Assert(StateRoot != null);

			MissGenerator = GameObject.Find("MissGenerator").GetComponent<MissGenerator>();
			Debug.Assert(MissGenerator != null);

			CanvasRoot = GameObject.Find("Canvas").GetComponent<Canvas>();
			Debug.Assert(CanvasRoot != null);

			var players = CanvasRoot.GetComponentsInChildren<Player>();
			foreach(var p in players)
			{
				if (p.gameObject.name == "P1")
				{
					Player1 = p;
				}
				else if (p.gameObject.name == "P2")
				{
					Player2 = p;
				}
			}

			Debug.Assert(Player1 != null);
			Debug.Assert(Player2 != null);
		}
	}
}
