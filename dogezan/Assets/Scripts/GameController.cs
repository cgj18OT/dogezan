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
			if (InputManager.P1.Attack)
			{
				MissGenerator.generate(PlayerID.P1);
			}

			if (InputManager.P2.Attack)
			{
				MissGenerator.generate(PlayerID.P2);
			}
		}

		void OnStartGame()
		{
			enabled = true;
		}
	}
}
