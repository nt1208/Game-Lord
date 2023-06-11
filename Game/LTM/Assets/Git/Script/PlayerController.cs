using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Multiplayer.Samples.Utilities;
using UnityEngine.VFX;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public SpriteRenderer sprite;
    public bool completedToaA = false;
    public int point = 10;
    string drl;
    [SerializeField] public Text pointtext;
    
    [SerializeField] public GameObject panel;
    [SerializeField] public GameObject panelStore;
    [SerializeField] public GameObject panelLootbox;
    public bool move = true;
    private enum MovementState { frontidle, frontrunning, backidle, backrunning, rightidle, rightrunning };
    MovementState state = MovementState.frontidle;
    public float getX, getY;
    public float standright = 0, standback = 0, standfront = 0;
    public ContactFilter2D movementFilter;
    public Animator anim;
    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();
    
    void Start()
    {


        point = 10;
       /* drl = GetComponent<string>();
        pointtext = GetComponent<Text>()*/;
        drl = pointtext.text;
        pointtext.text = drl + point;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    /*public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);
    }*/
    private void Update()
    {
        if (move)
        { 
            getX = Input.GetAxisRaw("Horizontal");
            getY = Input.GetAxisRaw("Vertical");
        
            rb.velocity = new Vector2(getX * moveSpeed, getY * moveSpeed);
        }
        pointtext.text = drl + point;
        //anim.SetFloat("X", getX);   
        UpdateAnimation();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "ToaA" && !completedToaA)
        {
            panel.SetActive(true);
            state = MovementState.frontidle;
            move = false;
        }
        else move = true;

        if(collision.gameObject.tag == "TableC")
        {
            panelStore.SetActive(true);
            panelLootbox.SetActive(true);
            state = MovementState.frontidle;
            move = false;
        }
        else move = true;
        
        if (collision.gameObject.tag == "InsideC")
        {
            transform.position = new Vector2(-240, 258);
        }
        if (collision.gameObject.tag == "OutsideC")
        {
            transform.position = new Vector2(-22, 26);
        }
        if (collision.gameObject.tag == "InsideE")
        {
            transform.position = new Vector2(-251, 352);
        }
        if (collision.gameObject.tag == "OutsideE")
        {
            transform.position = new Vector2(44, 33);
        }
        pointtext.text = drl + point;
    }
   
    private void UpdateAnimation()
    {

        if (move)
        {

            if (getX > 0)
            {
                standback = 0;
                standfront = 0;
                standright = 1;
                state = MovementState.rightrunning;
                sprite.flipX = false;
            }
            if (getX < 0)
            {
                standback = 0;
                standfront = 0;
                standright = 1;
                state = MovementState.rightrunning;
                sprite.flipX = true;
            }
        
       
            if (getY > .1f)
            {
                standright = 0;
                standfront = 0;
                standback = 1;
                state = MovementState.backrunning;
            }
            if (getY < -.1f)
            {
                standright = 0;
                standback = 0;
                standfront = 1;
                state = MovementState.frontrunning;
            }
        
            if(getX == 0 && getY == 0)
            {
                if(standfront == 1)
                {
                    state = MovementState.frontidle;
                }
                else if(standback == 1)
                {
                    state = MovementState.backidle;
                }
                else if(standright == 1)
                {
                    state = MovementState.rightidle;
                }
            }

      
            anim.SetInteger("state", (int)state);
        }
    }
    

    
}
