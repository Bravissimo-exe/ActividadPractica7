using UnityEngine;

public class Arma : MonoBehaviour, IInteractuable
{
    public enum Parte {Canon, Culata, Bala, Barra}
    public Parte parte;

    public ControladorPersonaje player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControladorPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        switch (parte)
        {
            case Parte.Canon:
                player.canon = true;
                Destroy(gameObject);
                break;
            case Parte.Culata:
                player.culata = true;
                Destroy(gameObject);
                break;
            case Parte.Bala:
                player.bala = true;
                Destroy(gameObject);
                break;
            case Parte.Barra:
                player.barra = true;
                Destroy(gameObject);
                break;
        }
    }
}
