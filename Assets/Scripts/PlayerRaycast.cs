using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float rayLength = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Tekenen de ray voor debugging purposes
            Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayLength, layerMask))
            {
                Physics2D.Raycast(transform.position, transform.right, rayLength, layerMask);
                //Hier doen we dingen
                Debug.Log(hit.collider.name);
            }
        }

        if (Input.GetMouseButton(1))
        {
            Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);
            RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, rayLength);
            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Debug.Log(hits[i].collider.name);
                }
            }
        }

    }
}
