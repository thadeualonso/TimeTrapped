﻿using UnityEngine;
using System.Collections;

public class Missel : MonoBehaviour {

    public float velocidade;
    public Direcoes direcao;
    public NiveisTerrenos nivelTerreno;
    public float dirX;
    public float dirY;

    // Update is called once per frame
    void Update()
    {
        switch (direcao)
        {
            case Direcoes.Right:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.Left:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.Up:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.Down:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.UpRight:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.UpLeft:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.DownRight:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.DownLeft:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Colisao: Trigger");

        if (collider.gameObject.tag == "Inimigo" && collider.GetComponent<EnemyLanceiro>().nivelTerreno == NiveisTerrenos.Superior)
        {
            Destroy(gameObject);
            Debug.Log(collider.GetComponent<EnemyLanceiro>().nivelTerreno);
        }

        if (collider.gameObject.tag == "Limite")
        {
            Destroy(gameObject);
        }
    }
}
