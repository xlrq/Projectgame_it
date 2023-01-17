using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    [SerializeField] GameObject shootingItem;
    [SerializeField] Transform shootingPoint;
    public bool canShoot = true;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!canShoot)
            return;

        GameObject si = Instantiate(shootingItem, shootingPoint);
        si.transform.parent = null;
    }
}
