using UnityEngine;

public class ComportamientoPuerta : MonoBehaviour
{
    [SerializeField] private float angulo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("sexo");
        if (other.gameObject.CompareTag("Player"))
        {
            transform.rotation = Quaternion.Euler(0f, angulo, 0f);
        }
    }

}
