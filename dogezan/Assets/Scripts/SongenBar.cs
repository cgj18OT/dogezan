using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongenBar : MonoBehaviour {

	public float MaxValue = 100.0f;
	public float Value = 100.0f;
	public GameObject ShadowObject;
	public GameObject ShadowObject2;
	public ParticleSystem Particle;
	float value = 100.0f;
	float shadowValue = 100.0f;
	float shadowValue2 = 100.0f;
	public float ParticlePosMin = 0;
	public float ParticlePosMax = 400;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		value = value - (value - Value) * 0.1f;
		SetSize (gameObject, value);
		if (Mathf.Abs (value - Value) < 0.3f) {
			if (Particle.isEmitting)
				Particle.Stop (true, ParticleSystemStopBehavior.StopEmitting);
		} else {
			if (!Particle.isEmitting)
				Particle.Play (true);
		}
		var ppos = Particle.gameObject.transform.localPosition;
		ppos.x = (ParticlePosMax - ParticlePosMin) * (value / MaxValue);
		Particle.gameObject.transform.localPosition = ppos;

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
