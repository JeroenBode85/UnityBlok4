using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Throwable"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
