using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;


public class RightAnswer : MonoBehaviour
{
    
    [SerializeField] public GameObject question1;
    [SerializeField] public GameObject question2;
    [SerializeField] public GameObject question3;
    [SerializeField] public GameObject question4;
    [SerializeField] public GameObject player;
    [SerializeField] public Text playerPoint;
    [SerializeField] public GameObject rightans;
    [SerializeField] public GameObject wrongans;
    [SerializeField] public GameObject panel;
    int flag = 1;
    private void Start()
    {
        
    }
    public void inactive_right_nofi()
    {
        rightans.SetActive(false);
    }
    public void inactive_wrong_nofi()
    {
        wrongans.SetActive(false);
    }
    public void prepareQuestion2()
    {
        question1.SetActive(false);
        question2.SetActive(true);
    }
    public void prepareQuestion3()
    {
        question2.SetActive(false);
        question3.SetActive(true);
    }
    public void prepareQuestion4()
    {
        question3.SetActive(false);
        question4.SetActive(true);
    }
    public void prepareComplete()
    {
        question4.SetActive(false);
        player.GetComponent<PlayerNetwork>().completedToaA = true;
        player.GetComponent<PlayerNetwork>().move = true;
        //player.GetComponent<PlayerNetwork>().panel.SetActive(false);
        panel.SetActive(false);
    }
    public void Gotonquestion2()
    {
        if(flag == 1)
        {
            rightans.SetActive(true);
            Invoke("inactive_right_nofi", 2f);
            //AddScoreServerRpc();
            //player.GetComponent<PlayerNetwork>().pointtext.Value += 10;
            player.GetComponent<PlayerNetwork>().point += 10;
            Invoke("prepareQuestion2", 2f);
            flag++;
        }
    }
    public void Gotonquestion3()
    {
        if(flag == 2)
        {

            rightans.SetActive(true);
            Invoke("inactive_right_nofi", 2f);
            //AddScoreServerRpc();
            //player.GetComponent<PlayerNetwork>().pointtext.Value += 10;
            player.GetComponent<PlayerNetwork>().point += 10;
            Invoke("prepareQuestion3", 2f);
            flag++;
        }
    
    }
    public void Gotonquestion4()
    {
        if(flag == 3)
        {

            rightans.SetActive(true);
            Invoke("inactive_right_nofi", 2f);
            //AddScoreServerRpc();
            //player.GetComponent<PlayerNetwork>().pointtext.Value += 10;
            player.GetComponent<PlayerNetwork>().point += 10;
            Invoke("prepareQuestion4", 2f);
            flag++;
        }
    }
    public void wrongAnswer1()
    {
        if(flag == 1)
        {
            wrongans.SetActive(true);
            Invoke("inactive_wrong_nofi", 2f);
            Invoke("prepareQuestion2", 2f);
            flag++;
        }
    }
    public void wrongAnswer2()
    {
        if(flag == 2)
        {
            wrongans.SetActive(true);
            Invoke("inactive_wrong_nofi", 2f);
            Invoke("prepareQuestion3", 2f);
            flag++;
        }
    }
    public void wrongAnswer3()
    {
        if(flag == 3)
        {
            wrongans.SetActive(true);
            Invoke("inactive_wrong_nofi", 2f);
            Invoke("prepareQuestion4", 2f);
            flag++;
        }
    }
    public void wrongAnswer4()
    {
        if(flag == 4)
        {
            wrongans.SetActive(true);
            Invoke("inactive_wrong_nofi", 2f);
            Invoke("prepareComplete", 2f);
            flag++;
        }

    }

    public void Complete()
    {
        if(flag == 4)
        {
            rightans.SetActive(true);
            //AddScoreServerRpc();
            //player.GetComponent<PlayerNetwork>().pointtext.Value += 10;
             player.GetComponent<PlayerNetwork>().point += 10;
            Invoke("inactive_right_nofi", 2f);
            Invoke("prepareComplete", 2f);
            flag++;
        }
    }
    [ServerRpc]
    public void AddScoreServerRpc()
    {
        player.GetComponent<PlayerNetwork>().point += 10;
    }

}
