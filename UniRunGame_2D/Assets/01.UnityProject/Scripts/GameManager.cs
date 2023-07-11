using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver = false;
    public TMP_Text scoreText; //text mesh pro ������Ʈ �� ���
    //public Text scoreText_; //legacy Text ������Ʈ �����
    public GameObject gameOverUi;

    private int score = 0;
    private void Awake()
    {
        //�Ʒ� if �� �ڵ�� ����� IsValid �� üũ���ش�
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
            GFunc.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }

        //GFunc ���ִ� List �� ��� ���̵� �����ϴ��� Ȯ���ϴ� Bool�� �޼��� �׽�Ʈ

        //List<int> intList = new List<int>();
        //intList.Add(1);

        //Debug.LogFormat("intList�� ��ȿ���� (�����ϴ���?) : {0}", intList.IsValid());

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


    //���ӿ����� false�� ���ھ �þ�� �ϰ� ǥ��
    public void AddScore(int newScore)
    {
        if (isGameOver == false)
        {
            score += newScore;
            scoreText.text = string.Format("Score : {0}", score);
        }
    }

    //�÷��̾ �׾������� ���ӿ����� Ȱ��ȭ�ǰ� ���ӿ��� UI Ȱ��ȭ ��Ŵ
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }
}
