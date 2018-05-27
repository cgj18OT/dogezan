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

		public Message MessageText;

		public AudioClip AudioReadyWait;
		public AudioClip AudioCountDown;
		public AudioClip AudioGameStart;
		private AudioSource AudioSource;

		override protected void Start()
		{
			base.Start();

			//Audio
			AudioSource = GetComponent<AudioSource>();
			Debug.Assert(AudioSource != null);
			Debug.Assert(AudioReadyWait != null);
			Debug.Assert(AudioCountDown!= null);
			Debug.Assert(AudioGameStart != null);

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
		}

		private bool IsReadyInput()
		{
			var p1 = InputManager.P1;
			var p2 = InputManager.P2;

			var p1ready = Mathf.Abs(p1.Vertical) <= 0.01f && !p1.Attack;
			var p2ready = Mathf.Abs(p2.Vertical) <= 0.01f && !p2.Attack;

			return p1ready && p2ready;
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

			AudioSource.PlayOneShot(AudioReadyWait);
		}

		private void UpdateFirstWait()
		{
			GenericTimer -= Time.deltaTime;

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
				AudioSource.PlayOneShot(AudioCountDown);
			}
			string[] msg = { "壱", "弐", "参" };
			SetMessageText(msg[index]);
			SetMessageScale((GenericTimer % 1) * 2.0f);
		}

		private void InitInGame()
		{
			CurrentState = State.InGame;
			Debug.Log("Go to InGame.");

			BGM.Play();

			AudioSource.PlayOneShot(AudioGameStart);

			StateRoot.BroadcastMessage("OnStartGame");
			CanvasRoot.BroadcastMessage("OnStartGame");

			SetMessageText("始め！");
			SetMessageScale(1.0f);
			MessageText.StartAlphaUpdate();
		}
	}
}

