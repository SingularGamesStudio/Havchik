using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitresize : MonoBehaviour {
	public RectTransform up;
	public RectTransform cn;
	// Use this for initialization
	void Start () {
		float a = cn.sizeDelta.y - up.sizeDelta.y;
		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (a, a);
		gameObject.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (a / 2, a / 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
