 using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

    public int hp;
	
	// Update is called once per frame
	void Update () {

	    if(hp <= 0) { Destroy(gameObject); }

	}


    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.tag == "Tiro")
        {
            hp--;
        }
    }

}
