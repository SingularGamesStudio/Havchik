using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincameracontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(main._m.ingame)
		gameObject.transform.position = new Vector3(main._m.teams[0].comgo.transform.position.x, main._m.teams[0].comgo.transform.position.y, -10);
    }
}
