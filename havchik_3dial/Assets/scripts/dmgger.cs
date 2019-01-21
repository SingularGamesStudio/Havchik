using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgger : MonoBehaviour {
	public int race;
	public int dmg;
	public bool attackonce;
	public bool strikeenemy=false;
	public bool destroy;
	public float timeleast;
	public float curtimeout = 0;
	public float curtimeout1 = 0;
	public float curtimeout3 = 0;
	public float curtimeout4 = 0;
	public List<Sprite> anim;
	public int state = 0;
	public string movetype;
	public Vector3 v;
	System.Random rnd=new System.Random();
	public float zaderzh;
	public float speed;
	public int maxspeed;
	public int numinmain;
	public bool spawn;
	public int tospawn;
	public int tospawncol;
	public float spawntime;
	public bool admintower;
	float curtimeout5=0;
	GameObject h;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (destroy) {
			curtimeout += Time.deltaTime;
			if (curtimeout >= timeleast) {
				Destroy (gameObject);
				main._m.buildingsbuilded.RemoveAt (numinmain);
				main._m.buildingsbuildedpos.RemoveAt (numinmain);
			}
		}
		if (anim.Count != 0){
			curtimeout1 += Time.deltaTime;
		if (curtimeout1 > 0.5f) {
			
			curtimeout1 = 0;
			state = (state + 1) % anim.Count;
			gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = anim [state];
		}
	}
		curtimeout3 += Time.deltaTime;
		if (curtimeout3 > 0.1f) {
			if (movetype == "forward")
				gameObject.transform.Translate (Vector3.up * speed);
			else if (movetype == "rnd")
				gameObject.transform.Translate (v * speed);
			curtimeout3 = 0;
		}
		if (movetype == "rnd") {
			curtimeout4 += Time.deltaTime;
			if (curtimeout4 >= zaderzh) {
				zaderzh =main._m.rnd.Next (100);
				zaderzh /= 100;
				v.x=main._m.rnd.Next (-100, 100);
				v.x /= 100;
				v.y =                                                                                                                               main._m.rnd.Next (-100, 100);
				v.y /= 100;
				speed =                                                                                                                               main._m.rnd.Next (maxspeed * 100);
				speed /= 100;
				curtimeout4 = 0;
			}
		}
		if (admintower) {
			for (int i = 0; i < main._m.units.Count; i++) {
				h = Instantiate (main._m.unitpref);
				h.GetComponent<uniter> ().race = 11;
				h.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = main._m.units [i].sp;
				h.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y);
				h.GetComponent<uniter> ().m = main._m.chosedteam;
				h.GetComponent<uniter> ().num = i + 1;
				h.GetComponent<uniter> ().fly = main._m.units [i].fly;
				main._m.teams [0].unsdvig.Add(Vector3.zero); main._m.teams [0].units.Add (i + 1);
				main._m.teams [0].unitshp.Add (main._m.units [i].hp);
				main._m.teams [0].inst.Add (h);
				main._m.teams [0].now += 0.1f;
			}
			for (int i = 0; i < main._m.resource.Count; i++) {
				main._m.resource [i] = 10000;
			}
			Destroy (gameObject);
			main._m.buildingsbuilded.RemoveAt (numinmain);
			main._m.buildingsbuildedpos.RemoveAt (numinmain);
		}
		if (spawn) {
			curtimeout5 += Time.deltaTime;
			if (curtimeout5 >= spawntime) {
				curtimeout5 = 0;
				tospawncol -= 1;
				h = Instantiate (main._m.unitpref);
				h.GetComponent<uniter> ().race = 11;
				h.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = main._m.units [tospawn-1].sp;
				h.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y);
				h.GetComponent<uniter> ().m = main._m.chosedteam;
				h.GetComponent<uniter> ().num = tospawn;
				h.GetComponent<uniter> ().fly = main._m.units [0].fly;
				main._m.teams [0].unsdvig.Add(Vector3.zero); main._m.teams [0].units.Add (tospawn);
				main._m.teams [0].unitshp.Add (main._m.units [tospawn-1].hp);
				main._m.teams [0].inst.Add (h);
				if (tospawncol == 0) {
					Destroy (gameObject);
					main._m.buildingsbuilded.RemoveAt (numinmain);
					main._m.buildingsbuildedpos.RemoveAt (numinmain);
				}
			}
		}
	}
	public void OnTriggerEnter2D(Collider2D coll){
		GameObject m;
		if (coll.gameObject.tag == "unit" || coll.gameObject.tag == "unittrig") {
			if (coll.gameObject.tag == "unit")
				m = coll.gameObject.transform.parent.gameObject;
			else
				m = coll.gameObject;
			if (m.GetComponent<uniter> () != null) {
				if (m.GetComponent<uniter> ().race != race && strikeenemy) {

					if (attackonce) {
						Destroy (gameObject);
						main._m.buildingsbuilded.RemoveAt (numinmain);
						main._m.buildingsbuildedpos.RemoveAt (numinmain);
					}
				}
			} if (m.GetComponent<uniter> () != null) {
				if (m.GetComponent<uniter> ().race != race && strikeenemy) {

					if (attackonce) {
						Destroy (gameObject);
						main._m.buildingsbuilded.RemoveAt (numinmain);
						main._m.buildingsbuildedpos.RemoveAt (numinmain);
					}
				}
			} else if (m.GetComponent<defender> () != null) {
				if (m.GetComponent<defender> ().race != race && strikeenemy) {
					m.GetComponent<defender> ().hp -= dmg;
					if (attackonce) {
						Destroy (gameObject);
						main._m.buildingsbuilded.RemoveAt (numinmain);
						main._m.buildingsbuildedpos.RemoveAt (numinmain);
					}
				}
			}
		}
	}
}
