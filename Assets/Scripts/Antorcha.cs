using UnityEngine;
using UnityEngine.UI;

public class Antorcha : MonoBehaviour
{
    public GameObject antorcha;
    public float maxTime;
    public float timer;
    public bool antorchaActiva;
    public Slider sliderTimer;
    void Start()
    {
        antorchaActiva = false;
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            antorchaActiva = !antorchaActiva;
        }
        ToggleTorch();
    }

    public void ToggleTorch()
    {
        sliderTimer.value = timer/maxTime;
        if (antorchaActiva)
        {
            timer -= Time.deltaTime;
            antorcha.SetActive(true);
            if(timer <= 0)
            {
                antorchaActiva = false;
            }
        }
        else
        {
            if(timer < maxTime)
            {
                timer += Time.deltaTime;
            }
            antorcha.SetActive(false);
        }
    }
}
