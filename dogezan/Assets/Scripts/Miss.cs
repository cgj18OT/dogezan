using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miss : MonoBehaviour {
	public float alphaTimer = 1;
	private float timer = 1;
	private UnityEngine.UI.Image image;
	private Color imageColor;

	void Start () {
		image = GetComponent<UnityEngine.UI.Image>();
		Debug.Assert(image != null);
		imageColor = image.color;

		timer = alphaTimer;
	}

	void Update () {
		timer -= Time.deltaTime;
		imageColor.a = timer / alphaTimer;
		image.color = imageColor;

		if (timer <= 0)
		{
			Destroy(gameObject);
		}
	}
}
