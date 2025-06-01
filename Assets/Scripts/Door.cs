using UnityEngine;

public class Door : MonoBehaviour, IInteractuable
{
    public bool open;

    public ControladorPersonaje player;

    public GameObject pivot;

    public float anguloFinal = 90f;
    private float velocidad = 6f;

    public float anguloInicial = 0f;
    private float anguloActual;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControladorPersonaje>();
    }
    void Update()
    {
        float objetivoAngulo = open ? anguloFinal : anguloInicial;
        anguloActual = Mathf.LerpAngle(anguloActual, objetivoAngulo, Time.deltaTime * velocidad);

        pivot.transform.rotation = Quaternion.Euler(0f, anguloActual, 0f);
    }

    public void Interact()
    {
        if (player.barra)
        {
            open = !open;
        }
    }
}
