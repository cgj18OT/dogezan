using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoserMotion : MonoBehaviour {

	public float Delay = 1;
	public float Time = 1;
	public iTween.EaseType EaseType=iTween.EaseType.easeOutBounce;
	public float PositionY = -200;

	// Use this for initialization
	void Start () {
		iTween.MoveTo (this.gameObject,
			iTween.Hash (
				"position", new Vector3(gameObject.transform.position.x,
					PositionY,
					gameObject.transform.position.z),
				"easeType", EaseType,
				"delay", Delay,
				"time", Time 
			));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
