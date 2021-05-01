using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class Mqtt :MonoBehaviour
{
    // Start is called before the first frame update
    public static MqttClient client;
    private string msg;
    private const string IP = "192.168.178.178";


    void Start()
    {
        client = new MqttClient(IP);
        client.MqttMsgPublishReceived += ReceiveMessage;
        client.Subscribe(new string[] { "Uno/" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
        client.Connect("Uno/#");
        


        Task.Run(() =>
        {
            if (client.IsConnected)
            {         
                client.Publish("Uno/LatestJoin", Encode(msg));
            }
        });
    }

    internal void WaitForPlayer(string GameName)
    {
        client.Subscribe(new string[] { "Uno/"+GameName }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
    }
    private void WaitForPlayer(object sender, MqttMsgPublishEventArgs e)
    {
        Debug.Log("e.Message");
    }

    internal void SubWaitForPlayers()
    {
        client.MqttMsgPublishReceived += WaitForPlayer;
    }


    



    private void ReceiveMessage(object sender, MqttMsgPublishEventArgs e)
    {
        Debug.Log("Recvied mqtt stuff :" + e.Message);
    }

    private byte[] Encode(string text)
    {
        return Encoding.UTF8.GetBytes(text);
    }

    private void Awake()
    {
       msg = SystemInfo.deviceName.ToString();
    }


    public void PostMessage(string topic, byte[] data)
    {
        client.Publish("Uno/"+topic, data);
    }

    public void PostMessage(string topic, string data)
    {
        client.Publish("Uno/" + topic, Encode(data));
    }

    public static MqttClient GetMqttClient()
    {
        return client;
    }
}
