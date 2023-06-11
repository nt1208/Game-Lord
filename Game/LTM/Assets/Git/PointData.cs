using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
public class PointData : NetworkBehaviour
{
    public Text point;
    public GameObject player;
    // Start is called before the first frame update

    private void Start()
    {
        point = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        CheckIDServerRpc();
    }

    [ServerRpc]
    public void CheckIDServerRpc()
    {

        point.text = "User " + OwnerClientId + ": " + player.GetComponent<PlayerNetwork>().pointtext.Value.ToString() + "\n";
    }
}
