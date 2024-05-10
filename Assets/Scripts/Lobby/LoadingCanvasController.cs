using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fusion;

public class LoadingCanvasController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Button cancelButton;
    private NetworkRunnerController networkRunnerController;

    private void Start()
    {
        networkRunnerController = GlobalManager.instance.networkRunnerController;
        networkRunnerController.OnStartedRunnrConnection += OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSuccessfully += OnPlayerJoinedSuccesfully;
        cancelButton.onClick.AddListener(networkRunnerController.ShutDownRunner);
        this.gameObject.SetActive(false);
    }

    private void OnStartedRunnerConnection()
    {
        this.gameObject.SetActive(true);
        const string CLIP_NAME = "In";
        StartCoroutine(Utils.PlayAnimAndSetStateWhenFinished(gameObject, anim, CLIP_NAME ));
    }

    private void OnPlayerJoinedSuccesfully()
    {
        const string CLIP_NAME = "Out";
        StartCoroutine(Utils.PlayAnimAndSetStateWhenFinished(gameObject, anim, CLIP_NAME, false));
    }

    private void CancelRequest()
    {
        
    }
    private void OnDestroy()
    {
        networkRunnerController.OnStartedRunnrConnection -= OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSuccessfully -= OnPlayerJoinedSuccesfully;

    }
}
