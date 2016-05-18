using UnityEngine;
using System.Collections;

public class PlayerWagnur : Personagem {

    

    public override void Ataque()
    {
        if (Input.GetButtonDown("A"))
        {
            WagnurLanca lanca = (WagnurLanca) Instantiate(tiro, transform.position, Quaternion.identity);
            lanca.direcao = direcao;
        }
    }

}
