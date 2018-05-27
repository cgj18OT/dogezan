using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DescriptionScene : MonoBehaviour {
	public GameObject Fade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var abtext = GameObject.Find ("AnyButton").GetComponent<Text> ();
		if (abtext.color.a > 0.9 && Input.anyKeyDown) {
			Fade.SetActive (true);
			Invoke ("NextScene", 1.5f);
		}
	}

	void NextScene()
	{
		SceneManager.LoadScene ("Game");
	}
}
