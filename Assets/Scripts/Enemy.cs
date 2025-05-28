using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Antorcha verAntorcha;
    public NavMeshAgent enemyIA;
    public Transform objetivoActual;
    public Transform[] puntosPatrulla;
    public int indicetarget;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        verAntorcha = player.GetComponent<Antorcha>();
        enemyIA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Target();
    }

    public void Target()
    {
        if (verAntorcha.antorchaActiva)
        {
            objetivoActual = player.transform;
            enemyIA.SetDestination(objetivoActual.position);
        }
        else
        {
            if (enemyIA.destination == player.transform.position)
            {
                indicetarget = Random.Range(0, puntosPatrulla.Length);
                objetivoActual = puntosPatrulla[indicetarget];
                enemyIA.SetDestination(objetivoActual.position);
            }
            else
            {
                if (!enemyIA.pathPending && enemyIA.remainingDistance <= enemyIA.stoppingDistance)
                {
                    indicetarget = (indicetarget + 1) % puntosPatrulla.Length;
                    enemyIA.SetDestination(puntosPatrulla[indicetarget].position);
                }
            }

        }
    }
}
