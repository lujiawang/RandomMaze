using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        transform.Rotate(Vector3.zero, Space.Self);
        transform.position = new Vector3(player.position.x,player.position.y,-1.25f);
    }
}
