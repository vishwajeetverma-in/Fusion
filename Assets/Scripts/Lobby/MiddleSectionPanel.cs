using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Fusion;

public class MiddleSectionPanel : LobbypanelBase
{
    [Header("MiddleSectionPanel Vars")]

    [SerializeField] private Button joinRandomRoomButton;
    [SerializeField] private Button joinRoomByArgButton;
    [SerializeField] private Button createRoomButton;

    [SerializeField] private TMP_InputField joinRoomByArgInputField;
    [SerializeField] private TMP_InputField createRoomInputField;
    private NetworkRunnerController networkRunnerController;

    public override void InitPanel(LobbyUiManager uiManager)
    {
        base.InitPanel(uiManager);
        networkRunnerController = GlobalManager.instance.networkRunnerController;
        //joinRandomRoomButton.onClick.AddListener(JoinRandomRoom);
        joinRoomByArgButton.onClick.AddListener(() => CreateRoom(GameMode.Client,joinRoomByArgInputField.text));
        createRoomButton.onClick.AddListener(() => CreateRoom(GameMode.Host, createRoomInputField.text));
    }

    private void CreateRoom(GameMode mode,string field)
    {
        if(field.Length >= 2)
        {
            Debug.Log($"---------{mode}------");
            networkRunnerController.StartGame(mode,field);
        
        }
        
    }

    private void JoinByArgRoom()
    {
        if(joinRoomByArgInputField.text.Length >= 2)
        {
           
            networkRunnerController.StartGame(GameMode.Client, joinRoomByArgInputField.text);
        }
        
    }

    private void JoinRandomRoom()
    {
        Debug.Log($"--------------joined random room");
        networkRunnerController.StartGame(GameMode.AutoHostOrClient,string.Empty);   
      
    }
}
