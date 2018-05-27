using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour {
	public Text ResultText;
	public GameObject FadeObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKeyDown) {
			FadeObject.SetActive (true);
			Invoke ("NextScene", 2);
		}
	}

	void NextScene()
	{
		SceneManager.LoadScene ("Title");
	}
}
