using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class GameController : DogeGameBehavior
	{
		override protected void Start()
		{
			base.Start();

			enabled = false;
		}

		void Update()
		{
		}

		void OnStartGame()
		{
			enabled = true;
		}
	}
}
