﻿using UnityEngine;
using System.Collections;
using System;

public class EnemyGoro : Humanoid {

    public float moveX;
    public float moveY;
    public GameObject explosao;

    void OnTriggerEnter2D (Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.tag == "Tiro" && other.GetComponent<Tiro>().nivelTerreno == nivelTerreno)
        {
            Debug.Log("Colidindo com tiro do player");
            hp -= other.GetComponent<Tiro>().dano;
            Instantiate(explosao, transform.position, Quaternion.identity);
        }

        if (other.gameObject.tag == "Missel" && nivelTerreno == other.gameObject.GetComponent<Missel>().nivelTerreno)
        {
            Debug.Log("Colidindo com missel do player");
            hp -= other.GetComponent<Missel>().dano;
            Instantiate(explosao, transform.position, Quaternion.identity);
            Destroy(gameObject);
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