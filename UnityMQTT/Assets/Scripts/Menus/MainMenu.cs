using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject CreatePanel;
    public GameObject JoinedPlayerPanel;
    public GameObject PlayerText;
    public Button CreateButton;

    public void OpenCreateLobbyPanel()
    {
        CreatePanel.SetActive(true);
        LeanTween.moveLocalX(CreatePanel, 0, 0.6f);
    }

    public void CreateRoom()
    {
        LeanTween.moveLocalX(CreatePanel, -2.8f, 0.3f);
        LeanTween.scaleX(CreatePanel, 0.8f, 0.3f);
        JoinedPlayerPanel.SetActive(true);
        LeanTween.moveY(JoinedPlayerPanel, 0, 0.3f);
        CreateButton.interactable = false;

    }

    public void StartGame()
    {
        Debug.Log("Start Game");
    }


}
