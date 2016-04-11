using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuFSM : MonoBehaviour {

    public enum States { MenuInicial, MenuOpcoes, TelaJogo };
    public States myStates;
    public GameObject[] opcoes;

    void Start()
    {
        myStates = States.MenuInicial;
    }

    void Update()
    {
        switch (myStates)
        {
            case States.MenuInicial: MenuInicial(); break;
            case States.MenuOpcoes: MenuOpcoes(); break;
            case States.TelaJogo: TelaJogo(); break;
        }
    }

    void MenuInicial()
    {
        
    }

    void MenuOpcoes()
    {
        
    }

    void TelaJogo()
    {
        
    }
    
}
