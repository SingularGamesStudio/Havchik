using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anysoundlevel : MonoBehaviour {
	public bool ismusic;
	public int levelset;
	public Sprite sp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnMouseDown(){
		if (ismusic) {
			main._m.musiclevelset (levelset);
		} else {
			main._m.soundlevelset (levelset);
		}
	}
}
