using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {

    public float velocidade;
    public Direcoes direcao;
    public NiveisTerrenos nivelTerreno;
    public float dirX;
    public float dirY;
    public int dano;
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * velocidade;
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Inimigo" && collider.GetComponent<Humanoid>().nivelTerreno == nivelTerreno)
        {
            Debug.Log("Colidiu com inimgo");
            collider.SendMessageUpwards("AplicarDano", dano);
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Limite")
        {
            Debug.Log("Colidiu com limites da fase");
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Obstaculo" && nivelTerreno == NiveisTerrenos.Chao)
        {
            Debug.Log("Colidiu com algum obstaculo");
            Destroy(gameObject);
        }

    }

}
