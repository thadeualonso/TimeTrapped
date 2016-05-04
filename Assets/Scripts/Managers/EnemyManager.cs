using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public int inimigosCont;
    public bool todosInimigosMortos = false;
    public Portal portal;

    void Update()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        inimigosCont = inimigos.Length;

        if (inimigosCont <= 0)
        {
            if (FindObjectOfType<Portal>() != null)
            {
                FindObjectOfType<Portal>().AbrirPortal(true);
            }
        }
    }

}
