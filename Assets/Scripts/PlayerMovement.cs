using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private bool movingForward;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject head;

    private bool turning;
    private float turningDirection;
    private Rigidbody rb;
    private Vector2 movementInput;

    //Met deze methode heeft de student direct meer zicht en controle over wat hij doet/toevoegd maar het is niet heel efficient werken
    #region InputSystemSuze1
    ////Individueel in te vullen in de inspector
    //[Header ("Player Controls")]
    //public InputAction playerMovement;
    //public InputAction playerRotation;
    //public InputAction playerShoot;
    #endregion

    //Met deze methode maakt de student gebruik van de window/editor die Unity zelf al geeft. Minder werk in de editor
    #region InputSystemSuze2
    public Player playerInputActions;
    private float rotation;
    private Vector3 movementInputV3;
    public float rotationalSpeed;

    private float shoot;

    [SerializeField]
    private GameObject item;
    [SerializeField]
    private Transform spawnPoint;


    ////Individuele onderdelen aan/uit zetten
    //private InputAction move;
    //private InputAction shoot;
    //private InputAction rotate;
    #endregion

    #region InputSystemChristiaan
    //InputValue is een script dat automatisch met UnityEngine.InputSystem geleverd wordt, deze checkt of de speler input geeft volgens jouw instellingen in de New Input System.
    //Hiervoor moet je wel het "Player Input" component op je player hebben staan, een input action hebben toegewezen en de juiste Map geselecteerd hebben
    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
    #endregion
    #region InputSystemSuze1
    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    ////Zodat de speler de Inputsystem alleen gebruikt wanneer het GameObject enabled is
    //private void OnEnable()
    //{
    //    playerMovement.Enable();
    //}

    //private void OnDisable()
    //{
    //    playerMovement.Disable();
    //}

    //private void Update()
    //{
    //    movementInputV3 = playerMovement.ReadValue<Vector3>();
    //}

    //private void FixedUpdate()
    //{
    //    rb.velocity = movementInputV3 * speed;
    //}
    #endregion
    #region InputSystemSuze2
    private void Awake()
    {
        //Om het script te initialiseren
        playerInputActions = new Player();
        rb = GetComponent<Rigidbody>();
    }

    //Zodat de speler de Inputsystem alleen gebruikt wanneer het GameObject enabled is
    private void OnEnable()
    {
        playerInputActions.Enable();

        #region Losse onderdelen aanzeten
        //move = playerInputActions.PlayerControls.Movement;
        //move.Enable();
        //rotate = playerInputActions.PlayerControls.Rotate;
        //rotate.Enable();
        //shoot = playerInputActions.PlayerControls.Shoot;
        //shoot.Enable();
        #endregion
    }

    private void OnDisable()
    {
        playerInputActions.Disable();

        #region Losse onderdelen uitzetten
        //move.Disable();
        //rotate.Disable();
        //shoot.Disable();
        #endregion
    }

    //Gebruik Update voor het meten van input en render vraagstukken
    private void Update()
    {
        movementInputV3 = playerInputActions.PlayerControls.Movement.ReadValue<Vector3>();
        rotation = playerInputActions.PlayerControls.Rotate.ReadValue<float>();
        shoot = playerInputActions.PlayerControls.Shoot1.ReadValue<float>();
    }

    //Gebruik FixedUpdate voor berekeningen
    private void FixedUpdate()
    {
        //Movement dmv transform.position
        //transform.position += transform.forward * movementInputV3.z * Time.deltaTime * speed;

        //Movement dmv Rigidbody
        Vector3 moveDir = (transform.forward * movementInputV3.z);
        rb.velocity = moveDir * speed;

        transform.Rotate(Vector3.up * Time.deltaTime * rotationalSpeed * rotation);

        if (shoot > 0)
        {
            Shoot();
        }
    }
    #endregion

    void Shoot()
    {
        Debug.Log("test");
        var throwable = Instantiate(item, spawnPoint.position, Quaternion.identity);
        throwable.GetComponent<Rigidbody>().velocity = spawnPoint.transform.forward * 5;
    }

    #region Aiming?
    //private void OnAim(InputValue value)
    //{
    //        Debug.Log("Aiming");
    //        var aimingInput = value.Get<float>();
    //        if (aimingInput != 0)
    //        {
    //            turning = true;
    //            turningDirection = aimingInput;
    //        }
    //        else
    //        {
    //            turning = false;
    //            turningDirection = 0;
    //        }
    //}
    #endregion

    #region InputSystemChristiaan
    ///*
    //private void Update()
    //{
    //    var movement = new Vector3(movementInput.x, 0, movementInput.y);

    //    if (!movingForward)
    //    {
    //        transform.position += movement * Time.deltaTime * speed;
    //    }
    //    else
    //    {
    //        transform.rotation *= Quaternion.Euler(0, movement.x, 0);
    //        transform.position += transform.forward * movement.z * Time.deltaTime * speed;
    //    }

    //GetKey in nieuwe input system

    // Draai de head alleen als er geen beweging is
    //Niet van toepassing voor de 2 blokjes
    //if (movement.magnitude == 0)
    //{
    //    head.transform.Rotate(0, turningDirection, 0);
    //}
    //}
    //*/
    #endregion
}
