using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DelayAudio : MonoBehaviour {
	public GameObject AudioObject;

	public float Delay = 1.0f;

	// Use this for initialization
	void Start () {
		Invoke ("Play", Delay);
	}
	void Play(){
		AudioObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
