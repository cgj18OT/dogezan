using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class Message : MonoBehaviour
	{
		private UnityEngine.UI.Text[] texts;

		bool isAlphaUpdate = false;

		public void StartAlphaUpdate()
		{
			isAlphaUpdate = true;
		}

		void UpdateAlphaUpdate()
		{
			if (isAlphaUpdate)
			{
				foreach (var t in texts)
				{
					var color = t.color;
					color.a -= Time.deltaTime * 1.0f;
					if (color.a <= 0.0f)
					{
						color.a = 0.0f;
					}
					t.color = color;
				}
			}
		}

		void ResetAlphaUpdate()
		{
			isAlphaUpdate = false;
			texts[0].color = colorBack;
			texts[1].color = colorFront;
		}

		Color colorFront;
		Color colorBack;

		public string _text;
		public string text
		{
			get { return _text; }
			set
			{
				ResetAlphaUpdate();
				_text = value;
				foreach (var t in texts)
				{
					t.text = value;
				}
			}
		}

		public int _fontSize = 100;
		public int fontSize
		{
			get { return _fontSize; }
			set
			{
				ResetAlphaUpdate();
				_fontSize = value;
				foreach (var t in texts)
				{
					t.fontSize = value;
				}
			}
		}

		public Color frontColor
		{
			get { return texts[1].color; }
			set
			{
				texts[1].color = value;
			}
		}

		void Start()
		{
			texts = GetComponentsInChildren<UnityEngine.UI.Text>();
			Debug.Assert(texts.Length == 2);

			colorBack = texts[0].color;
			colorFront = texts[1].color;

			text = _text;
			fontSize = _fontSize;
		}

		void Update()
		{
			UpdateAlphaUpdate();
		}
	}
}
