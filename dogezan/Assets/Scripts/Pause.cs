using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class Pause : MonoBehaviour
	{
		void Update()
		{
			if (UnityEngine.Input.GetButtonDown("Start"))
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
			}
		}
	}
}
