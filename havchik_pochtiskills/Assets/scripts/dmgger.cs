using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgger : MonoBehaviour {
	public int num;
	public int race;
	public int dmg;
	public bool heal = false;
	public bool rage = false;
	public bool strikeenemy=false;
	public GameObject strike;
	public bool destroy;
	public float timeleast;
	public float curtimeout = 0;
	public float curtimeout1 = 0;
	public SpriteRenderer flag;
	public float curtimeout2 = 0;
	public List<Sprite> anim;
	public int state = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (destroy) {
			curtimeout += Time.deltaTime;
			if (curtimeout >= timeleast) {
				Destroy (gameObject);
			}
		}
		curtimeout1 += Time.deltaTime;
		if (curtimeout1 > 0.4f) {
			curtimeout1 = 0;
			state = (state + 1) % anim.Count;
			gameObject.GetComponent<SpriteRenderer> ().sprite = anim [state];
		}
		curtimeout2 += Time.deltaTime;
		if (curtimeout2 > 0.5f) {
			flag.sprite = main._m.races [race].flag;
			curtimeout2 = 0;
		}
	}
}
