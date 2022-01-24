using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    public Text timer, gameOver;

    int scoreValue;
    float timerValue = 14.0f, timerValueDisplay = 12.0f;


    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;
    public AudioClip musicClipFour;
    public AudioClip musicClipFive;
    public AudioClip pickup;

    public AudioSource musicSource; 

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        rd2d = GetComponent<Rigidbody2D>();
        timer.text = "Time:" + timerValueDisplay.ToString();
        gameOver.text = "";

        musicSource.clip = musicClipFive;
        musicSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        timerValue -= Time.deltaTime;
        
        if(timerValue <= 14 && timerValue >= 4)
        {
            timerValueDisplay -= Time.deltaTime;
            timer.text = "Time:" + timerValueDisplay.ToString();
            musicSource.clip = musicClipThree;
            musicSource.Play();
        }

        if (scoreValue == 1 && timerValueDisplay > 2)
        {
            timer.text = "Time:" + timerValueDisplay.ToString();
            gameOver.text = "You Win! \n This game was made by MAS";
            timer.text = "Time:" + timerValueDisplay.ToString();
            timer.text = "Time:0";
        }
        if (scoreValue != 1 && timerValue < 4.0f)
        {
            timer.text = "Time:" + timerValueDisplay.ToString();
            timer.text = "Time:0";
            gameOver.text = "You lose! \n This game was made by MAS";              
            speed = 0;
        }
        if (timerValueDisplay <= 0)
        {
            timer.text = "Time: 0";
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    // Update is used for physics updating
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
        if (collision.collider.tag == "Platform")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
        if (collision.collider.tag == "Coin")
        {
            musicSource.PlayOneShot(pickup);
            scoreValue += 1;
            Destroy(collision.collider.gameObject);
        }
    }
    public void PlaySound(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
}
