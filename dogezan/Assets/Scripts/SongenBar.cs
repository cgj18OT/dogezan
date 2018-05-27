using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongenBar : MonoBehaviour {

	public float MaxValue = 100.0f;
	public float Value = 100.0f;
	public GameObject ShadowObject;
	public GameObject ShadowObject2;
	float value = 100.0f;
	float shadowValue = 100.0f;
	float shadowValue2 = 100.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		value = value - (value - Value) * 0.1f;
		SetSize (gameObject, value);

		shadowValue = shadowValue - (shadowValue - Value) * 0.05f;
		SetSize (ShadowObject, shadowValue);

		shadowValue2 = shadowValue2 - (shadowValue2 - Value) * 0.035f;
		SetSize (ShadowObject2, shadowValue2);
	}

	void SetSize(GameObject go, float val)
	{
		var trans = go.transform as RectTransform;
		trans.sizeDelta = new Vector2 (400 * (val / MaxValue), trans.sizeDelta.y);
		Debug.Log (go.name + " : " + value.ToString ());
	}

	public void Reset()
	{
		Value = MaxValue;
		value = MaxValue;
		shadowValue = MaxValue;
		shadowValue2 = MaxValue;
		SetSize (gameObject, value);
		SetSize (ShadowObject, shadowValue);
		SetSize (ShadowObject2, shadowValue2);
	}
}
