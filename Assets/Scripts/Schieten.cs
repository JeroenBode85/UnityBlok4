
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class Schieten : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public int speed = 5;

    void OnShoot()
    {
        var bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = spawnPoint.transform.forward * speed;
    }
}
