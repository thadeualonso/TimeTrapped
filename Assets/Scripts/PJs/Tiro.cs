using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {

    public float velocidade;
    public Direcoes direcao;
    public NiveisTerrenos nivelTerreno;
    public float dirX;
    public float dirY;
	
	// Update is called once per frame
	void Update ()
    {
        switch (direcao)
        {
            case Direcoes.Right:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f);
                break;
            case Direcoes.Left:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f);
                break;
            case Direcoes.Up:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f);
                break;
            case Direcoes.Down:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f);
                break;
            case Direcoes.UpRight:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f);
                break;
            case Direcoes.UpLeft:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f);
                break;
            case Direcoes.DownRight:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f);
                break;
            case Direcoes.DownLeft:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f);
                break;
        }
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Inimigo" && collider.GetComponent<Humanoid>().nivelTerreno == nivelTerreno)
        {
            Debug.Log("Colidiu com inimgo");
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
