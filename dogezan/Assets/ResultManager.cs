using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using doge;

public class ResultManager : MonoBehaviour {
	public Text ResultText;
	public Text ScoreText;
	public GameObject FadeObject;
	public Image Unn1;
	public Image Unn2;
	float wait = 0.0f;

	// Use this for initialization
	void Start () {
		switch (GameResultData.Reason) {
		case EndReason.SongenIsZero:
			{
				var img1 = GameObject.Find ("ResultDogeza").GetComponent<Image> ();
				var img2 = GameObject.Find ("ResultKill").GetComponent<Image> ();
				var img3 = GameObject.Find ("ResultChan").GetComponent<Image> ();
				img1.enabled = true;
				img2.enabled = false;
				img3.enabled = false;
			}
			break;
		case EndReason.Killed:
			{
				var img1 = GameObject.Find ("ResultDogeza").GetComponent<Image> ();
				var img2 = GameObject.Find ("ResultKill").GetComponent<Image> ();
				var img3 = GameObject.Find ("ResultChan").GetComponent<Image> ();
				img1.enabled = false;
				img2.enabled = true;
				img3.enabled = false;
			}
			break;
		}


		switch (GameResultData.Result) {
		case PlayerID.P1:
			ResultText.text = "左の者の勝利です！" + System.Environment.NewLine
			+ System.Environment.NewLine;
			ScoreText.text = "左の者　尊厳 : " + (GameResultData.P1.SongenValue / 100.0f).ToString ("P0") + System.Environment.NewLine
			+ "右の者　尊厳 : ";
			Unn1.enabled = false;
			Unn2.enabled = true;
			break;
		case PlayerID.P2:
			ResultText.text = "右の者の勝利です！" + System.Environment.NewLine
			+ System.Environment.NewLine;
			ScoreText.text = "左の者　尊厳 : " + System.Environment.NewLine
				+ "右の者　尊厳 : " + (GameResultData.P2.SongenValue / 100.0f).ToString ("P0") ;
			Unn1.enabled = true;
			Unn2.enabled = false;
			break;
		default:
			ResultText.text = "引き分け・・・" + System.Environment.NewLine
			+ System.Environment.NewLine
			+ "二人の尊厳は失われた";

			ScoreText.text = "左の者　尊厳 : " + System.Environment.NewLine
			+ "右の者　尊厳 : ";
			Unn1.enabled = true;
			Unn2.enabled = true;
			{
				var img1 = GameObject.Find ("ResultDogeza").GetComponent<Image> ();
				var img2 = GameObject.Find ("ResultKill").GetComponent<Image> ();
				var img3 = GameObject.Find ("ResultChan").GetComponent<Image> ();
				img1.enabled = false;
				img2.enabled = false;
				img3.enabled = true;
			}
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		wait += Time.deltaTime;
		if (UnityEngine.Input.anyKeyDown && wait > 5) {
			FadeObject.SetActive (true);
			Invoke ("NextScene", 2);
		}
	}

	void NextScene()
	{
		SceneManager.LoadScene ("Title");
	}
}
