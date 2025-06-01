using UnityEngine;
using TMPro;

public class ControladorPersonaje : MonoBehaviour
{

    //Movimiento
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpHeight = 1.9f;
    [SerializeField] private float gravityScale = -20f;

    private Vector3 movementVelocity = Vector3.zero;
    private CharacterController characterController;
    
    //Camara
    private float horizontalAxis;
    private float verticalAxis;

    public float rangoInteract;

    public TextMeshProUGUI textInteraction;

    private new Transform camera;
    public Vector2 sens = new Vector2(1f, 1f);

    private Vector3 centroPantalla;
    private Ray ray;
    private RaycastHit hit;

    //posecion de objetos
    public bool barra = false;

    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        camera = transform.Find("Camara");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Watch();
        Interact();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barra"))
        {
            barra = true;
            Debug.Log("Gongo");
            Destroy(other.gameObject);
        }
    }

    public void Watch()
    {
        horizontalAxis = Input.GetAxis("Mouse X");
        verticalAxis = Input.GetAxis("Mouse Y");

        if (horizontalAxis != 0)
        {
            transform.Rotate(Vector3.up * horizontalAxis * sens.x);
        }

        if (verticalAxis != 0)
        {
            //camera.Rotate(Vector3.left * verticalAxis * sens.y);
            float angle = (camera.localEulerAngles.x - verticalAxis * sens.y + 360) % 360;
            if (angle > 180) { angle -= 360; }
            angle = Mathf.Clamp(angle, -90, 90);

            camera.localEulerAngles = Vector3.right * angle;
        }

        centroPantalla = new Vector3(Screen.width / 2, Screen.height / 2, 0f);

        ray = Camera.main.ScreenPointToRay(centroPantalla);

        if (Physics.Raycast(ray, out hit, rangoInteract))
        {
            IInteractuable interactuable = hit.collider.GetComponent<IInteractuable>();
            if (interactuable != null)
            {
                textInteraction.gameObject.SetActive(true);
            }
        }
        else
        {
            textInteraction.gameObject.SetActive(false);
        }

    }
    
    public void Move()
    {
        //Sacamos las entradas
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1f); //limita el vector a 1

        //Definimos la velocidad
        float speed = Input.GetButton("Sprint") ? runSpeed : walkSpeed;
        Vector3 moveDirection = transform.TransformDirection(new Vector3(input.x, 0f, input.y)) * speed; //Lo pasamos a un Vector3

        // Movimiento horizontal -> al movimiento final
        movementVelocity.x = moveDirection.x;
        movementVelocity.z = moveDirection.z;

        // Comprobamos si el personaje está en el suelo
        if (characterController.isGrounded)
        {
            // movementVelocity.y = -2f; //si se pone el personaje empieza a bajar a salitos en pendientes
            if (Input.GetButtonDown("Jump"))
            {
                movementVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale); //Fórmula para el salto -> Raíz(-2a * d)
            }
        }
        else
        {
            // Aplicar gravedad (si no está en el piso)
            movementVelocity.y += gravityScale * Time.deltaTime;
        }

        characterController.Move(movementVelocity * Time.deltaTime);
    }
    
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (Physics.Raycast(ray, out hit, rangoInteract))
            {
                IInteractuable interactuable = hit.collider.GetComponent<IInteractuable>();
                if (interactuable != null)
                {
                    interactuable.Interact();
                }
            }
        }
    }
}
