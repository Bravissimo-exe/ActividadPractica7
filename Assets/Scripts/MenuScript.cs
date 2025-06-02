using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CargarEscena()
    {
        SceneManager.LoadScene(1);
    }

    public void SalirJuego()
    {
        Application.Quit();
        // Solo para verificar en el editor
        Debug.Log("Saliendo del juego...");
    }
}
