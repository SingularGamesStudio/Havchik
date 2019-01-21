using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class racecommand : MonoBehaviour {
	public List<int> otn=new List<int>();
	public int race;
	public List<main.team> army=new List<main.team>();
	public float curtimeout2;
	public float curtimeout;
	GameObject h;
	public int nowin=-1;
	public bool havetsel;
	public GameObject tsel;
	public string tselfor;
	public List<Vector3> way;
	public List<bool> isprt;
	public bool destroyed;
	public float maxd;
	public float wait;
	public bool startw;
	public System.Random rnd = new System.Random ();
	public GameObject lst;
	public int lstcnt = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (main._m.ingame) {
			if (!destroyed) {
				if (startw) {
					curtimeout += Time.deltaTime;
				} else {
					if (tselfor == "") {
						startw = true;
					}
				}
				if (army [0].mainunithp <= 0) {

						if (army [0].units.Count > 0) {
							
							h = Instantiate (main._m.compref); 
							h.GetComponent<mainunit> ().race = race;
							h.GetComponent<mainunit> ().num = army [0].units [0];
							h.GetComponent<mainunit> ().m = 0;
							h.GetComponent<mainunit> ().gotsel = true;
							h.GetComponent<mainunit> ().tsel = army [0].comgo.GetComponent<mainunit> ().tsel;
							h.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = main._m.units [army [0].units [0] - 1].sp;
							h.transform.position = army [0].comgo.transform.position;
							Destroy (army [0].comgo);
							army [0].mainunit = army [0].units [0];
							army [0].mainunithp = army [0].unitshp [0];
							army [0].comgo = h;
							army [0].now -= 0.1f;
							Destroy (army [0].inst [0]);
							army [0].unsdvig.RemoveAt (0); army [0].units.RemoveAt (0);
							army [0].inst.RemoveAt (0);
							army [0].unitshp.RemoveAt (0);
							for (int j = 0; j < army [0].units.Count; j++) {
								army [0].inst [j].GetComponent<uniter> ().m = 0;
							}
						} else {
							army [0].mainunit = -1;
							Destroy (army [0].comgo);
							destroyed = true;
						}

					
				}
				if (startw && curtimeout >= wait) {

					h = Instantiate (main._m.compref);   
					h.GetComponent<mainunit> ().num = army [0].mainunit;
					h.GetComponent<mainunit> ().race = race;
					h.GetComponent<mainunit> ().gotsel = true;
					h.GetComponent<mainunit> ().m = 0;
					h.transform.position = main._m.allcities [nowin].transform.position+main._m.allcities [nowin].newexit;
					h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = main._m.units [h.GetComponent<mainunit> ().num - 1].sp;
					main._m.races [race].com.army [0].comgo = h;

					for (int j = 0; j < army [0].units.Count; j++) {
						h = Instantiate (main._m.unitpref);   
						h.GetComponent<uniter> ().topresl = army [0].comgo;
						h.GetComponent<uniter> ().race = race;
						h.GetComponent<uniter> ().m = 0;
						h.GetComponent<uniter> ().num = army [0].units [j];
						h.GetComponent<uniter> ().fly = main._m.units [army [0].units [j] - 1].fly;
						h.transform.position = army [0].comgo.transform.position;
						h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = main._m.units [army [0].units [j] - 1].sp;
						army [0].inst.Add (h);
					}
					findtsel ();
					curtimeout = 0;
					startw = false;
					nowin = -1;
				}
				curtimeout2 += Time.deltaTime;

				if (curtimeout2 > 0.5f) {
					for (int j = 0; j < army [0].unitshp.Count; j++) {
						if (army [0].unitshp [j] <= 0) {
							Destroy (army [0].inst [j]);
							army [0].units.RemoveAt (j);
							army [0].unitshp.RemoveAt (j);
							army [0].inst.RemoveAt (j);
							army [0].now -= 0.1f;
						}
					}
				}
				if (curtimeout2 > 0.5f) {
					if (tselfor != "") {
						if (way.Count==0||Vector3.Distance (army [0].comgo.transform.position, way [0]) < maxd) {
							if (way.Count != 0) {
								if (isprt [0]) {
									isprt.RemoveAt (0);
									way.RemoveAt (0);
									army [0].comgo.transform.position = way [0];
								}
								isprt.RemoveAt (0);
								way.RemoveAt (0);
							}
							if (way.Count == 0) {
								if (tselfor == "defend") {
									way.Add (new Vector3 (tsel.transform.position.x + 3, tsel.transform.position.y));
									way.Add (new Vector3 (tsel.transform.position.x, tsel.transform.position.y + 3));
									way.Add (new Vector3 (tsel.transform.position.x - 3, tsel.transform.position.y));
									way.Add (new Vector3 (tsel.transform.position.x, tsel.transform.position.y - 3));
									way.Add (tsel.transform.position);
									isprt.Add (false);
									isprt.Add (false);
									isprt.Add (false);
									isprt.Add (false);
									isprt.Add (false);
									army [0].comgo.GetComponent<mainunit> ().gotsel = true;
									army [0].comgo.GetComponent<mainunit> ().tsel = way [0];
								} else if (tselfor == "attack") {
									if (tsel.GetComponent<city> ().uns.Count > 0) {
										if (!tsel.GetComponent<city> ().inbattle && !tsel.GetComponent<city> ().inbattleii) {
											tsel.GetComponent<city> ().startbtlii (race);
											army [0].comgo.transform.position = tsel.GetComponent<city> ().sppos.transform.position;
											for (int j = 0; j < army [0].units.Count; j++) {
												army [0].inst [j].transform.position = tsel.GetComponent<city> ().sppos.transform.position;
											}
											tselfor = "attackun";
											way.Add (tsel.GetComponent<city> ().uns [0].transform.position);
											army [0].comgo.GetComponent<mainunit> ().tsel = way [0];
											isprt.Add (false);
										} else {
											findtsel ();
										}
									} else {
										way.Add (tsel.transform.position);
										isprt.Add (false);
										army [0].comgo.GetComponent<mainunit> ().tsel = way [0];
										tselfor = "zahvat";
									}
								} else if (tselfor == "attackun") {
									if (tsel.GetComponent<city> ().uns.Count > 0) {
										if (tsel.GetComponent<city> ().uns [0] != null) {
											if (tsel.GetComponent<city> ().uns [0].activeSelf) {
												if (lst != tsel.GetComponent<city> ().uns [0]) {
													lstcnt = 0;
													lst = tsel.GetComponent<city> ().uns [0];
													way.Add (tsel.GetComponent<city> ().uns [0].transform.position);
													isprt.Add (false);
													army [0].comgo.GetComponent<mainunit> ().tsel = way [0];
												} else {
													if (lstcnt > 30) {
														lstcnt = 0;
														lst = tsel;
														way.Add (tsel.transform.position);
														isprt.Add (false);
														army [0].comgo.GetComponent<mainunit> ().tsel = way [0];
													} else {
														lstcnt++;
														way.Add (tsel.GetComponent<city> ().uns [0].transform.position);
														isprt.Add (false);
														army [0].comgo.GetComponent<mainunit> ().tsel = way [0];
													}
												}
											} else {
												findtsel ();
											}
										}
									} else {
										way.Add (tsel.transform.position);
										isprt.Add (false);
										army [0].comgo.GetComponent<mainunit> ().tsel = way [0];
										tselfor = "zahvat";
									}
								} else if (tselfor == "zahvat") {
									tsel.GetComponent<city> ().exitii ();
									tsel.GetComponent<city> ().race = race;
									tsel.GetComponent<city> ().inbattleii = false;
									tsel.GetComponent<city> ().inbattle1 = false;
									tsel.GetComponent<city> ().inbattle = false;
									tselfor = "entercity";
									way.Add (tsel.transform.position);
									isprt.Add (false);
								} else  if (tselfor == "entercity") {
									wait = rnd.Next (120);
									nowin = tsel.GetComponent<city> ().num;
									Destroy (army [0].comgo);
									int ggg = army [0].inst.Count;
									for (int i = 0; i < ggg; i++) {
										Destroy (army [0].inst [0]);
										army [0].inst.RemoveAt (0);
									}
									tselfor = "";
									while (tsel.GetComponent<city> ().unitsin.Count * 0.33f > army [0].units.Count) {
										int yu = rnd.Next (tsel.GetComponent<city> ().unitsin.Count);
										army [0].units.Add (tsel.GetComponent<city> ().unitsin [yu]);
										army [0].unitshp.Add (main._m.units [tsel.GetComponent<city> ().unitsin [yu] - 1].hp);
										army [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
										tsel.GetComponent<city> ().unitsin.RemoveAt (yu);
									}
									while (tsel.GetComponent<city> ().unitsin.Count * 0.33f > tsel.GetComponent<city> ().alldef.Count) {
										int yu = rnd.Next (tsel.GetComponent<city> ().unitsin.Count);
										tsel.GetComponent<city> ().alldef.Add (tsel.GetComponent<city> ().unitsin [yu]);
										tsel.GetComponent<city> ().unitsin.RemoveAt (yu);
									}
								
								} else if (tselfor == "go") {
								
									findtsel ();
								}
							} else
								army [0].comgo.GetComponent<mainunit> ().tsel = way [0];
						}
					}
				}
		
		
		

			}
		}
	}
	public List<int> proc = new List<int> ();
	public List<int> numslist = new List<int> ();
	public List<string> todoin = new List<string> ();
	public int ooo;
	public void findtsel(){
		int sum=0;
		for (int i = 0; i < main._m.allcities.Count; i++) {
			if (main._m.allcities [i].race == race) {
				proc.Add (Mathf.Max ((main._m.allcities [i].unitsin.Count - 3 * army [0].units.Count) / 4, 0) * 6);
				numslist.Add (i);
				todoin.Add ("entercity");
				sum += proc [proc.Count - 1];
			} else if (army[0].units.Count-main._m.allcities [i].alldef.Count > 0) {
				if (!main._m.allcities [i].cantbeatkii) {
					proc.Add (Mathf.Max (army [0].units.Count - main._m.allcities [i].alldef.Count, 0) * 2);
					numslist.Add (i);
					todoin.Add ("attack");
					sum += proc [proc.Count - 1];
				}
			}
			if (!main._m.allcities [i].cantbeatkii) {
				proc.Add (1);
				numslist.Add (i);
				todoin.Add ("go");
				sum += 1;
			}

		}
		ooo = main._m.rnd.Next (sum);
		sum = 0;
		for (int i = 0; i < proc.Count; i++) {
			sum += proc [i];
			if (sum >= ooo) {
				tselfor = todoin [i];
				tsel = main._m.allcities [numslist[i]].gameObject;
				break;
			}

		}
		int nowdot=0;
		float mind = 10000000;
		for(int i=0;i<main._m.graph.Count;i++){
			if (Vector3.Distance (main._m.graph [i].go.transform.position, army [0].comgo.transform.position) < mind) {
				mind = Vector3.Distance (main._m.graph [i].go.transform.position, army [0].comgo.transform.position);
				nowdot = i;
			}
		}
		Queue<List<int>> f = new Queue<List<int>> ();
		Queue<int> f1 = new Queue<int> ();

		bool[] visited = new bool[main._m.graph.Count];
		for (int i = 0; i < main._m.graph.Count; i++) {
			visited [i] = false;
		}
		f.Enqueue (new List<int>());
		f1.Enqueue(nowdot);
		try{
		while (main._m.graph [f1.Peek ()].go != tsel) {
			List<int> o = new List<int> ();
			o.Clear ();
			visited [f1.Peek ()] = true;
			o=f.Dequeue();
			o.Add (f1.Peek());
			for (int j = 0; j < main._m.graph [f1.Peek ()].svyaz.Count; j++) {
				if (!visited [main._m.graph [f1.Peek ()].svyaz [j]]) {
					f.Enqueue (o);
					f1.Enqueue (main._m.graph [f1.Peek ()].svyaz [j]);
				}
			}
			f1.Dequeue ();
			}
		}
		catch
		{
			Debug.LogError ("err race "+race+" city#" + main._m.allcities.IndexOf (tsel.GetComponent<city> ()) + " " + tselfor);
		}
		List<int> o1 = new List<int> ();
		o1 = f.Peek();
		o1.Add (f1.Peek ());
		int strt = o1.Count - 2;

		for (int i = strt; i > 0; i--) {
			int yy = 0;
			for (int j = 0; j < main._m.graph [o1 [i]].svyaz.Count; j++) {
				if (o1.Contains (main._m.graph [o1 [i]].svyaz [j])) {
					yy++;
				}
			}
			if (yy == 1)
				o1.RemoveAt (i);
		}
		strt = o1.Count - 2;
		for (int i = strt; i > 0; i--) {
			int yy = 0;
			for (int j = 0; j < main._m.graph [o1 [i]].svyaz.Count; j++) {
				if (o1.Contains (main._m.graph [o1 [i]].svyaz [j])) {
					yy++;
				}
			}
			if (yy == 1)
				o1.RemoveAt (i);
		}
		strt = o1.Count - 2;
		for (int i = strt; i > 0; i--) {
			int yy = 0;
			for (int j = 0; j < main._m.graph [o1 [i]].svyaz.Count; j++) {
				if (o1.Contains (main._m.graph [o1 [i]].svyaz [j])) {
					yy++;
				}
			}
			if (yy == 1)
				o1.RemoveAt (i);
		}
		strt = o1.Count - 2;
		for (int i = strt; i > 0; i--) {
			int yy = 0;
			for (int j = 0; j < main._m.graph [o1 [i]].svyaz.Count; j++) {
				if (o1.Contains (main._m.graph [o1 [i]].svyaz [j])) {
					yy++;
				}
			}
			if (yy == 1||yy==0)
				o1.RemoveAt (i);
		}
		strt = o1.Count - 2;
		for (int i = strt; i > 0; i--) {
			int yy = 0;
			for (int j = 0; j < main._m.graph [o1 [i]].svyaz.Count; j++) {
				if (o1.Contains (main._m.graph [o1 [i]].svyaz [j])) {
					yy++;
				}
			}
			if (yy == 1)
				o1.RemoveAt (i);
		}
		for (int i = 0; i < o1.Count; i++) {
			way.Add (main._m.graph [o1 [i]].go.transform.position);
			if (main._m.graph [o1 [i]].typer == "portal")
				isprt.Add (true);
			else
				isprt.Add (false);
		}
		army [0].comgo.GetComponent<mainunit> ().tsel = way [0];
		army [0].comgo.GetComponent<mainunit> ().gotsel = true;
	}
	
}
