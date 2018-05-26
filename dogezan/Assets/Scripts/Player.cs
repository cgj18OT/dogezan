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

		override protected void Start()
		{
			base.Start();

			Debug.Assert(playerID != PlayerID.Unknown);

			image = GetComponent<UnityEngine.UI.Image>();
			Debug.Assert(image != null);
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
				if (vertical >= 0.95)
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
