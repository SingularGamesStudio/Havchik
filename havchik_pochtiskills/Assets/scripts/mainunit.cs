using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class mainunit : MonoBehaviour {
	public int race;
	public int num;
	public int m;
	public bool kill=false;
	public bool kill1=false;
	public int killstate=0;
	public float anrazn=0.1f;
	public float curtimeout1=0;
	public float curtimeout2=0;
	public float curtimeout=0;
	public bool gotsel=false;
	public Vector3 tsel;
	public float speed;
	public bool isposol;
	public string poruch;
	public GameObject tseltsel;
	public int poruchcol;
	public GameObject poruchtsel;
	public bool stoptobattle;
	public bool arenabattler;
	public GameObject preslarena;
	public bool arenastop;
	public System.Random rnd = new System.Random ();
	public List<GameObject> au=new List<GameObject>();
	public int arenahp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (kill) {
			if(killstate==4){
				if (arenabattler)
					Destroy (gameObject);
				else
					main._m.teams [m].mainunithp = -10;
			}
		}
		if (kill1) {
			if(killstate==4){
				killstate=0;
				kill1=false;
			}
		}
		curtimeout2 += Time.deltaTime;
		curtimeout1 += Time.deltaTime;
		curtimeout += Time.deltaTime;
		if (curtimeout1 > anrazn && (kill|| kill1)) {
			if(killstate==0){
				gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=main._m.units[num-1].at1;
				main._m.soundplay (main._m.units [num - 1].attack, gameObject.transform.position.x, gameObject.transform.position.y);
			} else if(killstate==1){
				gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=main._m.units[num-1].at2;
				
			} else if(killstate==2){
				gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=main._m.units[num-1].at3;
				
			} else if(killstate==3){
				gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=main._m.units[num-1].sp;
				
			}
			killstate+=1;
			curtimeout1=0;
		}
		if (curtimeout > 0.01f) {
			if(gotsel){
				gameObject.transform.position=Vector3.MoveTowards(gameObject.transform.position,tsel,Time.deltaTime*speed);
			}
			curtimeout=0;
			if (arenabattler) {
				if (main._m.ingame)
					Destroy (gameObject);
				if (preslarena == null) {
					GameObject[] a = GameObject.FindGameObjectsWithTag ("arena");
					au.Clear ();
					for (int i = 0; i < a.Length; i++)
						if(a[i].transform.parent.gameObject!=gameObject)
							au.Add (a [i]);
					if (au.Count > 0) {
						int y = rnd.Next (au.Count);
						preslarena = au [y];
						arenastop = false;
					} else
						arenastop = true;
				} else {
					if (!arenastop) {
						gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, preslarena.transform.position, speed * Time.deltaTime);
					}
				}
			}
		}
		if (curtimeout2 > 1) {
			if (isposol && Vector3.Distance (transform.position, tsel) < 2 && gotsel) {
				if (poruch == "podkrep") {
					tseltsel.GetComponent<city> ().podkrep (poruchtsel, poruchcol);
				} else if (poruch == "podkrep") {
					tseltsel.GetComponent<racecommand> ().cityindanger (poruchcol);
				}
				gotsel = false;
			} else if (Vector3.Distance (transform.position, tsel) < 2 && gotsel)
				gotsel = false;
		}
	}





	public void OnTriggerEnter2D(Collider2D coll){
		if (!kill && !kill1) {
			if (arenabattler) {
				if (coll.gameObject.tag == "unittrig") {
					if (!coll.gameObject.GetComponent<mainunit> ().kill && !coll.gameObject.GetComponent<mainunit> ().kill1) {
						int hpen = coll.gameObject.GetComponent<mainunit> ().arenahp;
						int hpmy = arenahp;
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
							arenahp = hpmy;
						}
						if (hpen <= 0) {
							coll.gameObject.GetComponent<mainunit> ().kill = true;
						} else {
							coll.gameObject.GetComponent<mainunit> ().kill1 = true;
							coll.gameObject.GetComponent<mainunit> ().arenahp = hpen;
						}
					}
				} else if (coll.gameObject.tag == "unit") {
					GameObject coll1 = coll.transform.parent.gameObject;
					if (!coll1.gameObject.GetComponent<mainunit> ().kill && !coll1.gameObject.GetComponent<mainunit> ().kill1) {
						int hpen = coll1.gameObject.GetComponent<mainunit> ().arenahp;
						int hpmy = arenahp;
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
							arenahp = hpmy;
						}
						if (hpen <= 0) {
							coll1.gameObject.GetComponent<mainunit> ().kill = true;
						} else {
							coll1.gameObject.GetComponent<mainunit> ().kill1 = true;
							coll1.gameObject.GetComponent<mainunit> ().arenahp = hpen;
						}
					}
				}
			} else {
				if (coll.gameObject.tag == "unittrig") {
					if (coll.gameObject.GetComponent<uniter> () != null) {
						if (coll.gameObject.GetComponent<uniter> ().race != race) {
							if (!coll.gameObject.GetComponent<uniter> ().kill && !coll.gameObject.GetComponent<uniter> ().kill1) {
								if (coll.gameObject.GetComponent<uniter> ().race == 11) {
									int hpen = main._m.teams [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.teams [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)];
									int hpmy = main._m.races [race].com.army [m].mainunithp;
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
										main._m.races [race].com.army [m].mainunithp = hpmy;
									}
									if (hpen <= 0) {
										coll.gameObject.GetComponent<uniter> ().kill = true;
									} else {
										coll.gameObject.GetComponent<uniter> ().kill1 = true;
										main._m.teams [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.teams [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)] = hpen;
									}
								} else if (race == 11) {
									int hpen = main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)];
									int hpmy = main._m.teams [m].mainunithp;
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
										main._m.teams [m].mainunithp = hpmy;
									}
									if (hpen <= 0) {
										coll.gameObject.GetComponent<uniter> ().kill = true;
									} else {
										coll.gameObject.GetComponent<uniter> ().kill1 = true;
										main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)] = hpen;
									}
								} else {
									int hpen = main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)];
									int hpmy = main._m.races [race].com.army [m].mainunithp;
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
										main._m.races [race].com.army [m].mainunithp = hpmy;
									}
									if (hpen <= 0) {
										coll.gameObject.GetComponent<uniter> ().kill = true;
									} else {
										coll.gameObject.GetComponent<uniter> ().kill1 = true;
										main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)] = hpen;
									}
								}
							}
						}
					} else if (coll.gameObject.GetComponent<mainunit> () != null) {
						if (coll.gameObject.GetComponent<mainunit> ().race != race) {
							if (!coll.gameObject.GetComponent<mainunit> ().kill && !coll.gameObject.GetComponent<mainunit> ().kill1) {
								if (coll.gameObject.GetComponent<mainunit> ().race == 11) {
									int hpen = main._m.teams [coll.gameObject.GetComponent<mainunit> ().m].mainunithp;
									int hpmy = main._m.races [race].com.army [m].mainunithp;
									while (hpmy > 0 && hpen > 0) {
										hpmy -= main._m.units [coll.gameObject.GetComponent<mainunit> ().num - 1].dmg;
										hpen -= main._m.units [num - 1].dmg;
									}
									if (hpmy <= 0) {
										kill = true;
									} else {
										kill1 = true;
										main._m.races [race].com.army [m].unitshp [main._m.races [race].com.army [m].inst.IndexOf (gameObject)] = hpmy;
									}
									if (hpen <= 0) {
										curtimeout1 = 1;
										coll.gameObject.GetComponent<mainunit> ().kill = true;
									} else {
										coll.gameObject.GetComponent<mainunit> ().kill1 = true;
										main._m.teams [coll.gameObject.GetComponent<mainunit> ().m].mainunithp = hpen;
									}
								} else if (race == 11) {
									int hpen = main._m.races [coll.gameObject.GetComponent<mainunit> ().race].com.army [coll.gameObject.GetComponent<mainunit> ().m].mainunithp;
									int hpmy = main._m.teams [m].mainunithp;
									while (hpmy > 0 && hpen > 0) {
										hpmy -= main._m.units [coll.gameObject.GetComponent<mainunit> ().num - 1].dmg;
										hpen -= main._m.units [num - 1].dmg;
									}
									if (hpmy <= 0) {
										kill = true;
									} else {
										kill1 = true;
										main._m.teams [m].mainunithp = hpmy;
									}
									if (hpen <= 0) {
										curtimeout1 = 1;
										coll.gameObject.GetComponent<mainunit> ().kill = true;
									} else {
										coll.gameObject.GetComponent<mainunit> ().kill1 = true;
										main._m.races [coll.gameObject.GetComponent<mainunit> ().race].com.army [coll.gameObject.GetComponent<mainunit> ().m].mainunithp = hpen;
									}
								} else {
									int hpen = main._m.races [coll.gameObject.GetComponent<mainunit> ().race].com.army [coll.gameObject.GetComponent<mainunit> ().m].mainunithp;
									int hpmy = main._m.races [race].com.army [m].mainunithp;
									while (hpmy > 0 && hpen > 0) {
										hpmy -= main._m.units [coll.gameObject.GetComponent<mainunit> ().num - 1].dmg;
										hpen -= main._m.units [num - 1].dmg;
									}
									if (hpmy <= 0) {
										kill = true;
									} else {
										kill1 = true;
										main._m.races [race].com.army [m].mainunithp = hpmy;
									}
									if (hpen <= 0) {
										curtimeout1 = 1;
										coll.gameObject.GetComponent<mainunit> ().kill = true;
									} else {
										coll.gameObject.GetComponent<mainunit> ().kill1 = true;
										main._m.races [coll.gameObject.GetComponent<mainunit> ().race].com.army [coll.gameObject.GetComponent<mainunit> ().m].mainunithp = hpen;
									}
								}
							}
						}
					}
				} else if (coll.gameObject.tag == "unit") {
					GameObject coll1 = coll.gameObject.transform.parent.gameObject;
					coll = coll1.GetComponent<Collider2D> ();
					if (coll.gameObject.GetComponent<uniter> () != null) {
						if (coll.gameObject.GetComponent<uniter> ().race != race) {
							if (!coll.gameObject.GetComponent<uniter> ().kill && !coll.gameObject.GetComponent<uniter> ().kill1) {
								if (coll.gameObject.GetComponent<uniter> ().race == 11) {
									int hpen = main._m.teams [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.teams [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)];
									int hpmy = main._m.races [race].com.army [m].mainunithp;
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
										main._m.races [race].com.army [m].mainunithp = hpmy;
									}
									if (hpen <= 0) {
										coll.gameObject.GetComponent<uniter> ().kill = true;
									} else {
										coll.gameObject.GetComponent<uniter> ().kill1 = true;
										main._m.teams [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.teams [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)] = hpen;
									}
								} else if (race == 11) {
									int hpen = main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)];
									int hpmy = main._m.teams [m].mainunithp;
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
										main._m.teams [m].mainunithp = hpmy;
									}
									if (hpen <= 0) {
										coll.gameObject.GetComponent<uniter> ().kill = true;
									} else {
										coll.gameObject.GetComponent<uniter> ().kill1 = true;
										main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)] = hpen;
									}
								} else {
									int hpen = main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)];
									int hpmy = main._m.races [race].com.army [m].mainunithp;
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
										main._m.races [race].com.army [m].mainunithp = hpmy;
									}
									if (hpen <= 0) {
										coll.gameObject.GetComponent<uniter> ().kill = true;
									} else {
										coll.gameObject.GetComponent<uniter> ().kill1 = true;
										main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].unitshp [main._m.races [coll.gameObject.GetComponent<uniter> ().race].com.army [coll.gameObject.GetComponent<uniter> ().m].inst.IndexOf (coll.gameObject)] = hpen;
									}
								}
							}
						}
					} else if (coll.gameObject.GetComponent<mainunit> () != null) {
						if (coll.gameObject.GetComponent<mainunit> ().race != race) {
							if (!coll.gameObject.GetComponent<mainunit> ().kill && !coll.gameObject.GetComponent<mainunit> ().kill1) {
								if (coll.gameObject.GetComponent<mainunit> ().race == 11) {
									int hpen = main._m.teams [coll.gameObject.GetComponent<mainunit> ().m].mainunithp;
									int hpmy = main._m.races [race].com.army [m].mainunithp;
									while (hpmy > 0 && hpen > 0) {
										hpmy -= main._m.units [coll.gameObject.GetComponent<mainunit> ().num - 1].dmg;
										hpen -= main._m.units [num - 1].dmg;
									}
									if (hpmy <= 0) {
										kill = true;
									} else {
										kill1 = true;
										main._m.races [race].com.army [m].mainunithp = hpmy;
									}
									if (hpen <= 0) {
										curtimeout1 = 1;
										coll.gameObject.GetComponent<mainunit> ().kill = true;
									} else {
										coll.gameObject.GetComponent<mainunit> ().kill1 = true;
										main._m.teams [coll.gameObject.GetComponent<mainunit> ().m].mainunithp = hpen;
									}
								} else if (race == 11) {
									int hpen = main._m.races [coll.gameObject.GetComponent<mainunit> ().race].com.army [coll.gameObject.GetComponent<mainunit> ().m].mainunithp;
									int hpmy = main._m.teams [m].mainunithp;
									while (hpmy > 0 && hpen > 0) {
										hpmy -= main._m.units [coll.gameObject.GetComponent<mainunit> ().num - 1].dmg;
										hpen -= main._m.units [num - 1].dmg;
									}
									if (hpmy <= 0) {
										kill = true;
									} else {
										kill1 = true;
										main._m.teams [m].mainunithp = hpmy;
									}
									if (hpen <= 0) {
										curtimeout1 = 1;
										coll.gameObject.GetComponent<mainunit> ().kill = true;
									} else {
										coll.gameObject.GetComponent<mainunit> ().kill1 = true;
										main._m.races [coll.gameObject.GetComponent<mainunit> ().race].com.army [coll.gameObject.GetComponent<mainunit> ().m].mainunithp = hpen;
									}
								} else {
									int hpen = main._m.races [coll.gameObject.GetComponent<mainunit> ().race].com.army [coll.gameObject.GetComponent<mainunit> ().m].mainunithp;
									int hpmy = main._m.races [race].com.army [m].mainunithp;
									while (hpmy > 0 && hpen > 0) {
										hpmy -= main._m.units [coll.gameObject.GetComponent<mainunit> ().num - 1].dmg;
										hpen -= main._m.units [num - 1].dmg;
									}
									if (hpmy <= 0) {
										kill = true;
									} else {
										kill1 = true;
										main._m.races [race].com.army [m].mainunithp = hpmy;
									}
									if (hpen <= 0) {
										curtimeout1 = 1;
										coll.gameObject.GetComponent<mainunit> ().kill = true;
									} else {
										coll.gameObject.GetComponent<mainunit> ().kill1 = true;
										main._m.races [coll.gameObject.GetComponent<mainunit> ().race].com.army [coll.gameObject.GetComponent<mainunit> ().m].mainunithp = hpen;
									}
								}
							}
						}
					}
				}
			}
		}
	}




}
