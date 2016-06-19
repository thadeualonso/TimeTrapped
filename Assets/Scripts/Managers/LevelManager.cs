using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager> {

    public Telas telaAtual;

    void Update()
    {
        switch (telaAtual)
        {
            case Telas.TelaInicial  :
                TelaInicial();
                break;
            case Telas.MenuOpcoes   :
                MenuOpcoes();
                break;
            case Telas.MenuControles:
                MenuControles();
                break;
            case Telas.TelaJogo     :
                TelaJogo();
                break;
            case Telas.MenuPausa    :
                MenuPausa();
                break;
            case Telas.TelaGameOver :
                TelaGameOver();
                break;
        }
    }

    public void SetCurrentState(Telas tela)
    {
        this.telaAtual = tela;
    }

    void TelaInicial()
    {

    }

    void MenuOpcoes()
    {
        Debug.Log("Estado: " + telaAtual);
    }

    void MenuControles()
    {
        Debug.Log("Estado: " + telaAtual);
    }

    void TelaJogo()
    {
        Debug.Log("Estado: " + telaAtual);
    }

    void MenuPausa()
    {
        //TODO: Implementar código para carregar o MenuPausa
    }

    void TelaGameOver()
    {
        //TODO: Implementar código para carregar a cena TelaGameOver
    }

}
