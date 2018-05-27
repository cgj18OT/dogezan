using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public class BGM : MonoBehaviour
	{
		AudioSource audioSource;
		public AudioClip clip;

		void Start()
		{
			audioSource = GetComponent<AudioSource>();
			Debug.Assert(audioSource);
		}

		void Update()
		{
		}

		public void Play()
		{
			audioSource.clip = clip;
			audioSource.Play();
		}

		public void Stop()
		{
			audioSource.Stop();
		}
	}
}
