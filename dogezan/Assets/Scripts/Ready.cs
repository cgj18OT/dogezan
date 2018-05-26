using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class Ready : DogeGameBehavior
	{
		public enum State
		{
			FirstWait,
			ReadyWait,
			InGame,
		};
		private State CurrentState = State.FirstWait;

		public float FirstWaitTime = 3;
		private float GenericTimer = 0;

		public UnityEngine.UI.Text MessageText;
		public UnityEngine.UI.Text P1InputText;
		public UnityEngine.UI.Text P2InputText;

		override protected void Start()
		{
			base.Start();

			InitFirstWait();
		}

		void Update()
		{
			switch (CurrentState)
			{
				case State.FirstWait:
					UpdateFirstWait();
					break;

				case State.ReadyWait:
					UpdateReadyWait();
					break;
			}

			UpdateInputText();
		}

		private bool IsReadyInput()
		{
			var p1 = InputManager.P1;
			var p2 = InputManager.P2;

			var p1ready = Mathf.Abs(p1.Vertical) <= 0.01f && !p1.Attack;
			var p2ready = Mathf.Abs(p2.Vertical) <= 0.01f && !p2.Attack;

			return p1ready && p2ready;
		}

		private void UpdateInputText()
		{
			if (P1InputText != null)
			{
				P1InputText.text = InputManager.P1.Vertical.ToString("F3");
			}

			if (P2InputText != null)
			{
				P2InputText.text = InputManager.P2.Vertical.ToString("F3");
			}
		}

		private void SetMessageText(string msg)
		{
			MessageText.text = msg;
		}

		private void SetMessageScale(float scale)
		{
			MessageText.transform.localScale = new Vector3(scale, scale, 1);
		}

		private void InitFirstWait()
		{
			Debug.Log("Go to FirstWait.");
			CurrentState = State.FirstWait;
			GenericTimer = FirstWaitTime;
			SetMessageText("両者、構え！");
			SetMessageScale(1);
		}

		private void UpdateFirstWait()
		{
			GenericTimer -= Time.deltaTime;
			//Debug.Log("FirstWait... " + GenericTimer);

			if (!IsReadyInput())
			{
				GenericTimer = FirstWaitTime;
			}

			if (GenericTimer <= 0.0f)
			{
				InitReadyWait();
			}
		}

		private void InitReadyWait()
		{
			Debug.Log("Go to ReadyWait.");
			CurrentState = State.ReadyWait;
			SetMessageText("");
			SetMessageScale(1);
			GenericTimer = 3.0f;
		}

		private uint old_index = 0;
		private void UpdateReadyWait()
		{
			GenericTimer -= Time.deltaTime;

			if (!IsReadyInput())
			{
				InitFirstWait();
				return;
			}

			if (GenericTimer <= 0.0f)
			{
				InitInGame();
				return;
			}

			var index = (uint)(GenericTimer + 1) - 1;
			if (old_index != index)
			{
				old_index = index;
				MessageText.transform.localScale = new Vector3(1, 1, 1);
			}
			string[] msg = { "壱", "弐", "参" };
			SetMessageText(msg[index]);
			SetMessageScale(GenericTimer % 1);
		}

		private void InitInGame()
		{
			CurrentState = State.InGame;
			Debug.Log("Go to InGame.");

			StateRoot.BroadcastMessage("OnStartGame");
		}
	}
}

