using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Netcode;
public class ExitButton : NetworkBehaviour
{
    
    [SerializeField] public GameObject exit;
    [SerializeField] public GameObject player;
    

   public void Exit()
    {
        exit.SetActive(false);
        player.GetComponent<PlayerNetwork>().completedToaA = true;
        player.GetComponent<PlayerNetwork>().move = true;
        player.transform.position = new Vector2(84, 69);
    }
    
   
}
