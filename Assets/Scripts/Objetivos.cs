using UnityEngine;
using TMPro;

public class Objetivos : MonoBehaviour
{
    public ControladorPersonaje player;

    public TextMeshProUGUI cabaña1;
    public TextMeshProUGUI cabaña2;
    public TextMeshProUGUI cabaña3;
    public TextMeshProUGUI hazlo;

    void Start()
    {
        cabaña1.fontStyle = FontStyles.Normal;
        cabaña1.color = Color.white;
        cabaña2.fontStyle = FontStyles.Normal;
        cabaña2.color = Color.white;
        cabaña3.fontStyle = FontStyles.Normal;
        cabaña3.color = Color.white;
        hazlo.color = Color.white;
        hazlo.fontStyle = FontStyles.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.canon)
        {
            cabaña1.fontStyle = FontStyles.Strikethrough;
            cabaña1.color = Color.gray;
        }
        if (player.culata)
        {
            cabaña2.fontStyle = FontStyles.Strikethrough;
            cabaña2.color = Color.gray;
        }
        if (player.bala)
        {
            cabaña3.fontStyle = FontStyles.Strikethrough;
            cabaña3.color = Color.gray;
        }
        if (player.canon && player.culata && player.bala)
        {
            hazlo.fontStyle = FontStyles.Strikethrough;
            hazlo.color = Color.gray;
        }
    }
}
