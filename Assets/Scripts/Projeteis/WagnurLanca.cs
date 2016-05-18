using UnityEngine;
using System.Collections;
using System;

public class WagnurLanca : Projetil
{

    void Update()
    {
        switch (direcao)
        {
            case Direcoes.Down:
                transform.rotation = new Quaternion(0f, 0f, -180f, 0f);
                break;
            case Direcoes.Up:
                transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                break;
            case Direcoes.Left:
                transform.rotation = new Quaternion(0f, 0f, 90f, 0f);
                break;
            case Direcoes.Right:
                transform.rotation = new Quaternion(0f, 0f, -90f, 0f);
                break;
            case Direcoes.DownLeft:
                transform.rotation = new Quaternion(0f, 0f, 130f, 0f);
                break;
            case Direcoes.DownRight:
                transform.rotation = new Quaternion(0f, 0f, 230f, 0f);
                break;
            case Direcoes.UpLeft:
                transform.rotation = new Quaternion(0f, 0f, 40f, 0f);
                break;
            case Direcoes.UpRight:
                transform.rotation = new Quaternion(0f, 0f, 310f, 0f);
                break;
        }

        GetComponent<Rigidbody2D>().velocity = transform.up * velocidade;
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        //
    }
}
