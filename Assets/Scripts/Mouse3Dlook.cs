using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse3Dlook : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            // Richt de speler naar de muis
            Vector3 lookDirection = raycastHit.point - transform.position;
            lookDirection.y = 0f; // Houd de rotatie alleen op de horizontale as
            if (lookDirection != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = rotation;
            }
        }
    }
}

