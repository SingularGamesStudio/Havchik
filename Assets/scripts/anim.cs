using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class anim : MonoBehaviour {
    public Animation a;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!a.isPlaying) {
			a.Play ();
		}
	}
}
