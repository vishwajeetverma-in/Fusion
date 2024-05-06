using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUiManager : MonoBehaviour
{
    [SerializeField] private LobbypanelBase[] lobbyPanels;

    private void Start()
    {
        foreach (var lobby in lobbyPanels)
        {
            lobby.InitPanel(this);
        }    
    }

    public void ShowPanel(LobbypanelBase.LobbyPanelType type)
    {
        foreach (var lobby in lobbyPanels)
        {
            if(lobby.panel == type)
            {
                lobby.ShowPanel();
                break;      
            }
        }
    }
}
