using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class learnpods : MonoBehaviour {
	[Multiline]public string s;
	public int now=0;
	public List<GameObject> l=new List<GameObject>();
	public GameObject g1;
	public List<GameObject> l2=new List<GameObject>();
	public GameObject g2;
	public GameObject g3;
	public GameObject g4;
	public GameObject g5;
	public GameObject g6;
	public GameObject g7;
	public GameObject g8;
	public GameObject g9;
	public GameObject g10;
	public GameObject g11;
	public Text txtfld;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void lrn1(GameObject g,string ss){
		Transform h = g.transform.parent;
		g.transform.SetParent(l [0].transform.parent);
		txtfld.gameObject.SetActive (true);
		txtfld.text = ss;
		now++;
		l [0].transform.localPosition = g.transform.localPosition- new Vector3(g.GetComponent<RectTransform> ().sizeDelta.x / 2 + 750,0);
		l [1].transform.localPosition = g.transform.localPosition- new Vector3(0,g.GetComponent<RectTransform> ().sizeDelta.y / 2 + 750);
		l [2].transform.localPosition = g.transform.localPosition+ new Vector3(g.GetComponent<RectTransform> ().sizeDelta.x / 2 + 750,0);
		l [3].transform.localPosition = g.transform.localPosition+ new Vector3(0,g.GetComponent<RectTransform> ().sizeDelta.y / 2 + 750);
		g.transform.SetParent(h);
		for (int i = 0; i < 4; i++) {
			l [i].SetActive (true);
		}
	}
	public void lrn2(string ss){
		Transform h = g2.transform.parent;
		g2.transform.SetParent(l2 [0].transform.parent);
		txtfld.gameObject.SetActive (true);
		txtfld.text = ss;
		now++;
		l2 [0].transform.localPosition = g2.transform.localPosition- new Vector3(g2.transform.localScale.x / 2 + 500,0);
		l2 [2].transform.localPosition = g2.transform.localPosition- new Vector3(0,g2.transform.localScale.y / 2 + 500);
		l2 [2].transform.localPosition = g2.transform.localPosition+ new Vector3(g2.transform.localScale.x / 2 + 500,0);
		l2 [3].transform.localPosition = g2.transform.localPosition+ new Vector3(0,g2.transform.localScale.y / 2 + 500);
		g2.transform.SetParent(h);
		for (int i = 0; i < 4; i++) {
			l2 [i].SetActive (true);
		}
	}
	public void ext1(){
		for (int i = 0; i < 4; i++) {
			l [i].SetActive (false);
		}
		txtfld.gameObject.SetActive (false);
	}
	public void ext2(){
		for (int i = 0; i < 4; i++) {
			l2 [i].SetActive (false);
		}
		txtfld.gameObject.SetActive (false);
	}
	public void ext3(){
		for (int i = 0; i < 4; i++) {
			l [i].SetActive (false);
		}
		txtfld.gameObject.SetActive (false);
		lrn1 (g4, "Нажмите на кнопку <Сделать главным>, чтобы сделать юнита командиром. Нажмите в любое другое место, чтобы привязать его к точке.");
	}
	public void ext4(){
		for (int i = 0; i < 4; i++) {
			l [i].SetActive (false);
		}
		txtfld.gameObject.SetActive (false);
		now = 5;
	}
	public void ext6(){
		for (int i = 0; i < 4; i++) {
			l [i].SetActive (false);
		}
		txtfld.gameObject.SetActive (false);
		lrn1 (g6, "Нажмите на кнопку слева для выбора раздела викии");
	}
	public void ext7(){
		for (int i = 0; i < 4; i++) {
			l [i].SetActive (false);
		}
		txtfld.gameObject.SetActive (false);
		lrn1 (g7, "Нажмите на кнопку слева для выбора статьи викии");
	}
	public void ext8(){
		for (int i = 0; i < 4; i++) {
			l [i].SetActive (false);
		}
		txtfld.gameObject.SetActive (false);
	}
	public void ext11(){
		for (int i = 0; i < 4; i++) {
			l [i].SetActive (false);
		}
		txtfld.gameObject.SetActive (false);
	}
}
