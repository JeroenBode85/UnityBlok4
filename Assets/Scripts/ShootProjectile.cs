using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [Header("Dit script wordt direct vanuit je New Input System Map aangeroepen")]

    [SerializeField]
    private GameObject item;
    [SerializeField]
    private Transform spawnPoint;
    // Start is called before the first frame update

    void OnShoot()
    {
        Debug.Log("test");
        var throwable = Instantiate(item, spawnPoint.position, Quaternion.identity);
        throwable.GetComponent<Rigidbody>().velocity = spawnPoint.transform.forward * 5;
    }

    void OnTest()
    {
        Debug.Log("Hallo");
    }
}
