using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class GameManagerTeste : Singleton<GameManagerTeste> {

    #region VARIAVEIS

    // Contador de tempo
    public float timer;
    // Eixo horizontal do input do jogador
    public float analogHorizontal;
    // Flag indicando o inicio do jogo
    public bool gameStart;
    // Flag indicando se não existe nenhum personagem em cena
    public bool semPjsNaCena;
    // Flag indicando que o jogador está selecionando o proximo personagem para jogar
    public bool emSelecao;
    // Flag indicando se o input do jogador está sendo usado 
    public bool stickInUse;
    // Indice do array de personagens na equipe
    public int indicePjsNaEquipe;
    // Quantidade de personagens presente na equipe
    public int countEquipe;
    // Quantidade de personagens presentes na cena
    public int countPjsEmCena;
    // Equipe com todos os personagens
    public List<GameObject> pjsNaEquipe;
    // Array guardando os personagens na equipe
    public List<GameObject> pjsEmCena;
    // GameObject que representa o local de spawn do jogador
    public Transform spawnP1;
    // Imagem do jogador 1
    public Image avatarP1;

    #endregion

    #region COMPONENTES DO SISTEMA

    // Componente responsavel por receber os inputs do jogador
    private InputManager inputManager;

    #endregion

    #region MÉTODOS DO UNITY

    void Awake()
    {
        // Método Awake herdado da classe Singleton
        base.Awake();

        // Recebe a contagem de personagens presentes na cena atual
        countPjsEmCena = ContaPjsNaCena();
        // Recebe a contagem de personagens presentes na equipe
        countEquipe = ContaEquipe();
        // Procura e recebe o componente 'Transform' associado ao objeto
        spawnP1 = GameObject.Find("SpawnP1").GetComponent<Transform>();

        // Procura e associa a imagem do jogador 1 a variavel 'avatarP1'
        avatarP1 = GameObject.Find("imgAvatarP1").GetComponent<Image>();

        // Recebe a instancia do InputManager presente na cena
        inputManager = GameObject.FindObjectOfType<InputManager>();
    }

    void Start()
    {
        // Atribui a foto do 1º personagem na equipe no avatarP1
        avatarP1.sprite = pjsNaEquipe[0].GetComponent<Personagem>().avatar;
        // Ativa a flag indicando que o jogador está selecionando o personagem
        emSelecao = true;
    }

    void Update()
    {
        // Atualiza constantemente a quantidade de personagens na equipe
        countEquipe = ContaEquipe();
        // Atualiza constantemente a quantidade de personagens presentes na cena
        countPjsEmCena = ContaPjsNaCena();

        #region INPUT DO JOGADOR

        // analogHorizontal recebe constantemente o eixo horizontal do input do jogador
        analogHorizontal = inputManager.horizontal;

        // Checa se o jogador movimentou os botões direcionais
        if (analogHorizontal != 0f && emSelecao)
        {
            // Se o eixo estiver sendo puxado para direita...
            if (analogHorizontal >= 0.1f)
            {
                // Chama o método de selecao de personagem passando a direção por parametro
                SelecionarPersonagem("direita");
            }
            // Se o eixo estiver sendo puxado para esquerda...
            else if (analogHorizontal <= -0.1f)
            {
                // Chama o método de selecao de personagem passando a direção por parametro
                SelecionarPersonagem("esquerda");
            }
        }
        else
        {
            // Desativa a flag para indicar que o input não está mais em uso
            stickInUse = false;
        }

        //Checa se o jogador pressionou o botão de ataque normal
        if (Input.GetButtonDown("A"))
        {
            Spawn();
        }

        #endregion

        #region VERIFICAÇÃO DE PERSONAGENS

        // Checa se existe algum personagem na tela. Caso não tenha...
        if (countPjsEmCena <= 0)
        {
            // Ativa a flag 'semPjsNaCena'
            semPjsNaCena = true;
        }
        // Caso contrário...
        else
        {
            // Desativa a flag
            semPjsNaCena = false;
        }

        // Se o jogo estiver iniciado...
        if (gameStart)
        {
            // Começa a decrementar o contador de tempo
            timer -= Time.deltaTime;
        }

        // Se não houver personagens na cena...
        if (semPjsNaCena)
        {
            // Se a contagem de personagens na equipe for menor ou igual a 0...
            if (countEquipe <= 0)
            {
                // Chama o método GameOver
                GameOver();
            }
            // Caso contrário...
            else
            {
                // Entra em modo de seleção de personagem
                emSelecao = true;
            }
        }
        // Caso contrário...
        else
        {
            // Retoma o jogo
            gameStart = true;
            // Desativa a seleção de personagem
            emSelecao = false;
        }

        #endregion  
    }

    #endregion

    #region MÉTODOS PERSONALIZADOS

    private void GameOver()
    {
        throw new NotImplementedException();
    }

    // Percorre o array 'pjsNaEquipe' e retorna a quantidade de personagens presentes
    int ContaEquipe()
    {
        countEquipe = 0;

        foreach (GameObject pj in pjsNaEquipe)
        {
            if(pj != null)
            {
                countEquipe++;
            }
        }

        return countEquipe;
    }

    // Percorre o array 'pjsNaCena' e retorna a quantidade de personagens em cena
    int ContaPjsNaCena()
    {
        countPjsEmCena = 0;

        foreach (GameObject pj in pjsEmCena)
        {
            if(pj != null)
            {
                countPjsEmCena++;
            }
        }

        return countPjsEmCena;
    }

    // Faz o spawn dos personagens na cena seguindo as restrições das regras
    void Spawn()
    {
        // Se a seleção de personagens estiver ativa...
        if (emSelecao)
        {
            // Instancia o personagem selecionado no local do Spawn
            Instantiate(pjsNaEquipe[indicePjsNaEquipe], spawnP1.position, Quaternion.identity);
            // Desativa a seleção de personagem
            emSelecao = false;

            // Atualiza a lista 'pjsEmCena' a cada novo spawn
            GameObject[] arrayPjsEmCena = GameObject.FindGameObjectsWithTag("Player");

            // Percorre o arrayPjsEmCena
            foreach (GameObject pj in arrayPjsEmCena)
            {
                // Adiciona a lista cada pj contido no array
                pjsEmCena.Add(pj);
            }
        }

    }

    // Gerencia a seleção de personagens através pelo array de personagens na equipe
    void SelecionarPersonagem(string direcao)
    {
        #region CHECA A DIREÇÃO QUE O JOGADOR SELECIONOU E ANDA NO ARRAY CONFORME A DIREÇÃO

        // Se a direção passada for 'direita'...
        if (direcao == "direita")
        {
            // Se o input do jogador não estiver em uso...
            if (stickInUse == false)
            {
                // Se o indice atual for igual ao ultimo personagem do array...
                if (indicePjsNaEquipe == pjsNaEquipe.Count - 1)
                {
                    // Muda o indice para o 1º personagem do array
                    indicePjsNaEquipe = 0;
                }
                // Caso contrário...
                else
                {
                    // Incrementa o indice
                    indicePjsNaEquipe++;
                }

                //
                avatarP1.sprite = pjsNaEquipe[indicePjsNaEquipe].GetComponent<Personagem>().avatar;

                // Ativa a flag indicando que o jogador está usando o input
                stickInUse = true;
            }

        }
        // Caso contrário, se a direção for 'esquerda'...
        else if (direcao == "esquerda")
        {
            if (stickInUse == false)
            {
                // Se o indice atual estiver no 1º personagem do array...
                if (indicePjsNaEquipe == 0)
                {
                    // Muda o indice para o ultimo personagem do array
                    indicePjsNaEquipe = pjsNaEquipe.Count - 1;
                }
                // Caso contrário...
                else
                {
                    // Decrementa o indice
                    indicePjsNaEquipe--;
                }

                //
                avatarP1.sprite = pjsNaEquipe[indicePjsNaEquipe].GetComponent<Personagem>().avatar;

                // Ativa a flag indicando que o jogador está usando o input
                stickInUse = true;
            }
        }

        #endregion
    }

    // Remove os personagens mortos da equipe e da cena atual
    public void RemoverDaEquipe()
    {
        // Remove o personagem da equipe baseado no indice atual
        pjsNaEquipe.RemoveAt(indicePjsNaEquipe);

        // Remove o personagem da cena baseado no indice atual
        pjsEmCena.RemoveAt(indicePjsNaEquipe);
    }

    // Adiciona um personagem na equipe
    public void AdicionaNaEquipe(GameObject pj)
    {
        pjsNaEquipe.Add(pj);
    }

    #endregion
}
