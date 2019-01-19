using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learnpods : MonoBehaviour {
	[Multiline]public string s;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter2D(Collider2D coll){
		Debug.Log ("1");
		if (coll.gameObject.name == "commander(Clone)" || coll.gameObject.name == "trig (1)") {
			main._m.learn (s);
			Destroy (gameObject);
		}
	}
}
