using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace doge
{
	public class Story : MonoBehaviour
	{
		void Update()
		{
			if (UnityEngine.Input.anyKeyDown)
			{
				SceneManager.LoadScene("Title");
			}
		}
	}
}
