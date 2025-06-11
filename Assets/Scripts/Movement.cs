using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float rotationSpeed = 100f;

    private Player inputActions;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new Player(); // Initialiseer de input actions
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        // Gebruik de juiste Action Map en Actions:
        Vector3 moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector3>();
        float rotationInput = inputActions.PlayerControls.Rotate.ReadValue<float>();

        // Beweging toepassen (lokale ruimte)
        Vector3 moveDir = (transform.forward * moveInput.z) + (transform.right * moveInput.x);
        //transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;

        // Rotatie toepassen om de Y-as
        rb.velocity = moveSpeed * moveDir.normalized;

        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);//rotationInput

        // Debug.Log(transform.forward);
    }
    
}
