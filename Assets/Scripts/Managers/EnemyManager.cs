using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public int inimigosCont;
    public bool todosInimigosMortos = false;

    void Update()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        inimigosCont = inimigos.Length;
    }

}
