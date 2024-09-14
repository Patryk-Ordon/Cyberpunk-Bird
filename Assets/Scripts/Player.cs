using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float v;
    private Rigidbody2D rbody;
    private Transform tr;
    public Game Game;
    public bool isDead = false;
    public AudioSource clickAudioSource;

    public void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        tr.SetPositionAndRotation(new Vector2(0,0), transform.rotation);
    }

    void Update()
    {
        float fallSpeed = rbody.velocity.y;

        if (fallSpeed < 0)
        {
            float targetRotation = Mathf.Lerp(0, -75, -fallSpeed / 10); 
            transform.rotation = Quaternion.Euler(0, 0, targetRotation);
        }
        else if (fallSpeed > 0)
        {
            float targetRotation = Mathf.Lerp(0, 50, fallSpeed / 10);
            transform.rotation = Quaternion.Euler(0, 0, targetRotation);
        }
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rbody.velocity = Vector2.up * v;
            clickAudioSource.Play();
        }

        if (tr.position.y > 16 || tr.position.y < -16)
        {
            isDead = true;
            Game.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        Game.GameOver();
    }
}
