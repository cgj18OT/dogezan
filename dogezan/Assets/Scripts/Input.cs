﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class Input : MonoBehaviour
	{
		public string VerticalKey = "";
		public string AttackKey = "";
		public PlayerID PlayerID = PlayerID.Unknown;

		void Start()
		{
			Debug.Assert(PlayerID != PlayerID.Unknown);
		}

		void Update()
		{
		}

		public float Vertical
		{
			get
			{
				return UnityEngine.Input.GetAxis(VerticalKey);
			}
		}

		public bool Attack
		{
			get
			{
				return UnityEngine.Input.GetButtonDown(AttackKey);
			}
		}
	}
}
