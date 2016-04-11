using UnityEngine;
using Pathfinding;
using System;
using System.Collections;

[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour {

    // O objeto que irá ser perseguido
    public Transform target;
    // Quantidade de vezes por segundo que o path será atualizado 
    public float updateRate = 4f;
    // Velocidade de movimento 
    public float speed = 2f;
    // Distância entre o inimigo e o player
    public float distTarget;
    // A distância máxima entre o inimigo e o proximo waypoint
    public float nextWayPointDistance = 3f;
    // O Caminho calculado
    public Path path;   

    // Componente do A* Pathfinding que possibilita o objeto ser um "buscador"
    private Seeker seeker;
    // O atual waypoint em que o inimigo está localizado
    private int currentWayPoint;

    [HideInInspector]
    // Flag para indicar se o caminho chegou ao fim
    public bool pathIsEnded = false;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Método executado ao iniciar o jogo
    void Start()
    {
        // Recebe a referência do componente Seeker 
        seeker = GetComponent<Seeker>();

        // Se a referência do target for nula...
        if (target == null)
        {
            // Mostra a seguinte mensagem de erro no console
            Debug.LogError("Nenhum target foi associado");
            // Encerra o método
            return;
        }

        // Inicia um novo caminho até a posição do target e retorna o resultado para o método OnPathComplete
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        // Inicia a coroutine para atualizar o caminho do inimigo
        StartCoroutine(UpdatePath());
    }

    // Coroutine que atualiza o caminho do inimigo frequentemente (fora do update)
    private IEnumerator UpdatePath()
    {
        // Procura o Player na cena e guarda o Transform dele
        target = GameObject.FindWithTag("Player").transform;

        // Cria um novo caminho direcionado ao target encontrado
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        // Define a taxa de atualização dos caminhos
        yield return new WaitForSeconds(1f / updateRate);

        // Inicia novamente o método
        StartCoroutine(UpdatePath());
    }

    // Método chamado ao concluir o caminho até o target
    public void OnPathComplete(Path p)
    {
        // Debug de possíveis erros
        Debug.Log("Caminho encontrado. Ocorreu algum erro? " + p.error);

        // Se não houver nenhum erro...
        if (!p.error)
        {
            // path recebe o caminho passado por seeker.StartPath
            path = p;
            // Reseta o waypoint atual
            currentWayPoint = 0;
        }
    }

    // Método executado a cada frame
    void Update()
    {
        // Se a referência do target for nula, encerra o método
        if (target == null) { return; }

        //TODO: Sempre olhar para o player

        // Se o caminho for nulo, encerra o método
        if (path == null) { return; }

        // Se chegar ao final do caminho...
        if(currentWayPoint >= path.vectorPath.Count)
        {
            // Se ja estiver no fim do caminho, apenas retorna
            if (pathIsEnded) { return; }

            // Mostra mensagem no console
            Debug.Log("Fim do caminho alcançado");

            // Ativa a flag que indica o fim do caminho
            pathIsEnded = true;

            return;
        }

        // Define a flag que indica o fim do caminho como falso a cada frame
        pathIsEnded = false;

        // Direção para o proximo waypoint
        Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized;
        dir *= speed * Time.deltaTime;

        // Mover o AI 
        transform.Translate(dir);

        // Distância entre o inimigo e o próximo waypoint
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);

        // Se a distância for menor que o waypoint mais proximo...
        if (dist < nextWayPointDistance)
        {
            // Incrementa o waypoint atual
            currentWayPoint++;
            return;
        }

        distTarget = Vector3.Distance(transform.position, target.position);

        if (distTarget <= 3)
        {
            Debug.Log("Shoot");
            
        }
    }

}
