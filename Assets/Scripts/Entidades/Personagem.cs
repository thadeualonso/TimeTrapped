using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Personagem : Humanoid
{
    public Projetil projetilNormal;
    public Projetil projetilEspecial;
    public int danoAtaqueNormal;
    public int danoAtaqueEspecial;

    private float horizontal;
    private float vertical;

    // Audios
    [HideInInspector]
    public AudioSource sourceAudio;
    public AudioClip[] soundEffects;

    [HideInInspector]
    public InputManager inputManager;

    // Cooldown de ataques
    [HideInInspector]
    public bool isShooting, canShootEspecial, canShootNormal;
    [HideInInspector]
    public float shootingTimer = 0, shootingCD = 0.3f, coolDownAtaqueEspecial, coolDownAtaqueNormal;
    public float delayAtaqueNormal;
    public float delayAtaqueEspecial;

    protected Rigidbody2D rgbd2D;

    void Awake()
    {
        base.Awake();

        sourceAudio = GetComponent<AudioSource>();
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (FindObjectOfType<InputManager>() != null)
        {
            inputManager = FindObjectOfType<InputManager>();
        }
        else
        {
            Debug.LogWarning("InputManager não encontrado");
        }
    }

    public override void Ataque()
    {
        ChecaCoolDown();

        projetilNormal.dano = danoAtaqueNormal;
        projetilNormal.direcao = direcao;
        projetilNormal.nivelTerreno = nivelTerreno;

        /*projetilEspecial.dano = danoAtaqueEspecial;
        projetilEspecial.direcao = direcao;
        projetilEspecial.nivelTerreno = nivelTerreno;*/
    }


    public void ChecaCoolDown()
    {
        if (isShooting)
        {
            if (shootingTimer > 0)
            {
                shootingTimer -= Time.deltaTime;
            }
            else
            {
                isShooting = false;
            }
        }

        if (coolDownAtaqueNormal >= 0.1f)
        {
            coolDownAtaqueNormal -= Time.deltaTime;
            canShootNormal = false;
        }
        else
        {
            canShootNormal = true;
        }


        if (coolDownAtaqueEspecial >= 0.1f)
        {
            coolDownAtaqueEspecial -= Time.deltaTime;
            canShootEspecial = false;
        }
        else
        {
            canShootEspecial = true;
        }
    }

    // Chamar no Update
    public override void Mover()
    {
        horizontal = inputManager.horizontal;
        vertical = inputManager.vertical;

        animator.SetFloat("SpeedX", horizontal);
        animator.SetFloat("SpeedY", vertical);

        Vector3 movement = new Vector3(horizontal * speed, vertical * speed, 0.0f);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    // Chamar no FixedUpdate
    public override void ChecaDirecao()
    {
        float lastInputX = horizontal;
        float lastInputY = vertical;

        if (lastInputX != 0f || lastInputY != 0f)
        {
            animator.SetBool("walking", true);

            // Direita
            if(lastInputX > 0.1f)
            {
                direcao = Direcoes.Right;
            }

            // Esquerda
            if (lastInputX < -0.1f)
            {
                direcao = Direcoes.Left;
            }

            // Cima
            if (lastInputY > 0.1f)
            {
                direcao = Direcoes.Up;
            }

            // Baixo
            if (lastInputY < -0.1f)
            {
                direcao = Direcoes.Down;
            }

            // Superior direito
            if (lastInputX > 0.1f && lastInputY > 0.1f)
            {
                direcao = Direcoes.UpRight;
            }

            // Superior esquerdo
            if (lastInputX < -0.1f && lastInputY > 0.1f)
            {
                direcao = Direcoes.UpLeft;
            }

            // Inferior direito
            if (lastInputX > 0.1f && lastInputY < -0.1f)
            {
                direcao = Direcoes.DownRight;
            }

            // Inferior esquerdo
            if (lastInputX < -0.1f && lastInputY < -0.1f)
            {
                direcao = Direcoes.DownLeft;
            }

            animator.SetFloat("LastX", horizontal);
            animator.SetFloat("LastY", vertical);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Nivel Superior")
        {
            nivelTerreno = NiveisTerrenos.Superior;
        }

        if (other.gameObject.CompareTag("TiroInimigo"))
        {
            this.hp--;
            SceneManager.LoadScene("TelaGameOver");
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Nivel Superior")
        {
            nivelTerreno = NiveisTerrenos.Chao;
        }
    }

}
