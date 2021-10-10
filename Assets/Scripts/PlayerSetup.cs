using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject cam;

    [SerializeField]
    TextMeshProUGUI playerNameText;
    public string playername;
    public string otherPlayerName;
    // Start is called before the first frame update
    void Start()
    {
        if(photonView.IsMine)
        {
            transform.GetComponent<CarController>().enabled = true;
            cam.GetComponent<Camera>().enabled = true;
        }
        else
        {
            transform.GetComponent<CarController>().enabled = false;
            cam.GetComponent<Camera>().enabled = false;

        }
        playername = photonView.Owner.NickName;
        setPlayerName();
    }

    void setPlayerName()
    {
        if (playerNameText != null)
            playerNameText.text = photonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
