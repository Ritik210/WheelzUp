using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;
using Photon.Pun;

public class QuizSystem : MonoBehaviourPunCallbacks
{
    public Questions[] questions;
    private static List<Questions> unAnsweredQuestions;
    public int quesCount;

    private Questions currentQues;
    //private AnswerSelection answerSelection;

    [SerializeField]
    private Text questionText;
    //public Text ansText;
    public string ans;
    public GameObject quesPanel;
    public GameObject finishPanel;
    [Header("Timer")]
    public bool startTimer;
    public float time = 10f;
    public Text timerText;
    //int remainingTime = 0;
    public bool set;
    public int count = 0;
    ScoreSystem scoreSystem;

   

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        finishPanel.SetActive(false);
        quesPanel.SetActive(true);
        time = 10;
        if(unAnsweredQuestions == null || unAnsweredQuestions.Count == 0)
        {
            unAnsweredQuestions = questions.ToList<Questions>();
        }
        GetCurrentQuestion();
        scoreText.text = scoreSystem.score.ToString();


    }

    

    void GetCurrentQuestion()
    {
        quesPanel.SetActive(true);
        quesCount = unAnsweredQuestions.Count;
       // gameObject.GetComponent<PhotonView>().RPC("getQuestion", RpcTarget.All);
       
        int randomQuestionIndex = Random.Range(0, quesCount);
        currentQues = unAnsweredQuestions[randomQuestionIndex];

        questionText.text = currentQues.ques;
        startTimer = true;

        
        ans = currentQues.answer;
        Debug.Log(ans);
        unAnsweredQuestions.Remove(currentQues);

        set = false;
        
    }

    public void leaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);


    }

    void timer()
    {
        time -= Time.deltaTime;
        timerText.text = time.ToString("F0");
    }


    // Update is called once per frame
    void Update()
    {
        if(startTimer == true)
        {
            timer();
        }
        if (time <= 0)
        {
            quesPanel.SetActive(false);
            time = 10;
            startTimer = false;
        }

        if(set == true)
        {
            GetCurrentQuestion();
        }

        if(count == 10)
        {
            finishPanel.SetActive(true);
        }
        scoreText.text = scoreSystem.score.ToString();
        Debug.Log("This is" + ans);
        
    }
}
