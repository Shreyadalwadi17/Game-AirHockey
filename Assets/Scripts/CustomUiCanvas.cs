using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class CustomUiCanvas : MonoBehaviourPunCallbacks
{
    public Canvas homeCanvas;
    public Canvas customCanvas;

    public TMP_InputField createInputField;
    public TMP_InputField joinInputField;

    public GameObject createImage;
    public GameObject joinImage;

    private void Start()
    {
        homeCanvas.enabled = true;
        customCanvas.enabled = false;
    }

    public void OnClickCustomPlayButton()
    {
        homeCanvas.enabled = false;
        customCanvas.enabled = true;
    }

    public void OnCreateButtonClick()
    {
        PhotonNetwork.CreateRoom(createInputField.text);
        Debug.Log($"Room Created: {createInputField.text}");
        createImage.SetActive(true);

    }
    public void OnJoinButtonClick()
    {
        PhotonNetwork.JoinRoom(joinInputField.text);
        Debug.Log($"Join Room: {joinInputField.text}");
        joinImage.SetActive(true);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Debug.Log("We load the 'RoomFor1' ");
            PhotonNetwork.LoadLevel("RoomFor1");
        }
        
    }
}
