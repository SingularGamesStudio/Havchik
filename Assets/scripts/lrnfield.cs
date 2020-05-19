using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lrnfield : MonoBehaviour {
	public string s;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.name == "commander(Clone)" || coll.gameObject.name == "trig (1)") {
			if (main._m.lrncontroll.now == 1) {
				main._m.lrncontroll.lrn2 (s);
				Destroy (gameObject);
			} else if (main._m.lrncontroll.now == 5) {
				main._m.lrncontroll.lrn1 (main._m.lrncontroll.g5,s);
				Destroy (gameObject);
			}
		}
	}
}
