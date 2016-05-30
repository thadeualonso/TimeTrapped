using UnityEngine;
using System.Collections;
using System;

public class WagnurLanca : Projetil
{
    void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Invoke("Destruir", 1f);

        if (direcao == Direcoes.Up)         { transform.rotation = Quaternion.Euler(0f, 0f, 0f);    }
        if (direcao == Direcoes.Down)       { transform.rotation = Quaternion.Euler(0f, 0f, 180f);  }
        if (direcao == Direcoes.Right)      { transform.rotation = Quaternion.Euler(0f, 0f, -90f);  }
        if (direcao == Direcoes.Left)       { transform.rotation = Quaternion.Euler(0f, 0f, 90f);   }
        if (direcao == Direcoes.UpRight)    { transform.rotation = Quaternion.Euler(0f, 0f, 325f);  }
        if (direcao == Direcoes.UpLeft)     { transform.rotation = Quaternion.Euler(0f, 0f, -325f); }
        if (direcao == Direcoes.DownRight)  { transform.rotation = Quaternion.Euler(0f, 0f, -135f); }
        if (direcao == Direcoes.DownLeft)   { transform.rotation = Quaternion.Euler(0f, 0f, 135f);  }
    }

    void Update()
    {
        rgbd2D.velocity = transform.up * velocidade;
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Inimigo" && collider.GetComponent<Humanoid>().nivelTerreno == nivelTerreno)
        {
            collider.SendMessageUpwards("AplicarDano", dano);
            Instantiate(explosao, collider.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Limite")
        {
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Obstaculo" && nivelTerreno == NiveisTerrenos.Chao)
        {
            Destroy(gameObject);
        }
    }
}
