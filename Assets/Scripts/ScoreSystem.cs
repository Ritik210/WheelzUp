using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviourPunCallbacks
{
    public int score;
    PlayerSetup playerSetup;
    QuizSystem quizSystem;
    [SerializeField]
    TextMeshProUGUI playerScoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        playerSetup = FindObjectOfType<PlayerSetup>();
        quizSystem = FindObjectOfType<QuizSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = "Score : " + score;

    }

    [PunRPC]
    void playerScore(int scoreincrement)
    {
        score += scoreincrement;
        Debug.Log(playerSetup.playername + score);

        quizSystem.count++;

    }

    
}
