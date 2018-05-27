using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {
	public UnityEngine.UI.Text MessageText;

	private bool isEnd = false;

	private float timer = 2.0f;

	void Start () {
		Debug.Assert(MessageText != null);
	}
	
	void Update () {
		if (isEnd)
		{
			timer -= Time.deltaTime;
			if (timer <= 0.0f)
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
			}
		}
	}

	void OnEndGame()
	{
		MessageText.transform.localScale = new Vector3(1, 1, 1);
		MessageText.text = "そこまで！";

		isEnd = true;
	}
}
