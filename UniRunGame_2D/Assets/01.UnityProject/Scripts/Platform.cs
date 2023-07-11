using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject[] obstacles;
    private bool stepped = false;

    private int objectCall = default;
    

    private void OnEnable()
    {

        stepped = false;

        for(int i = 0; i < obstacles.Length; i++)
        {
            objectCall = Random.Range(0, 5);
            if (objectCall >= 3)
            {
                obstacles[i].SetActive(true);
            }           

            else if(objectCall == 4)
            {
                obstacles[i].SetActive(true);
            }

            else if(objectCall == 5)
            {
                obstacles[i].SetActive(true);
            }

            else
            {
                obstacles[i].SetActive(false);
            }


        }

    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Player") && stepped == false)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }





}
