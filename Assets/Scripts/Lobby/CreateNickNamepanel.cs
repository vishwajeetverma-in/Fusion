using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CreateNickNamepanel : LobbypanelBase
{
    private const int MAX_CHAR_NICK_NAME = 2;
    [Header("CreateNickName Vars")]
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button createNickNameButton;

    //private void Start()
    //{
    //    createNickNameButton.interactable = false;
    //    createNickNameButton.onClick.AddListener(OnClickCreateNickName);
    //    inputField.onValueChanged.AddListener(OnInputValueChanged);
    //}

    public override void InitPanel(LobbyUiManager uiManager)
    {
        base.InitPanel(uiManager);
        createNickNameButton.interactable = false;
        createNickNameButton.onClick.AddListener(OnClickCreateNickName);
        inputField.onValueChanged.AddListener(OnInputValueChanged);
        
    }

    private void OnInputValueChanged(string arg)
    {
        createNickNameButton.interactable = arg.Length >= MAX_CHAR_NICK_NAME;
    }

    private void OnClickCreateNickName()
    {
        var nickName = inputField.text;
        if (nickName.Length >= MAX_CHAR_NICK_NAME)
        {
            base.ClosePanel();
            lobbyUiManager.ShowPanel(LobbyPanelType.MiddleSectionPanel);
        }

    }
}
