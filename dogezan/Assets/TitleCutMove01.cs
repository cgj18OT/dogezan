using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCutMove01 : MonoBehaviour {
	public float Delay1 = 1;
	public float Time1 = 1;
	public iTween.EaseType EaseType1=iTween.EaseType.linear;
	public float PositionY1 = -200;

	public float Delay2 = 1;
	public float Time2 = 1;
	public iTween.EaseType EaseType2=iTween.EaseType.linear;
	public float PositionY2 = -200;

//	public float Dela

	// Use this for initialization
	void Start () {
		var image = this.gameObject.GetComponent<UnityEngine.UI.Image> ();
		image.enabled = true;
		iTween.MoveTo (this.gameObject, iTween.Hash (
			"position", new Vector3 (this.gameObject.transform.position.x, 
									PositionY1, 
									this.gameObject.transform.position.z),
			"easeType", EaseType1,
			"delay", Delay1,
			"time", Time1,
			"oncomplete", "OncompleteHandler"
		));
	}

	void OncompleteHandler() {
		iTween.MoveTo (this.gameObject, iTween.Hash (
			"position", new Vector3 (this.gameObject.transform.position.x, 
				PositionY2, 
				this.gameObject.transform.position.z),
			"easeType", EaseType2,
			"delay", Delay2,
			"time", Time2,
			"oncomplete", "OncompleteHandler"
		));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
