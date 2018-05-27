using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class Message : MonoBehaviour
	{
		private UnityEngine.UI.Text[] texts;

		public string _text;
		public string text
		{
			get { return _text; }
			set
			{
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
				_fontSize = value;
				foreach (var t in texts)
				{
					t.fontSize = value;
				}
			}
		}

		void Start()
		{
			texts = GetComponentsInChildren<UnityEngine.UI.Text>();
			Debug.Assert(texts.Length == 2);

			text = _text;
			fontSize = _fontSize;
		}

		void Update()
		{
		}
	}
}
