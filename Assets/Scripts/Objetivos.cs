using UnityEngine;
using TMPro;

public class Objetivos : MonoBehaviour
{
    public ControladorPersonaje player;

    public TextMeshProUGUI caba�a1;
    public TextMeshProUGUI caba�a2;
    public TextMeshProUGUI caba�a3;
    void Start()
    {
        caba�a1.fontStyle = FontStyles.Normal;
        caba�a1.color = Color.white;
        caba�a2.fontStyle = FontStyles.Normal;
        caba�a2.color = Color.white;
        caba�a3.fontStyle = FontStyles.Normal;
        caba�a3.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.canon)
        {
            caba�a1.fontStyle = FontStyles.Strikethrough;
            caba�a1.color = Color.gray;
        }
        if (player.culata)
        {
            caba�a2.fontStyle = FontStyles.Strikethrough;
            caba�a2.color = Color.gray;
        }
        if (player.bala)
        {
            caba�a3.fontStyle = FontStyles.Strikethrough;
            caba�a3.color = Color.gray;
        }
    }
}
