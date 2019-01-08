﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class defender : MonoBehaviour {
	public int race;
	public string type;
	public int hp;
	public int num;
	public float curtimeout;
	public float curtimeout1;
	public float curtimeout2;
	public float speed;
	public int nextpoint=0;
	public float attrasst;
	public float maxrtop;
	public List<GameObject> positions=new List<GameObject>();
	public Animation a;
	public bool kill=false;
	public bool kill1=false;
	public int killstate=0;
	public float anrazn=0.1f;
	public bool fly=false;
	public int rpr;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (main._m.ingame) {
			curtimeout += Time.deltaTime;
			if (kill) {
				if (killstate == 4) {
					Destroy (gameObject);
				}
			}
			if (kill1) {
				if (killstate == 4) {
					killstate = 0;
					kill1 = false;
				}
			}
			if (hp <= 0) {
				Destroy (gameObject);
			}
			curtimeout2 += Time.deltaTime;
			if (curtimeout2 > anrazn && (kill || kill1)) {
				if (killstate == 0) {
					gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = main._m.units [num - 1].at1;
					main._m.soundplay (main._m.units [num - 1].attack, gameObject.transform.position.x, gameObject.transform.position.y);
				} else if (killstate == 1) {
					gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = main._m.units [num - 1].at2;
				
				} else if (killstate == 2) {
					gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = main._m.units [num - 1].at3;
				
				} else if (killstate == 3) {
					gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = main._m.units [num - 1].sp;
				
				}
				killstate += 1;
				curtimeout2 = 0;
			}
			if (curtimeout > 0.01f) {
				if (type != "stay") {
					if (type == "presl") {
						if (rpr == 11) {
							transform.Translate ((transform.position - main._m.teams [0].comgo.transform.position) * -speed);
							if (!fly)
								a.Play ();
						} else {
							transform.Translate ((transform.position - main._m.races [rpr].com.army [0].comgo.transform.position) * -speed);
							if (!fly)
								a.Play ();
						}
					} else if (type == "patrul") {
						transform.Translate ((transform.position - positions [nextpoint].transform.position) * -speed);
						if (!fly)
							a.Play ();
					} else if (type == "staypreslinf") {
						if (rpr == 11) {
							if (Vector3.Distance (gameObject.transform.position, main._m.teams [0].comgo.transform.position) < attrasst) {
								transform.Translate ((transform.position - main._m.teams [0].comgo.transform.position) * -speed);
								if (!fly)
									a.Play ();
							}
						} else {
							if (Vector3.Distance (gameObject.transform.position, main._m.races [rpr].com.army [0].comgo.transform.position) < attrasst) {
								transform.Translate ((transform.position - main._m.races [rpr].com.army [0].comgo.transform.position) * -speed);
								if (!fly)
									a.Play ();
							}
						}
					} else if (type == "staypresl") {
						if (rpr == 11) {
							if (Vector3.Distance (gameObject.transform.position, main._m.teams [0].comgo.transform.position) < attrasst) {
								type = "presl";
								transform.Translate ((transform.position - main._m.teams [0].comgo.transform.position) * -speed);
								if (!fly)
									a.Play ();
							}
						} else {
							if (Vector3.Distance (gameObject.transform.position, main._m.races [rpr].com.army [0].comgo.transform.position) < attrasst) {
								type = "presl";
								transform.Translate ((transform.position - main._m.races [rpr].com.army [0].comgo.transform.position) * -speed);
								if (!fly)
									a.Play ();
							}
						}
					} else if (type == "patrulpreslinf") {
						if (rpr == 11) {
							if (Vector3.Distance (gameObject.transform.position, main._m.teams [0].comgo.transform.position) < attrasst) {
								transform.Translate ((transform.position - main._m.teams [0].comgo.transform.position) * -speed);
							} else
								transform.Translate ((transform.position - positions [nextpoint].transform.position) * -speed);
							if (!fly)
								a.Play ();
						} else {
							if (Vector3.Distance (gameObject.transform.position, main._m.races [rpr].com.army [0].comgo.transform.position) < attrasst) {
								transform.Translate ((transform.position - main._m.races [rpr].com.army [0].comgo.transform.position) * -speed);
							} else
								transform.Translate ((transform.position - positions [nextpoint].transform.position) * -speed);
							if (!fly)
								a.Play ();
						}
					} else if (type == "patrulpresl") {
						if (rpr == 11) {
							if (Vector3.Distance (gameObject.transform.position, main._m.teams [0].comgo.transform.position) < attrasst) {
								type = "presl";
								transform.Translate ((transform.position - main._m.teams [0].comgo.transform.position) * -speed);
							} else
								transform.Translate ((transform.position - positions [nextpoint].transform.position) * -speed);
							if (!fly)
								a.Play ();
						} else {
							if (Vector3.Distance (gameObject.transform.position, main._m.races [rpr].com.army [0].comgo.transform.position) < attrasst) {
								type = "presl";
								transform.Translate ((transform.position - main._m.races [rpr].com.army [0].comgo.transform.position) * -speed);
							} else
								transform.Translate ((transform.position - positions [nextpoint].transform.position) * -speed);
							if (!fly)
								a.Play ();
						}
					}
					if (type == "patrulpresl" || type == "patrulpreslinf" || type == "patrul") {
						if (Vector3.Distance (transform.position, positions [nextpoint].transform.position) < maxrtop) {
							nextpoint = (nextpoint + 1) % positions.Count;
						}
					}
				}
				curtimeout = 0;
			}
		}
	}
	public void OnTriggerEnter2D(Collider2D coll){
		if (!kill && !kill1) {
			if (coll.gameObject.tag == "unittrig") {
				if (coll.gameObject.GetComponent<uniter> () != null) {
					if (coll.gameObject.GetComponent<uniter> ().race != race) {
						if (!coll.gameObject.GetComponent<uniter> ().kill && !coll.gameObject.GetComponent<uniter> ().kill1) {
							if (coll.gameObject.GetComponent<uniter> ().race == 11) {
								int hpen = main._m.teams [0].unitshp [main._m.teams [0].inst.IndexOf (coll.gameObject)];
								int hpmy = hp;
								if (main._m.crit [num - 1, coll.gameObject.GetComponent<uniter> ().num - 1] == true)
									hpen = -10;
								if (main._m.crit [coll.gameObject.GetComponent<uniter> ().num - 1, num - 1] == true)
									hpmy = -10;
								while (hpmy > 0 && hpen > 0) {
									hpmy -= main._m.units [coll.gameObject.GetComponent<uniter> ().num - 1].dmg;
									hpen -= main._m.units [num - 1].dmg;
								}
								if (hpmy <= 0) {
									kill = true;
								} else {
									kill1 = true;
									hp = hpmy;
								}
								if (hpen <= 0) {
									coll.gameObject.GetComponent<uniter> ().kill = true;
								} else {
									coll.gameObject.GetComponent<uniter> ().kill1 = true;
									main._m.teams [0].unitshp [main._m.teams [0].inst.IndexOf (coll.gameObject)] = hpen;
								}
							} else {
								int hpen = main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [0].unitshp [main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [0].inst.IndexOf (coll.gameObject)];
								int hpmy = hp;
								if (main._m.crit [num - 1, coll.gameObject.GetComponent<uniter> ().num - 1] == true)
									hpen = -10;
								if (main._m.crit [coll.gameObject.GetComponent<uniter> ().num - 1, num - 1] == true)
									hpmy = -10;
								while (hpmy > 0 && hpen > 0) {
									hpmy -= main._m.units [coll.gameObject.GetComponent<uniter> ().num - 1].dmg;
									hpen -= main._m.units [num - 1].dmg;
								}
								if (hpmy <= 0) {
									kill = true;
								} else {
									kill1 = true;
									hp = hpmy;
								}
								if (hpen <= 0) {
									coll.gameObject.GetComponent<uniter> ().kill = true;
								} else {
									coll.gameObject.GetComponent<uniter> ().kill1 = true;
									main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [0].unitshp [main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [0].inst.IndexOf (coll.gameObject)] = hpen;
								}
							}
						}
					}
				} else if (coll.gameObject.GetComponent<mainunit> () != null) {
					if (coll.gameObject.GetComponent<mainunit> ().race != race) {
						if (!coll.gameObject.GetComponent<mainunit> ().kill && !coll.gameObject.GetComponent<mainunit> ().kill1) {
							if (coll.gameObject.GetComponent<mainunit> ().race == 11) {
								int hpen = main._m.teams [0].mainunithp;
								int hpmy = hp;
								if (main._m.crit [num - 1, coll.gameObject.GetComponent<mainunit> ().num - 1] == true)
									hpen = -10;
								if (main._m.crit [coll.gameObject.GetComponent<mainunit> ().num - 1, num - 1] == true)
									hpmy = -10;
								while (hpmy > 0 && hpen > 0) {
									hpmy -= main._m.units [coll.gameObject.GetComponent<mainunit> ().num - 1].dmg;
									hpen -= main._m.units [num - 1].dmg;
								}
								if (hpmy <= 0) {
									kill = true;
								} else {
									kill1 = true;
									hp = hpmy;
								}
								if (hpen <= 0) {
									curtimeout1 = 1;
									coll.gameObject.GetComponent<mainunit> ().kill = true;
								} else {
									coll.gameObject.GetComponent<mainunit> ().kill1 = true;
									main._m.teams [0].mainunithp = hpen;
								}
							} else {
								int hpen = main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [0].mainunithp;
								int hpmy = hp;
								if (main._m.crit [num - 1, coll.gameObject.GetComponent<mainunit> ().num - 1] == true)
									hpen = -10;
								if (main._m.crit [coll.gameObject.GetComponent<mainunit> ().num - 1, num - 1] == true)
									hpmy = -10;
								while (hpmy > 0 && hpen > 0) {
									hpmy -= main._m.units [coll.gameObject.GetComponent<mainunit> ().num - 1].dmg;
									hpen -= main._m.units [num - 1].dmg;
								}
								if (hpmy <= 0) {
									kill = true;
								} else {
									kill1 = true;
									hp = hpmy;
								}
								if (hpen <= 0) {
									curtimeout1 = 1;
									coll.gameObject.GetComponent<mainunit> ().kill = true;
								} else {
									coll.gameObject.GetComponent<mainunit> ().kill1 = true;
									main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [0].mainunithp = hpen;
								}
							}
						}
					}
				}
			}
			if (coll.gameObject.tag == "unit") {
				GameObject coll1 = coll.gameObject.transform.parent.gameObject;
				if (coll1.gameObject.GetComponent<uniter> () != null) {
					if (coll1.gameObject.GetComponent<uniter> ().race != race) {
					if(!coll1.gameObject.GetComponent<uniter> ().kill &&!coll1.gameObject.GetComponent<uniter> ().kill1){
							if (coll1.gameObject.GetComponent<uniter> ().race == 11) {
								int hpen = main._m.teams [0].unitshp [main._m.teams [0].inst.IndexOf (coll1.gameObject)];
								int hpmy = hp;
								if (main._m.crit [num - 1, coll1.gameObject.GetComponent<uniter> ().num - 1] == true)
									hpen = -10;
								if (main._m.crit [coll1.gameObject.GetComponent<uniter> ().num - 1, num - 1] == true)
									hpmy = -10;
								while (hpmy > 0 && hpen > 0) {
									hpmy -= main._m.units [coll1.gameObject.GetComponent<uniter> ().num - 1].dmg;
									hpen -= main._m.units [num - 1].dmg;
								}
								if (hpmy <= 0) {
									kill = true;
								} else {
									kill1 = true;
									hp = hpmy;
								}
								if (hpen <= 0) {
									coll1.gameObject.GetComponent<uniter> ().kill = true;
								} else {
									coll1.gameObject.GetComponent<uniter> ().kill1 = true;
									main._m.teams [0].unitshp [main._m.teams [0].inst.IndexOf (coll1.gameObject)] = hpen;
								}
							} else {
								int hpen = main._m.races [coll1.gameObject.GetComponent<uniter> ().race].com.army [0].unitshp [main._m.races [coll1.gameObject.GetComponent<uniter> ().race].com.army [0].inst.IndexOf (coll1.gameObject)];
								int hpmy = hp;
								if (main._m.crit [num - 1, coll1.gameObject.GetComponent<uniter> ().num - 1] == true)
									hpen = -10;
								if (main._m.crit [coll1.gameObject.GetComponent<uniter> ().num - 1, num - 1] == true)
									hpmy = -10;
								while (hpmy > 0 && hpen > 0) {
									hpmy -= main._m.units [coll1.gameObject.GetComponent<uniter> ().num - 1].dmg;
									hpen -= main._m.units [num - 1].dmg;
								}
								if (hpmy <= 0) {
									kill = true;
								} else {
									kill1 = true;
									hp = hpmy;
								}
								if (hpen <= 0) {
									coll1.gameObject.GetComponent<uniter> ().kill = true;
								} else {
									coll1.gameObject.GetComponent<uniter> ().kill1 = true;
									main._m.races [coll1.gameObject.GetComponent<uniter> ().race].com.army [0].unitshp [main._m.races [coll1.gameObject.GetComponent<uniter> ().race].com.army [0].inst.IndexOf (coll1.gameObject)] = hpen;
								}
							}}}
				} else if (coll1.gameObject.GetComponent<mainunit> () != null) {
					if (coll1.gameObject.GetComponent<mainunit> ().race != race) {
					if(!coll1.gameObject.GetComponent<mainunit> ().kill &&!coll1.gameObject.GetComponent<mainunit> ().kill1){
							if (coll1.gameObject.GetComponent<mainunit> ().race == 11) {
								int hpen = main._m.teams [0].mainunithp;
								int hpmy = hp;
								if (main._m.crit [num - 1, coll1.gameObject.GetComponent<mainunit> ().num - 1] == true)
									hpen = -10;
								if (main._m.crit [coll1.gameObject.GetComponent<mainunit> ().num - 1, num - 1] == true)
									hpmy = -10;
								while (hpmy > 0 && hpen > 0) {
									hpmy -= main._m.units [coll1.gameObject.GetComponent<mainunit> ().num - 1].dmg;
									hpen -= main._m.units [num - 1].dmg;
								}
								if (hpmy <= 0) {
									kill = true;
								} else {
									kill1 = true;
									hp = hpmy;
								}
								if (hpen <= 0) {
									curtimeout1 = 1;
									coll1.gameObject.GetComponent<mainunit> ().kill = true;
								} else {
									coll1.gameObject.GetComponent<mainunit> ().kill1 = true;
									main._m.teams [0].mainunithp = hpen;
								}
							} else {
								int hpen = main._m.races [coll1.gameObject.GetComponent<mainunit> ().race].com.army [0].mainunithp;
								int hpmy = hp;
								if (main._m.crit [num - 1, coll1.gameObject.GetComponent<mainunit> ().num - 1] == true)
									hpen = -10;
								if (main._m.crit [coll1.gameObject.GetComponent<mainunit> ().num - 1, num - 1] == true)
									hpmy = -10;
								while (hpmy > 0 && hpen > 0) {
									hpmy -= main._m.units [coll1.gameObject.GetComponent<mainunit> ().num - 1].dmg;
									hpen -= main._m.units [num - 1].dmg;
								}
								if (hpmy <= 0) {
									kill = true;
								} else {
									kill1 = true;
									hp = hpmy;
								}
								if (hpen <= 0) {
									curtimeout1 = 1;
									coll1.gameObject.GetComponent<mainunit> ().kill = true;
								} else {
									coll1.gameObject.GetComponent<mainunit> ().kill1 = true;
									main._m.races [coll1.gameObject.GetComponent<uniter> ().race].com.army [0].mainunithp = hpen;
								}
							}
						}}}
			}
		}
	}
}
