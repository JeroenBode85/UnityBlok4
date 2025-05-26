using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRaycast : MonoBehaviour
{
    [Header("Raycasting")]
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float rayLength = 10;

    #region Schieten
    [Header("Schieten")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private bool canShoot = false;
    private Player inputActions;
    #endregion

    private void Awake()
    {
        inputActions = new Player();
    }



    // Update is called once per frame
    void Update()
    {

        #region Raycast
        //New inputsystem muis
        if (Mouse.current.rightButton.IsPressed())
        {
            //Tekenen de ray voor debugging purposes
            Debug.DrawRay(transform.position, transform.forward * rayLength, Color.blue);
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayLength, layerMask))
            {
                //Hier doen we dingen
                Debug.Log("Blauwe lijn raakt: " + hit.collider.name);
                canShoot = true;
            }
        }
        #endregion

        #region RaycastAll
        //New inputsystem muis
        if (Mouse.current.leftButton.IsPressed())
        {
            Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);
            RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, rayLength);
            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Debug.Log("Rode lijn raakt: " + hits[i].collider.name);
                }
            }
        }
        #endregion

        var shoot = inputActions.PlayerControls.Shoot.ReadValue<bool>();
        Debug.Log(shoot);
        if (canShoot && shoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Schiet");
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = spawnPoint.transform.forward * 5;
    }
}
