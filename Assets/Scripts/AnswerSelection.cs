using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class AnswerSelection : MonoBehaviourPunCallbacks
{
    public string answertag;
  //  Questions questionAnswer;
    QuizSystem quizSystem;
   // public string player1;
  //  public string player2;

   

    // Start is called before the first frame update
    void Start()
    {
        quizSystem = FindObjectOfType<QuizSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        /*  if (questionAnswer.answer == answertag)
          {
              Debug.Log("Correct");
          }*/
       // Debug.Log(quizSystem.ans);
       


    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            answertag = this.gameObject.tag;
            Debug.Log(answertag);

            
            
            if (quizSystem.ans == answertag)
            {
                quizSystem.set = true;
                
                collision.gameObject.GetComponent<PhotonView>().RPC("playerScore", RpcTarget.All, 1);
              //  quizSystem.count++;
            }

        }

       /* if(collision.gameObject.CompareTag("Player") )
        {
            
        }*/

        


    }
}
