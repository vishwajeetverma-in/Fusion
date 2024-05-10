using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbypanelBase : MonoBehaviour
{
    [field: SerializeField, Header("LobbyPanelBase Vars")]
    public LobbyPanelType panel { get; private set; }
    [SerializeField] private Animator anim;
    //private LobbyUiManager lobbyUiManager;
    protected LobbyUiManager lobbyUiManager;
    public enum LobbyPanelType
    {
        None,
        CreateNickNamePanel,
        MiddleSectionPanel
    }

    public virtual void InitPanel(LobbyUiManager uiManager)
    {
       lobbyUiManager = uiManager;
    }

    public void ShowPanel()
    {
        this.gameObject.SetActive(true);
        const string POP_IN_CLIP_NAME = "In";
        anim.Play(POP_IN_CLIP_NAME);
    }

    protected void ClosePanel()
    {
        const string POP_OUT_CLIP_NAME = "Out";
        this.gameObject.SetActive(false);
        //StartCoroutine(Utils.PlayAnimAndSetStateWhenFinished(gameObject,anim,POP_OUT_CLIP_NAME,false));     
    }
}
