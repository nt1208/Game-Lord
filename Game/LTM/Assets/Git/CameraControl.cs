using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class CameraControl : NetworkBehaviour
{
    public Transform target;

    // Update is called once per frame
    private void Update()
    {
        if(IsLocalPlayer)
            transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
    }
}
