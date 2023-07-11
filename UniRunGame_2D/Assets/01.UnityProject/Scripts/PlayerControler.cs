using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 300f;
    public GameObject coin;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;
   
    private Transform playerTransform = default;
    private Rigidbody2D playerRigid = default;
    private Animator animator = default;
    private AudioSource playerAudio = default;
    


    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerTransform = GetComponent<Transform>();

        Debug.Assert(playerRigid != null);
        Debug.Assert(animator != null);
        Debug.Assert(playerAudio != null);
        

    }

    // Update is called once per frame
    void Update()
    {

        if (isDead) { return; }

        if(Input.GetMouseButtonDown(0) && jumpCount < 2 )
        {
            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();

        }

        else if(Input.GetMouseButtonDown(0) && 0 < playerRigid.velocity.y)
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }

        animator.SetBool("Ground", isGrounded);
            
        


    }

    private void Die()
    {
        animator.SetTrigger("Die");

        playerAudio.clip = deathClip;

        playerAudio.Play();

        playerRigid.velocity = Vector2.zero;

        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag.Equals("Dead") && isDead == false)
        {            
            Die();
        }

        //닿았을때에 인식 불가
        if (collision.gameObject.CompareTag("Coin"))
        {
            //Debug.Log("코인과 닿았을때에 들어옴");
            Destroy(collision.gameObject);
            GameManager.instance.AddScore(3);
        }

        if(collision.gameObject.CompareTag("Heart"))
        {
            Destroy(collision.gameObject);
            if (playerTransform.transform.localScale == new Vector3(1f,1f,1f))
            {
                playerTransform.transform.localScale = new Vector3(2f, 2f, 2f);
            }
            
            else if (playerTransform.transform.localScale == new Vector3(2f, 2f, 2f))
            {
                GameManager.instance.AddScore(2);
            }

        }

        



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y)
        {
            isGrounded = true;
            jumpCount = 0;

        }

       

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;

    }



}

