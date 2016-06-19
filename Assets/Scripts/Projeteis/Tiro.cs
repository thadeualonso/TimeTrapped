using UnityEngine;
using System.Collections;

public class Tiro : Projetil {

    [SerializeField]
    private GameObject explosaoTiro;

    void Start()
    {
        Invoke("Destruir", 0.6f);

        if (direcao == Direcoes.Up)         { transform.rotation = Quaternion.Euler(0f, 0f, 0f);    }
        if (direcao == Direcoes.Down)       { transform.rotation = Quaternion.Euler(0f, 0f, 180f);  }
        if (direcao == Direcoes.Right)      { transform.rotation = Quaternion.Euler(0f, 0f, -90f);  }
        if (direcao == Direcoes.Left)       { transform.rotation = Quaternion.Euler(0f, 0f, 90f);   }
        if (direcao == Direcoes.UpRight)    { transform.rotation = Quaternion.Euler(0f, 0f, 325f);  }
        if (direcao == Direcoes.UpLeft)     { transform.rotation = Quaternion.Euler(0f, 0f, -325f); }
        if (direcao == Direcoes.DownRight)  { transform.rotation = Quaternion.Euler(0f, 0f, -135f); }
        if (direcao == Direcoes.DownLeft)   { transform.rotation = Quaternion.Euler(0f, 0f, 135f);  }
    }

	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * velocidade;
    }

    public override void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Inimigo" /*&& other.GetComponent<Humanoid>().nivelTerreno == nivelTerreno*/)
        {
            other.SendMessageUpwards("AplicarDano", dano);
            Instantiate(explosao, other.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Limite")
        {
            Debug.Log("Colidiu com limites da fase");
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Obstaculo" && nivelTerreno == NiveisTerrenos.Chao)
        {
            Debug.Log("Colidiu com algum obstaculo");
            //Instantiate(explosaoTiro, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

}
