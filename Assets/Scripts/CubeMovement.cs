using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeMovement : MonoBehaviour
{
    public Player playerInputActions;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationalSpeed;
    public bool isRB;
    public bool canRotate;

    private InputAction move;
    private InputAction rotate;
    private float rotation;
    private Vector3 movementInput;
    private Rigidbody rb;

    private void Awake()
    {
        playerInputActions = new Player();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        move = playerInputActions.PlayerControls.Move;
        move.Enable();
        rotate = playerInputActions.PlayerControls.Rotate;
        rotate.Enable();
    }

    private void OnDisable()
    {
        move.Disable();   
        rotate.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = move.ReadValue<Vector3>();
        if (canRotate)
        {
            rotation = rotate.ReadValue<float>();
        }      
    }

    private void FixedUpdate()
    {
        if (isRB)
        {
            rb.velocity = speed * movementInput;
        }
        else
        {
            transform.position += transform.forward * movementInput.z * Time.deltaTime * speed;
            transform.position += transform.right * movementInput.x * Time.deltaTime * speed;
        }

        if (canRotate)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationalSpeed * rotation);
        }
        
    }
}
