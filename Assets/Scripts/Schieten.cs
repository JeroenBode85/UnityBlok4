using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Schieten : MonoBehaviour
{
    #region prev
    [Header("Basic Shooting")]
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public int speed = 5;
    #endregion

    //Scriptable Objects
    [Header("Basic Info Sciptbale Objects")]
    [SerializeField] Transform bulletSpawnpoint;
    [SerializeField] GameObject bullet;

    [Header("BulletType info")]
    [SerializeField] BulletScriptableObjects[] myScriptableBullets;
    [SerializeField] int bulletType;

    private void Start()
    {
        bulletType = 0;
    }
    void OnShoot()
    {
        #region Basic Shooting
        //var bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody>().velocity = spawnPoint.transform.forward * speed;
        #endregion

        #region Scriptable Object Shooting
        //Instantiate de Bullet
        GameObject newBullet = Instantiate(bullet, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
        newBullet.name = myScriptableBullets[bulletType].bName;

        //Geef de Bullet de informatie die je in het ScriptableObject hebt ingevuld
        newBullet.GetComponent<Renderer>().material = myScriptableBullets[bulletType].bMaterial;
        Rigidbody rbnewBullet = newBullet.GetComponent<Rigidbody>();
        rbnewBullet.AddForce(rbnewBullet.transform.forward * myScriptableBullets[bulletType].bSpeed);

        //Vernietig de Bullet nadat zijn LiveTime voorbij is
        Destroy(newBullet, myScriptableBullets[bulletType].bLiveTime);

        #endregion

    }

    void OnSwitch()
    {
        //Verander het type Bullet dat je schiet
        bulletType++;

        if (bulletType >= myScriptableBullets.Length) 
        {
            bulletType = 0;
        }
    }
}
