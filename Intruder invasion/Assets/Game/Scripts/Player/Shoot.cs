using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Shoot : MonoBehaviour
{
    //de gun motion class gebruik ik om de positions te pakken van de gun barrels
    [SerializeField] private GunShootMotion gunMotion;
    [Space]
    [SerializeField] private int objectPoolIndex;
    [SerializeField] private float barrelDistance;
        
    // de late update is er zodat de barrel eerst verplaatst word voordat de shootpos eerder word uitgevoerd in de update
    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = ObjectPooler.Instance.GetPooledObject(objectPoolIndex);
            Vector3 shootPos = gunMotion.Arms[gunMotion.index].transform.position + transform.right * barrelDistance;
            projectile.transform.position = shootPos;
            projectile.SetActive(true);
        }
    }

}
