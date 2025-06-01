using UnityEngine;

public class Door : MonoBehaviour, IInteractuable
{
    public bool open;

    public GameObject pivot;

    public float anguloFinal = 90f;
    public float velocidad = 1f;

    public float anguloInicial = 0f;
    private float anguloActual;

    void Update()
    {
        float objetivoAngulo = open ? anguloFinal : anguloInicial;
        anguloActual = Mathf.LerpAngle(anguloActual, objetivoAngulo, Time.deltaTime * velocidad);

        pivot.transform.rotation = Quaternion.Euler(0f, anguloActual, 0f);
    }

    public void Interact()
    {
        open = !open;
    }
}
