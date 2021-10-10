using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNameInputField : MonoBehaviour
{
   public void setPlayerName(string playerName)
    {
        if(string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Please enter a player Name");
            return;
        }
        PhotonNetwork.NickName = playerName;
    }
}
