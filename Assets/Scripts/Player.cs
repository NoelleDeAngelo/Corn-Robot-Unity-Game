using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpForce;
    static int score;
    public UI ui;

    private bool isGrounded;
    private int levelStartScore;

    void Start()
    {
        levelStartScore = score;
        if (score == 0)
        {
            ui.SetScoreText(0);
        }
        else
        {
            ui.SetScoreText(score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);

        Vector3 vel = rig.velocity;
        vel.y=0;

        if(vel.x != 0 || vel.z !=0)
        {
            transform.forward = vel;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(transform.position.y < -10)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    public void GameOver ()
    {
        score = levelStartScore;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void addScore (int points)
    {
        score+= points;
        ui.SetScoreText(score);

    }

    public void SetScore(int value)
    {
        score = value;
    }
}


