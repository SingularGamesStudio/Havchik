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
		curtimeout1 += Time.deltaTime;
		if (curtimeout1 > 0.5f) {
			curtimeout1 = 0;
			state = (state + 1) % anim.Count;
			gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = anim [state];
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
				zaderzh = rnd.Next (100);
				zaderzh /= 100;
				v.x = rnd.Next (-100, 100);
				v.x /= 100;
				v.y = rnd.Next (-100, 100);
				v.y /= 100;
				speed = rnd.Next (maxspeed * 100);
				speed /= 100;
				curtimeout4 = 0;
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
