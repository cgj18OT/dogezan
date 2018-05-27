using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {
	public float Step = 0.05f;
	float alpha = 0.0f;
	public GameObject WhiteFadeObject;

	// Use this for initialization
	void Awake () {
		enabled = false;
		alpha = 0.0f;
		SetAlpha (0);
	}
	bool keyDowned = false;
	
	// Update is called once per frame
	void Update () {
		if (!enabled || keyDowned)
			return;
		
		alpha += Step;
		if (alpha < 0 || alpha > 1) {
			Step = Step * -1;
			alpha += Step;
		}
		SetAlpha (alpha);


		if (Input.anyKeyDown) {
			keyDowned = true;
			SetAlpha (1);
			AudioPlay ("Audio Source3");
			WhiteFadeObject.SetActive (true);
			Invoke ("ChangeScene", 2);
		}
	}

	void ChangeScene()
	{	
		SceneManager.LoadScene ("DogezaChan");
	}

	void SetAlpha(float a)
	{
		var t = GameObject.Find ("ShobuText").GetComponent<Text> ();
		var tc = t.color;
		tc.a = a;
		t.color = tc;

		var ts = GameObject.Find("ShobuTextShadow").GetComponent<Text>();
		var tsc = ts.color;
		tsc.a = a * (165.0f / 256.0f);
		ts.color = tsc;
		
	}

	void AudioPlay(string name){
		var go = GameObject.Find (name);
		if (go != null) {
			var src = go.GetComponent<AudioSource> ();
			if (src != null) {
				src.Play ();
			}
		}
	}
}
