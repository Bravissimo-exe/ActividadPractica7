using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Antorcha verAntorcha;
    public NavMeshAgent enemyIA;
    public Transform objetivoActual;
    public Transform[] puntosPatrulla;
    public int indicetarget;
    public bool ataque;
    public GameObject head;

    public GameObject objetivos;
    public GameObject muerte;

    public float timer;

    public GameObject luz;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        verAntorcha = player.GetComponent<Antorcha>();
        enemyIA = GetComponent<NavMeshAgent>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Target();
    }

    public void Target()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 2f)
        {
            ataque = true;
        }
        if (!ataque)
        {
            objetivos.SetActive(true);
            muerte.SetActive(false);
            luz.SetActive(false);
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
                        indicetarget = Random.Range(0, puntosPatrulla.Length);
                        enemyIA.SetDestination(puntosPatrulla[indicetarget].position);
                    }
                }

            }
        }
        if (ataque)
        {
            objetivos.SetActive(false);
            muerte.SetActive(true);
            luz.SetActive(true);

            objetivoActual = player.transform;
            enemyIA.SetDestination(objetivoActual.position);
            player.GetComponent<ControladorPersonaje>().walkSpeed = 0;
            enemyIA.speed = 0;
            transform.LookAt(player.transform);
            player.transform.LookAt(transform);
            Camera.main.transform.LookAt(head.transform);
            timer += Time.deltaTime;

            float change = Mathf.Clamp(timer, 0, 60);
            Camera.main.fieldOfView = Mathf.Lerp(60,0,change);

            if(timer >= 2)
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
