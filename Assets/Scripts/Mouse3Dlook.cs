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
            //Sla de positie van de muis ten opzichte van de speler op
            Vector3 lookDirection = raycastHit.point - transform.position;

            lookDirection.y = 0f; // Houd de rotatie alleen op de horizontale as. De kubus probeert met alle macht naar
                                  // de desbetreffende positie te draaien namelijk waardoor hij voor de vloer heen clipt.
                                  //Dit zorgt voor frictie tussen de collider van de box en die van de vloer waardoor
                                  //de box gaat schuiven
            if (lookDirection != Vector3.zero)
            {
                // Richt de speler naar de muis
                Quaternion rotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = rotation;
            }
        }
    }
}

