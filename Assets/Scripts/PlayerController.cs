using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static PlayerController _player;
    public Colors _playerCol = Colors.Red;
    SpriteRenderer _spr;
    public float flyvelocity = 200f;
    private Rigidbody2D body;
    public (float, float) constraintYAxis = (100.7f, -100.65f);
    public bool AllowMovement = false;
    public bool Dead = false;
    


    internal void Die()
    {
        
        Dead = true;
        body.gravityScale = 0;
        body.velocity = Vector2.zero;
    }

    public AudioClip jumpAudio;
    public AudioSource audSrc;

    public bool Haulted = true;
    public int haultcounter = 0;

    private void Awake()
    {
        jumpAudio = Resources.Load<AudioClip>("jump");
        audSrc = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        _player = this;
        _spr = GetComponent<SpriteRenderer>();
        body.gravityScale = 0;
    }
    private void Start()
    {
        SetColor(_playerCol);
    }
    private void Update()
    {
        if (!Dead)
        {
            if (AllowMovement && (Input.GetKeyDown("space")||Input.GetMouseButtonDown(0)))
            {
                audSrc.PlayOneShot(jumpAudio);
                body.velocity = Vector2.zero;
                body.AddForce(new Vector2(0, flyvelocity), ForceMode2D.Impulse);
            }
            else
            {
                if ((Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)) && !Haulted)
                {
                    haultcounter = 0;
                    audSrc.PlayOneShot(jumpAudio);
                    enableMovement(true);
                }
                else if (haultcounter % 180 == 0f)
                {
                    Haulted = false;
                }
                else
                {
                    haultcounter++;
                }

            }
        }




    }

    public void enableMovement(bool a)
    {
        if (a)
        {
            AllowMovement = true;
            body.gravityScale = 1;

        }
        else
        {
            AllowMovement = false;
            body.gravityScale = 0;

        }

    }

    public void SetColor(Colors col = Colors.Red)
    {
        _playerCol = col;
        _spr.color = ColorGetter.GetColor(col);
    }
}