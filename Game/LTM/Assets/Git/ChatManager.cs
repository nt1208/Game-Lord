using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;
using UnityEditor;
using static Unity.Burst.Intrinsics.X86.Avx;
using Unity.VisualScripting;

public class ChatManager : NetworkBehaviour
{


    [SerializeField] public TMP_Text show_Message;
    [SerializeField] public TMP_InputField input;
    [SerializeField] public TMP_InputField Client_name;

    [ClientRpc]
    public void SendMessageClientRpc(string message)
    {
        // Call the ClientRpc to update the chat message on all clients

        ReceiveMessageClientRpc(message);

    }

    [ClientRpc]
    public void ReceiveMessageClientRpc(string message)
    {
        var timeNow = System.DateTime.Now;

        string formattedInput = "[<#FFFF80>" + timeNow.Hour.ToString("d2") + ":" + timeNow.Minute.ToString("d2") + ":" + timeNow.Second.ToString("d2") + "</color>] " + message;
        show_Message.text += $"{formattedInput}\n";
    }

    [ServerRpc(RequireOwnership = false)]
    public void SendMessageServerRpc(string message)
    {
        ReceiveMessageServerRpc(message);
    }

    [ServerRpc(RequireOwnership = false)]
    public void ReceiveMessageServerRpc(string message)
    {
    
        SendMessageClientRpc(message);

    }

    public void SendButtonClicked()
    {
        if (input.text.Trim() == string.Empty)
            return;

        string message = input.text;
        if (IsServer)
        {
            SendMessageClientRpc(message);
        }
        else if (IsClient)
        {
            SendMessageServerRpc(message);
        }
        input.text = string.Empty;
    }
}