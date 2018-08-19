using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingbuild : MonoBehaviour {
	public int race;
	public SpriteRenderer flag;
	public float albuildtime;
	public float curtimeout = 0;
	public float curtimeout1 = 0;
	public int spawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		curtimeout += Time.deltaTime;
		if (curtimeout > albuildtime) {
			GameObject h = Instantiate (main._m.allbuildings [spawn]);
			h.transform.position = gameObject.transform.position;
			Destroy (gameObject);
		}
		curtimeout1 += Time.deltaTime;
		if (curtimeout1 > 0.5f) {
			flag.sprite = main._m.races [race].flag;
			curtimeout1 = 0;
		}
	}
}
