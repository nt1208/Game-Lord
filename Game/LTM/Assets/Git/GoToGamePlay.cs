using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class GoToGamePlay : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject database;
    public void TurnOffCanvas()
    {
        database.SetActive(false);
    }
}
