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

		override protected void Start()
		{
			base.Start();

			StateRoot = GameObject.Find("StateRoot").transform;
			Debug.Assert(StateRoot != null);

			MissGenerator = GameObject.Find("MissGenerator").GetComponent<MissGenerator>();
			Debug.Assert(MissGenerator != null);

			CanvasRoot = GameObject.Find("Canvas").GetComponent<Canvas>();
		}
	}
}
