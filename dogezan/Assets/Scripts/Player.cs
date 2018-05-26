﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class Player : DogeGameBehavior
	{
		private UnityEngine.UI.Image image;

		public Sprite dogeza0;
		public Sprite dogeza1;
		public Sprite dogeza2;
		public Sprite stand0;
		public Sprite attack0;
		public Sprite attack1;

		public PlayerID playerID = PlayerID.Unknown;

		private bool isAttack = false;
		private uint attackIndex = 0;

		public GameObject SongenDownEffect;
		private GameObject MySongenDownEffect = null;
		private bool isDogeza = false;
		private bool isDogezaDowing = false;

		public float SongenDownTimerInit = 0.1f;
		private float SongenDownTimer = 0.1f;

		public float SongenPointMax = 100;
		private float SongenPointValue = 0;
		public float SongenPointDownSpeed = 1.0f;
		public UnityEngine.UI.Text DebugText;

		void InitSongenValue()
		{
			Debug.Assert(SongenPointMax > 0);
			SongenPointValue = SongenPointMax;
		}

		void InitSongenDownTimer()
		{
			SongenDownTimer = SongenDownTimerInit;
			isDogeza = true;
			isDogezaDowing = false;
		}

		private bool canSongenDown = false;
		void OnStartGame()
		{
			canSongenDown = true;
		}

		void UpdateSongenDown()
		{
			if (!canSongenDown)
			{
				return;
			}

			if (Input.Vertical == 0)
			{
				if (!isDogeza)
				{
					InitSongenDownTimer();
				}
			}
			else
			{
				isDogeza = false;
				isDogezaDowing = false;
				if (MySongenDownEffect != null)
				{
					Destroy(MySongenDownEffect);
					MySongenDownEffect = null;
				}
				return;
			}

			if (!isDogezaDowing && isDogeza)
			{
				SongenDownTimer -= Time.deltaTime;
				if (SongenDownTimer <= 0.0f)
				{
					isDogezaDowing = true;
					MySongenDownEffect = (GameObject)Instantiate(SongenDownEffect);

					Vector3 pos;
					if (playerID == PlayerID.P1)
					{
						pos = new Vector3(0.44f, -9.64f, 165.0f);
					}
					else
					{
						pos = new Vector3(8.8f, -9.64f, 165.0f);
					}
					MySongenDownEffect.transform.position = pos;
				}
			}

			if (isDogezaDowing)
			{
				var songenDelta = SongenPointDownSpeed * Time.deltaTime;
				SongenPointValue -= songenDelta;
				DebugText.text = SongenPointValue.ToString("F3");
			}
		}

		override protected void Start()
		{
			base.Start();

			Debug.Assert(playerID != PlayerID.Unknown);

			image = GetComponent<UnityEngine.UI.Image>();
			Debug.Assert(image != null);

			Debug.Assert(SongenDownEffect != null);

			InitSongenValue();

			Debug.Assert(DebugText != null);
		}

		private Input Input
		{
			get { return InputManager.get(playerID); }
		}

		void Update()
		{
			if (isAttack)
			{
				UpdateAttack();
			}
			else
			{
				UpdateDogeza();
				UpdateSongenDown();
			}
		}

		void UpdateAttack()
		{
			var size = new Vector2(360, 385);

			var pattern = new Sprite[]{
				attack0,
				attack0,
				attack0,
				attack1,
				attack1,
				attack1,
			};

			ChangePattern(pattern[attackIndex], size);

			++attackIndex;
			if (attackIndex >= pattern.Length)
			{
				isAttack = false;
			}
		}

		void UpdateDogeza()
		{
			var vertical = Input.Vertical;
			var size = new Vector2(360, 385);

			if (vertical <= 0.25f)
			{
				ChangePattern(dogeza0, size);
			}
			else if (vertical <= 0.50f)
			{
				ChangePattern(dogeza1, size);
			}
			else if (vertical <= 0.75f)
			{
				ChangePattern(dogeza2, size);
			}
			else
			{
				ChangePattern(stand0, size);
			}

			if (Input.Attack)
			{
				if (vertical >= 0.975f)
				{
					isAttack = true;
					attackIndex = 0;
				}
				else
				{
					MissGenerator.generate(playerID);
				}
			}
		}

		void ChangePattern(Sprite pattern, Vector2 size)
		{
			image.sprite = pattern;
			image.rectTransform.sizeDelta = size;
		}
	}
}
