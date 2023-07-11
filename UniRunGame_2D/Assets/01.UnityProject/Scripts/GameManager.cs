using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver = false;
    public TMP_Text scoreText; //text mesh pro 컴포넌트 쓴 경우
    //public Text scoreText_; //legacy Text 컴포넌트 쓴경우
    public GameObject gameOverUi;

    private int score = 0;
    private void Awake()
    {
        //아래 if 문 코드와 비슷함 IsValid 가 체크해준다
        if (instance.IsValid() == false)
        {
            instance = this;
        }


        //if (instance == null)
        //{
        //    instance = this;
        //}

        else
        {
            GFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }

        //GFunc 에있는 List 에 어떤한 값이든 존재하는지 확인하는 Bool형 메서드 테스트

        //List<int> intList = new List<int>();
        //intList.Add(1);

        //Debug.LogFormat("intList가 유효한지 (존재하는지?) : {0}", intList.IsValid());

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && Input.GetMouseButtonDown(0))
        {
            //GFunc.LoadScene("PlayScene");
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }
    }


    //게임오버가 false면 스코어가 늘어나게 하고 표시
    public void AddScore(int newScore)
    {
        if (isGameOver == false)
        {
            score += newScore;
            scoreText.text = string.Format("Score : {0}", score);
        }
    }

    //플레이어가 죽었을때에 게임오버가 활성화되고 게임오버 UI 활성화 시킴
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }
}
