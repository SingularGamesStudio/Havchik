﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class city : MonoBehaviour {
	public GameObject citym;
	public main.dial d;
	public int race;
	public List<main.dial> l;
	public GameObject leftup;
	public GameObject rightdown;
	public List<int> alldef = new List<int> ();
	public List<GameObject> uns=new List<GameObject>();
	public List<GameObject> unsotkat=new List<GameObject>();
	public GameObject sppos;
	public GameObject flag;
	public bool inbattle=false;
	public float curtimeout;
	public float curtimeout1;
	public float curtimeout2;
	public float maxbatrasst=10;
	public int resdob;
	public List<int> resin=new List<int>();
	public List<int> resincol=new List<int>();
	public List<int> unitsin=new List<int>();
	public int resspeed;
	GameObject h;
	public bool inbattle1;
	public System.Random rnd=new System.Random();
	public bool actmain=false;
	public GameObject posol;
	public city mainhouse;
	public bool maincity;
	public bool grabbed=false;
	public bool canbedest;
	public int destroyglsob;
	public bool hasnoflag;
	public bool dobsomething;
	public bool nowhasarrow;
	public GameObject  arrow;
	public int otnosh;
	public int num;
	public bool inbattleii;
	public int atk;
	// Use this for initialization
	void Start () {
		if (actmain&&!hasnoflag)
			flag.GetComponent<SpriteRenderer> ().sortingOrder = 32767;
	}
	public void startbtlii(int race){
		inbattleii = true;
	}
	// Update is called once per frame
	void Update () {
		if (main._m.ingame) {
			if ((inbattle||inbattleii) && !inbattle1) {
				inbattle1 = true;
				if (main._m.races [race].com.nowin == num) {
					h = Instantiate (main._m.compref);
					h.GetComponent<mainunit> ().num = main._m.races[race].com.army[0].mainunit;
					h.GetComponent<mainunit> ().race = race;
					h.GetComponent<mainunit> ().m = 0;
					h.transform.position = gameObject.transform.position;
					h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = main._m.units [h.GetComponent<mainunit> ().num - 1].sp;
					main._m.races [race].com.army [0].comgo = h;

					for (int j = 0; j < main._m.races[race].com.army[0].units.Count; j++) {
								h = Instantiate (main._m.unitpref);
						h.GetComponent<uniter> ().topresl = main._m.races[race].com.army[0].comgo;
								h.GetComponent<uniter> ().m = 0;
						h.GetComponent<uniter> ().num = main._m.races[race].com.army[0].units [j];
						h.GetComponent<uniter> ().fly = main._m.units [main._m.races[race].com.army[0].units [j] - 1].fly;
						h.transform.position = main._m.races[race].com.army[0].comgo.transform.position;
						h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = main._m.units [main._m.races[race].com.army[0].units [j] - 1].sp;
						main._m.races[race].com.army[0].inst.Add (h);
							}
					main._m.races[race].com.tselfor="defend";
					main._m.races [race].com.tsel = gameObject;
					main._m.races [race].com.way.Add(gameObject.transform.transform.position);
				}
			}
			if (actmain && !nowhasarrow && Vector3.Distance (main._m.teams [0].comgo.transform.position, gameObject.transform.position) < 3) {
				nowhasarrow = true;
				arrow = Instantiate (main._m.arrow);
				arrow.transform.position = gameObject.transform.position;
				arrow.transform.position = arrow.transform.position + new Vector3 (0, -gameObject.transform.lossyScale.y / 4, 0);
			} else if (actmain && nowhasarrow && Vector3.Distance (main._m.teams [0].comgo.transform.position, gameObject.transform.position) >= 3) {
				nowhasarrow = false;
				Destroy (arrow);
			}
			if(dobsomething)
			curtimeout1 += Time.deltaTime;
			curtimeout += Time.deltaTime;
			if (unsotkat.Count < alldef.Count) {
				h = Instantiate (main._m.defer);
				h.GetComponent<defender> ().race = race;
				h.GetComponent<defender> ().num = alldef [uns.Count];
				h.GetComponent<defender> ().hp = main._m.units [alldef [uns.Count]-1].hp;
				h.GetComponent<defender>().fly=main._m.units [alldef [uns.Count]-1].fly;
				h.GetComponent<defender> ().speed = 0.01f;
				h.GetComponent<defender> ().attrasst = 3;
				h.GetComponent<defender> ().maxrtop = 0.5f;
				h.GetComponent<defender> ().anrazn = 0.2f;
				int u = rnd.Next (7);
				if(u==0){
					h.GetComponent<defender>().type="stay";
				} else if(u==1){
					h.GetComponent<defender>().type="presl";
				} else if(u==2){
					h.GetComponent<defender>().type="patrul";
					int y = rnd.Next (2, 10);
					for (int i = 0; i < y; i++) {
						GameObject hh;
						hh = Instantiate (main._m.emp);
						hh.transform.SetParent (main._m.defall.transform);
						hh.transform.position = new Vector3 (rnd.Next ((int)(leftup.transform.position.x * 100), (int)(rightdown.transform.position.x * 100)), rnd.Next ((int)(rightdown.transform.position.y * 100), (int)(leftup.transform.position.y * 100)), 0);
						hh.transform.position /= 100;
						h.GetComponent<defender> ().positions.Add (hh);
					}
				} else if(u==3){
					h.GetComponent<defender>().type="staypresl";
				} else if(u==4){
					h.GetComponent<defender>().type="staypreslinf";
				} else if(u==5){
					h.GetComponent<defender>().type="patrulpresl";
					int y = rnd.Next (2, 10);
					for (int i = 0; i < y; i++) {
						GameObject hh;
						hh = Instantiate (main._m.emp);
						hh.transform.SetParent (main._m.defall.transform);
						hh.transform.position = new Vector3 (rnd.Next ((int)(leftup.transform.position.x * 100), (int)(rightdown.transform.position.x * 100)), rnd.Next ((int)(rightdown.transform.position.y * 100), (int)(leftup.transform.position.y * 100)), 0);
						hh.transform.position /= 100;
						h.GetComponent<defender> ().positions.Add (hh);
					}
				} else if(u==6){
					h.GetComponent<defender>().type="patrulpreslinf";
					int y = rnd.Next (2, 10);
					for (int i = 0; i < y; i++) {
						GameObject hh;
						hh = Instantiate (main._m.emp);
						hh.transform.SetParent (main._m.defall.transform);
						hh.transform.position = new Vector3 (rnd.Next ((int)(leftup.transform.position.x * 100), (int)(rightdown.transform.position.x * 100)), rnd.Next ((int)(rightdown.transform.position.y * 100), (int)(leftup.transform.position.y * 100)), 0);
						hh.transform.position /= 100;
						h.GetComponent<defender> ().positions.Add (hh);
					}
				}
				h.transform.position = new Vector3 (rnd.Next ((int)(leftup.transform.position.x*100), (int)(rightdown.transform.position.x*100)), rnd.Next ((int)(rightdown.transform.position.y*100), (int)(leftup.transform.position.y*100)), 0);
				h.transform.position /= 100;
				h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = main._m.units [alldef [uns.Count]-1].sp;
				GameObject h1 = Instantiate (h);
				h1.transform.SetParent (main._m.defall.transform);
				h.transform.SetParent (main._m.defall.transform);
				h.SetActive (false);
				h1.SetActive (false);
				uns.Add (h);
				unsotkat.Add (h1);
			}






			if (curtimeout > 0.05f) {
				if (canbedest && main._m.globalsob [destroyglsob] == 1) {
					Destroy (gameObject);
				}
				if (uns.Count > 0) {
					for (int i = 0; i < uns.Count; i++) {
						if (uns [i] == null) {
							Destroy (unsotkat [i]);
							unsotkat.RemoveAt (i);
							uns.RemoveAt (i);
							if(alldef.Count>i)
							alldef.RemoveAt (i);
						}
					}
				} else {
					if (inbattle) {
						main._m.inbattle = false;
						inbattle = false;
						inbattle1 = false;
						for (int i = 0; i < uns.Count; i++) {
							uns [i].SetActive (false);
							uns [i].transform.position = unsotkat [i].transform.position;
							uns [i].GetComponent<defender> ().hp = unsotkat [i].GetComponent<defender> ().hp;
							uns [i].GetComponent<defender> ().type = unsotkat [i].GetComponent<defender> ().type;
						}
					}
				}
				bool k = true;
				for (int i = 0; i < 1; i++) {
					if (main._m.teams [0].mainunit != -1)
					if (Vector3.Distance (main._m.teams [0].comgo.transform.position, gameObject.transform.position) < maxbatrasst)
						k = false;
				}
				if (k) {
					if (inbattle) {
						inbattle1 = false;
						main._m.inbattle = false;
						inbattle = false;
						for (int i = 0; i < uns.Count; i++) {
							uns [i].SetActive (false);
							uns [i].transform.position = unsotkat [i].transform.position;
							uns [i].GetComponent<defender> ().hp = unsotkat [i].GetComponent<defender> ().hp;
							uns [i].GetComponent<defender> ().type = unsotkat [i].GetComponent<defender> ().type;
						}
					}
				}
				curtimeout = 0;
				if (actmain && !hasnoflag)
					flag.GetComponent<SpriteRenderer> ().sprite = main._m.races [race].flag;
			}
			if(dobsomething)
			if (curtimeout1 > 20) {
				resincol [resin.IndexOf (resdob)] += rnd.Next (resspeed);
				curtimeout1 = 0;

			}
		}
	}
	void OnMouseDown(){
		if(!citym.GetComponent<city>().inbattle)
			if(!main._m.dialog.activeSelf)
		if(!main._m.iswikiopen)
		main._m.townenter (citym);
	}
}
