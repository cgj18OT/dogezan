using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class EndGame : DogeGameBehavior
	{
		public Message MessageText;

		private bool isEnd = false;

		private float timer = 2.0f;

		protected override void Start()
		{
			base.Start();

			Debug.Assert(MessageText != null);
		}

		void Update()
		{
			if (isEnd)
			{
				timer -= Time.deltaTime;
				if (timer <= 0.0f)
				{
					UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
				}
			}
		}

		void OnEndGame()
		{
			MessageText.transform.localScale = new Vector3(1, 1, 1);

			string text = "";
			var diff = Mathf.Abs(Player1.SongenPointValue - Player2.SongenPointValue);
			if(diff < 0.5f)
			{
				text = "両者、敗北";
			}
			else if (Player1.SongenPointValue < Player2.SongenPointValue)
			{
				text = "勝者、右の者";
			}
			else if (Player1.SongenPointValue > Player2.SongenPointValue)
			{
				text = "勝者、左の者";
			}
			MessageText.text = text;
			MessageText.frontColor = new Color(1, 0, 0, 1);

			isEnd = true;
		}
	}
}
