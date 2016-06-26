using UnityEngine;
using System.Collections;

public class EnemyManager : Singleton<EnemyManager> {

    public int inimigosCont;
    public bool todosInimigosMortos = false;
    public Portal portal;

    void Update()
    {
        Inimigo[] inimigos = GameObject.FindObjectsOfType<Inimigo>();
        
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
