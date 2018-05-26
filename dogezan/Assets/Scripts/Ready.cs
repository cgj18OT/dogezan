using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{

	public class Ready : DogeBehavior
	{
		public enum State
		{
			FirstWait,
			ReadyWait,
		};
		private State CurrentState = State.FirstWait;

		public float FirstWaitTime = 3;
		private float GenericTimer = 0;

		public UnityEngine.UI.Text MessageText;
		public UnityEngine.UI.Text P1InputText;
		public UnityEngine.UI.Text P2InputText;

		// Use this for initialization
		void Start()
		{
			InitFirstWait();
		}

		// Update is called once per frame
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
			var p1ready = Mathf.Abs(InputManager.P1.Vertical) <= 0.01f;
			var p2ready = Mathf.Abs(InputManager.P2.Vertical) <= 0.01f;
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

		private void InitFirstWait()
		{
			Debug.Log("Go to FirstWait.");
			CurrentState = State.FirstWait;
			GenericTimer = FirstWaitTime;
			MessageText.text = "両者、構え！";
		}

		private void UpdateFirstWait()
		{
			GenericTimer -= Time.deltaTime;
			Debug.Log("FirstWait... " + GenericTimer);

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
			MessageText.text = "";
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
				InitReadyStart();
				return;
			}

			var index = (uint)(GenericTimer + 1) - 1;
			if (old_index != index)
			{
				old_index = index;
				MessageText.transform.localScale = new Vector3(1, 1, 1);
			}
			string[] msg = {
				"壱", "弐", "参"
			};
			MessageText.text = msg[index];
			var scale = GenericTimer % 1;
			MessageText.transform.localScale = new Vector3(scale, scale, 1);
		}

		private void InitReadyStart()
		{
			CurrentState = State.ReadyWait;
		}
	}
}

