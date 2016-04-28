using UnityEngine;
using System.Collections;
using System;

public class Inimigo : Humanoid {

    public float moveX;
    public float moveY;
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D (Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.tag == "Tiro")
        {
            Debug.Log("Colidindo com tiro do player");
            hp--;
        }
    }

    public override void Ataque()
    {
        
    }

    public override void Mover()
    {
        
    }

    public override void ChecaDirecao()
    {
        
    }
}
