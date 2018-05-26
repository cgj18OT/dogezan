using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour {
	public float Delay = 1.0f;
	public float FadeTime = 3.0f;

	float wait = 0.0f;
	float timer = 0.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		var txt = gameObject.GetComponent<Text> ();
		var txtcolor = txt.color;

		if (wait < Delay) {
			wait += Time.deltaTime;
			txtcolor.a = 0.0f;
		} else {

			if (timer < FadeTime) {
				timer += Time.deltaTime;
				txtcolor.a = timer / FadeTime;
			} else {
				txtcolor.a = 1.0f;
			}
		}
		txt.color = txtcolor;
	}
}
