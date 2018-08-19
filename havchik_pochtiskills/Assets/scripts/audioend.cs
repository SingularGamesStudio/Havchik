using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioend : MonoBehaviour {
	public AudioSource aud;
	float curt = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		curt += Time.deltaTime;
		if (curt > 0.5f) {
			if (!aud.isPlaying)
				Destroy (gameObject);
			curt = 0;
		}
	}
}
