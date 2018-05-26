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

		public PlayerID playerID = PlayerID.Unknown;

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
				MissGenerator.generate(playerID);
			}
		}

		void ChangePattern(Sprite pattern, Vector2 size)
		{
			image.sprite = pattern;
			image.rectTransform.sizeDelta = size;
		}
	}
}
