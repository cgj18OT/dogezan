using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miss2 : MonoBehaviour
{
	public float alphaTimer = 1;
	private float timer = 1;
	private UnityEngine.UI.Image image;
	private UnityEngine.UI.Text[] texts;

	private string _text;
	public string text
	{
		get { return _text; }
		set
		{
			_text = value;
			if (texts == null)
			{
				texts = GetComponentsInChildren<UnityEngine.UI.Text>();
			}
			foreach (var t in texts)
			{
				t.text = value;
			}
		}
	}

	void Start()
	{
		if (texts == null)
		{
			texts = GetComponentsInChildren<UnityEngine.UI.Text>();
		}
		Debug.Assert(texts.Length == 2);
		timer = alphaTimer;
	}

	void Update()
	{
		timer -= Time.deltaTime;

		foreach (var t in texts)
		{
			var color = t.color;
			color.a = timer / alphaTimer;
			t.color = color;
		}

		if (timer <= 0)
		{
			Destroy(gameObject);
		}
	}
}
