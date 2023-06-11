using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class GetInToaA : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject panel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
                panel.SetActive(true);
        }
    }
}
