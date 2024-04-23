using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnShoot()
    {
        Debug.Log("test");
        var throwable = Instantiate(item,spawnPoint.position,Quaternion.identity);
        throwable.GetComponent<Rigidbody>().velocity = spawnPoint.transform.forward*5;
    }
}
