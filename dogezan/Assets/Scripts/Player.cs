using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class Player : DogeGameBehavior
	{
		private UnityEngine.UI.Image image;

		public Sprite pattern00;
		public Sprite pattern05;
		public Sprite pattern10;

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
			if (vertical <= 0.33f)
			{
				ChangePattern(pattern00, new Vector2(266, 124));
			}
			else if (vertical <= 0.66f)
			{
				ChangePattern(pattern05, new Vector2(257, 238));
			}
			else
			{
				ChangePattern(pattern10, new Vector2(237, 371));
			}
		}

		void ChangePattern(Sprite pattern, Vector2 size)
		{
			image.sprite = pattern;
			image.rectTransform.sizeDelta = size;
		}
	}
}
