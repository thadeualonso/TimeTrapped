using UnityEngine;
using System.Collections;

public class TakaLanca : Projetil{

    void Start()
    {
        Invoke("MudaNivelTerreno", 0.6f);
        Invoke("ChamarCurva", 0.6f);
        Invoke("Destruir", 3f);
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * velocidade;
    }

    void ChamarCurva()
    {
        StartCoroutine(Curva());
    }

    IEnumerator Curva()
    {
        while (true)
        {
            if (direcao == Direcoes.Left)
            {
                transform.Rotate(0f, 0f, 20f);
            }

            if (direcao == Direcoes.Right)
            {
                transform.Rotate(0f, 0f, -20f);
            }

            yield return new WaitForSeconds(0.8f);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && collider.GetComponent<Personagem>().nivelTerreno == nivelTerreno)
        {
            collider.SendMessageUpwards("AplicarDano", dano);
            collider.gameObject.GetComponent<Personagem>().sourceAudio.clip = hitSound;
            collider.gameObject.GetComponent<Personagem>().sourceAudio.Play();
            Instantiate(explosao, collider.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Obstaculo" && nivelTerreno == NiveisTerrenos.Chao)
        {
            Destroy(gameObject);
        }
    }

    void MudaNivelTerreno()
    {
        nivelTerreno = NiveisTerrenos.Chao;
    }

}
