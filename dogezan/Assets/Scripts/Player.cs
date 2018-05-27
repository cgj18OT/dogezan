using System.Collections;
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
		[HideInInspector]
		[System.NonSerialized]
		public bool isDogeza = false;
		private bool isDogezaDowing = false;

		public float SongenDownTimerInit = 0.1f;
		private float SongenDownTimer = 0.1f;

		public float SongenPointMax = 100;
		[HideInInspector]
		[System.NonSerialized]
		public float SongenPointValue = 0;
		public float SongenPointDownSpeed = 1.0f;
		public SongenBar SongenBar;
		public UnityEngine.UI.Text DebugText;

		[HideInInspector]
		[System.NonSerialized]
		public bool AlwaysDogeza = true;

		[HideInInspector]
		[System.NonSerialized]
		public bool KillYou = false;

		public float AttackMissDamage = 0;

		private UnityEngine.UI.Image[] images;

		public AudioClip AudioChangePattern;
		public AudioClip AudioEnemyKill;
		public AudioClip AudioKaraburi;
		public AudioClip AudioDogezaAttack;
		private AudioSource AudioSource;

		private Vector3 InitPos;

		public GameObject LoserEffect;

		Player Enemy
		{
			get
			{
				if (playerID == PlayerID.P1)
				{
					return Player2;
				}
				else
				{
					return Player1;
				}
			}
		}

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
			AlwaysDogeza = false;
		}

		private bool canSongenDown = false;
		void OnStartGame()
		{
			canSongenDown = true;
		}

		void OnEndGame()
		{
			enabled = false;
			DebugText.text = SongenPointValue.ToString("F3");
			EndDogeza();
		}

		void EndDogeza()
		{
			isDogeza = false;
			isDogezaDowing = false;
			if (MySongenDownEffect != null)
			{
				Destroy(MySongenDownEffect);
				MySongenDownEffect = null;
			}
		}

		public void Unko()
		{
			var unko = (GameObject)Instantiate(LoserEffect, CanvasRoot.transform);

			unko.transform.localPosition = new Vector3 (
				image.transform.localPosition.x,
				unko.transform.localPosition.y,
				image.transform.localPosition.z);
		}

		void UpdateSongenDown()
		{
			if (!canSongenDown)
			{
				return;
			}

			if (Input.Vertical <= 0.01f)
			{
				if (!isDogeza)
				{
					InitSongenDownTimer();
				}
			}
			else
			{
				EndDogeza();
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
					float z = 100.0f;
					if (playerID == PlayerID.P1)
					{
						pos = new Vector3(0.44f, -9.64f, z);
					}
					else
					{
						pos = new Vector3(8.8f, -9.64f, z);
					}
					MySongenDownEffect.transform.position = pos;
				}
			}

			if (isDogezaDowing)
			{
				var songenDelta = SongenPointDownSpeed * Time.deltaTime;
				AddSongenValue(-songenDelta);
			}
		}

		void OnSongenPointValueIsZero()
		{
			SongenPointValue = 0.0f;
			SongenBar.Value = 0;
			StateRoot.BroadcastMessage("OnEndGame");
			CanvasRoot.BroadcastMessage("OnEndGame");
		}

		public void AddSongenValue(float value)
		{
			if (canSongenDown)
			{
				SongenPointValue += value;
				SongenBar.Value = SongenPointValue;

				var pos = InitPos + new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
				image.rectTransform.localPosition = pos;

				if (SongenPointValue <= 0.0f)
				{
					OnSongenPointValueIsZero();
				}
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

			Debug.Assert(SongenBar != null);
			SongenBar.MaxValue = SongenPointMax;
			SongenBar.Value = SongenPointMax;

			images = GetComponentsInChildren<UnityEngine.UI.Image>();

			AudioSource = GetComponent<AudioSource>();
			Debug.Assert(AudioSource != null);

			InitPos = image.rectTransform.localPosition;
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

			DebugText.text = SongenPointValue.ToString("F3");
			SongenBar.Value = SongenPointValue;

			_oldPatternChangeTimer += Time.deltaTime;
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
				ChangePattern(dogeza0, size, AudioChangePattern, 0.15f);
			}
			else if (vertical <= 0.50f)
			{
				ChangePattern(dogeza1, size, AudioChangePattern, 0.15f);
			}
			else if (vertical <= 0.75f)
			{
				ChangePattern(dogeza2, size, AudioChangePattern, 0.15f);
			}
			else
			{
				ChangePattern(stand0, size, AudioChangePattern, 0.15f);
			}

			if (Input.Attack)
			{
				if (vertical >= 0.975f)
				{
					isAttack = true;
					attackIndex = 0;

					if (Enemy.isDogeza)
					{
						MissGenerator.generate(playerID, "すまぬ……");
						AddSongenValue(-AttackMissDamage);
						AudioSource.volume = 1.0f;
						AudioSource.PlayOneShot(AudioDogezaAttack);
					}
					else
					{
						if (canSongenDown)
						{
							MissGenerator.generate(playerID, "死になはれ");
							AudioSource.PlayOneShot(AudioEnemyKill);
							KillYou = true;
						}
						else
						{
							MissGenerator.generate(Enemy.playerID, "やめて");
							AudioSource.PlayOneShot(AudioKaraburi);
						}

						Enemy.AddSongenValue(-100000);
						AudioSource.volume = 1.0f;
					}
				}
				else
				{
					if (canSongenDown)
					{
						MissGenerator.generate(playerID, "不覚…！");
					}
					else
					{
						MissGenerator.generate(Enemy.playerID, "やめて");
					}

					AddSongenValue(-AttackMissDamage);
					AudioSource.volume = 1.0f;
					AudioSource.PlayOneShot(AudioKaraburi);
				}
			}
		}

		private Sprite _oldPattern = null;
		private float _oldPatternChangeTimer = 0.0f;
		void ChangePattern(Sprite pattern, Vector2 size, AudioClip clip = null, float volume = 1.0f)
		{
			if (_oldPattern == pattern)
			{
				return;
			}
			_oldPattern = pattern;

			foreach (var image in images)
			{
				image.sprite = pattern;
				image.rectTransform.sizeDelta = size;
			}

			if (clip != null && _oldPatternChangeTimer >= 0.1f)
			{
				AudioSource.volume = volume;
				AudioSource.PlayOneShot(clip);
				_oldPatternChangeTimer = 0.0f;
			}
		}
	}
}
