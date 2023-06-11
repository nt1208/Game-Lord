using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonC : MonoBehaviour
{
    [SerializeField] private GameObject exitStore;
    [SerializeField] private GameObject exitLootbox;
    [SerializeField] public GameObject player;
    public void Exit()
    {
        exitStore.SetActive(false);
        exitLootbox.SetActive(false);
        player.GetComponent<PlayerController>().move = true;
        player.transform.position = new Vector2(-257, 263);
    }
}
