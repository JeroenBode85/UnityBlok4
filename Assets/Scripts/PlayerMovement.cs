using UnityEngine;
using UnityEngine.InputSystem;

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

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

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
}
