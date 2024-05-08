using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

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

    private Vector2 movementInput;

    //Met deze methode heeft de student direct meer zicht en controle over wat hij doet/toevoegd maar het is niet heel efficient werken
    #region InputSystemSuze1
    //Individueel in te vullen in de inspector
    [Header ("Player Controls")]
    public InputAction playerMovement;
    public InputAction playerRotation;
    public InputAction playerShoot;
    private Rigidbody rb;
    #endregion

    //Met deze methode maakt de student gebruik van de window/editor die Unity zelf al geeft. Minder werk in de editor
    #region InputSystemSuze2
    public Player playerInputActions;
    private InputAction move;
    private InputAction shoot;
    private InputAction rotate;
    private float rotation;
    private Vector3 movementInputV3;
    public float rotationalSpeed;
    #endregion

    #region InputSystemChristiaan
    //private void OnMove(InputValue value)
    //{        
    //    movementInput = value.Get<Vector2>();
    //}
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
        move = playerInputActions.PlayerControls.Move;
        move.Enable();
        rotate = playerInputActions.PlayerControls.Rotate;
        rotate.Enable();
        shoot = playerInputActions.PlayerControls.Shoot;
        shoot.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        rotate.Disable();
        shoot.Disable();
    }

    //Gebruik Update voor het meten van input en render vraagstukken
    private void Update()
    {
        movementInputV3 = move.ReadValue<Vector3>();
        rotation = rotate.ReadValue<float>();
    }

    //Gebruik FixedUpdate voor berekeningen
    private void FixedUpdate()
    {
        transform.position += transform.forward * movementInputV3.z * Time.deltaTime * speed;

        transform.Rotate(Vector3.up * Time.deltaTime * rotationalSpeed * rotation);
    }
    #endregion

    private void OnAim(InputValue value)
    {
            Debug.Log("Aiming");
            var aimingInput = value.Get<float>();
            if (aimingInput != 0)
            {
                turning = true;
                turningDirection = aimingInput;
            }
            else
            {
                turning = false;
                turningDirection = 0;
            }
    }

    #region InputSystemChristiaan
    /*
    private void Update()
    {
        var movement = new Vector3(movementInput.x, 0, movementInput.y);

        if (!movingForward)
        {
            transform.position += movement * Time.deltaTime * speed;
        }
        else
        {
            transform.rotation *= Quaternion.Euler(0, movement.x, 0);
            transform.position += transform.forward * movement.z * Time.deltaTime * speed;
        }

        //GetKey in nieuwe input system

        // Draai de head alleen als er geen beweging is
        if (movement.magnitude == 0)
        {
            head.transform.Rotate(0, turningDirection, 0);
        }
    }
    */
    #endregion
}
