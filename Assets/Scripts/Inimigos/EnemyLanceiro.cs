﻿using UnityEngine;
using System.Collections;
using System;

public class EnemyLanceiro : Humanoid {

    public float moveX;
    public float moveY;

    void OnTriggerEnter2D (Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.tag == "Tiro")
        {
            Debug.Log("Colidindo com tiro do player");
            hp--;
        }

        if (other.gameObject.tag == "Missel" && nivelTerreno == other.gameObject.GetComponent<Missel>().nivelTerreno)
        {
            Debug.Log("Colidindo com missel do player");
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