using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class UnoHandler : MonoBehaviour
{
    public TMP_Text LobbyName;
    public GameObject Mqtt;
    Mqtt client;


    private void Awake()
    {
        client = Mqtt.GetComponent<Mqtt>();
    }

    public void CreateRoom()
    {
        client.PostMessage("game/"+LobbyName.text, "Opend the Game");
        client.SubWaitForPlayers();
    }

    private void RoomJoinListener(object sender, MqttMsgPublishEventArgs e)
    {
        Debug.Log("Recvied mqtt stuff :" + e.Message);
    }
}
