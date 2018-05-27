using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zangeki : MonoBehaviour {

	public Image Base;
	public Image Shadow1;
	public Image Shadow2;
	public bool Left = true;

	struct Data
	{
		public float delay;
		public float timer;
		public float x;
		public float w;
		public Image img;
		public bool Left;

		public void update()
		{
			timer += Time.deltaTime;

			var t = timer - delay;
			if (t < 0.0f || t > 0.2f) {
				img.enabled = false;
				return;
			}
			float maxw = 400.0f;
			img.enabled = true;
			if (t < 0.1f) {
				x = 0;
				w = (t / 0.1f) * maxw;
			} else if (t < 0.2f) {
				w = maxw - ((t-0.1f)/0.1f) * maxw;
				x = ((t-0.1f)/0.1f) * maxw;
				if (Left)
					x = -x;
			}

			var trans = img.gameObject.transform as RectTransform;
			var pos = trans.localPosition;
				pos.x = x;
			trans.localPosition = pos;

			if (Left) {
				var rot = trans.localRotation;
				Quaternion quat = new Quaternion ();
				quat.eulerAngles = new Vector3(0, 0, 180);
				trans.localRotation = quat;
			}

			var size = trans.sizeDelta;
				size.x = w;
			trans.sizeDelta = size;
		}
	};
	Data DataBase;
	Data DataShadow1;
	Data DataShadow2;

	// Use this for initialization
	void Start () {
		DataBase.timer = 0;
		DataShadow1.timer = 0;
		DataShadow2.timer = 0;

		DataBase.img = Base;
		DataShadow1.img = Shadow1;
		DataShadow2.img = Shadow2;

		DataBase.delay = 0;
		DataShadow1.delay = 0.05f;
		DataShadow2.delay = 0.08f;

		DataBase.Left = Left;
		DataShadow1.Left = Left;
		DataShadow2.Left = Left;
	}
	
	// Update is called once per frame
	void Update () {
		DataBase.update ();
		DataShadow1.update ();
		DataShadow2.update ();

		if (DataShadow2.timer > 0.5f) {
			GameObject.Destroy (gameObject);
		}
	}
}
