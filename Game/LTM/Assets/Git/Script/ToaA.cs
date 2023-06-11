using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToaA : MonoBehaviour
{
    [SerializeField] public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ToaA")
        {
            button.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
