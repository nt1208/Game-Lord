using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class UserPoint : NetworkBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public GameObject player;
    public Text text;
    // Update is called once per frame
    private void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {

        /*text.text = player.GetComponent<PlayerNetwork>().score.Value;
        //text.text = "Hello World";
        Debug.Log(text.text);*/
    }
}
