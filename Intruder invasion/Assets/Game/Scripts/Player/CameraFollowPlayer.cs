using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0,0,-5), 0.5f);
    }
}
