using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class MatchMakingUICanvas : MonoBehaviour
{

    public Text waitingtxt;
    public static MatchMakingUICanvas inst;
    public Canvas homeCanvas;
    public Canvas matchmakingCanvas;

    private void Start()
    {
        matchmakingCanvas.enabled = false;
    }

    public void OnClickMatchMakingPlayButton()
    {
        homeCanvas.enabled = false;
        matchmakingCanvas.enabled = true;


    }

}
