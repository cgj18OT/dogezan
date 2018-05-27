using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour {
	public float Delay = 1.0f;
	public float FadeTime = 3.0f;
	public bool FadeOut = false;

	float wait = 0.0f;
	float timer = 0.0f;

	// Use this for initialization
	void Start () {
		var img = gameObject.GetComponent<Image> ();
		var imgcolor = img.color;
		imgcolor.a = 0;
		img.color = imgcolor;
		
	}
	
	// Update is called once per frame
	void Update () {
		var img = gameObject.GetComponent<Image> ();
		var imgcolor = img.color;

		if (wait < Delay) {
			wait += Time.deltaTime;
			imgcolor.a = 0.0f;
		} else {

			if (timer < FadeTime) {
				timer += Time.deltaTime;
				imgcolor.a = timer / FadeTime;
			} else {
				imgcolor.a = 1.0f;
			}
		}
		if (FadeOut)
			imgcolor.a = 1.0f - imgcolor.a;
		img.color = imgcolor;
	}
}
