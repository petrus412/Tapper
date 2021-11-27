using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    bool canMove;
    bool isLeaving;
    float Timer;
    float Speed;
    float TipProb;
    public float EndTimer;
    public int Drinks;
    public Lane Lane;

    public void Update()
    {
        if (isLeaving)
        {
            Leave();
            if (transform.position.x < Lane.EndOfTheLane.transform.position.x)
            {
                if (Drinks <= 0)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    Timer = 0;
                    isLeaving = false;
                }
            }
        }
        else if (!canMove)
        {
            Timer += Time.deltaTime;
            if (Timer >= EndTimer)
            {
                Timer = 0;
                canMove = true;
            }
        }
        else if (canMove)
        {
            Move();
            Timer += Time.deltaTime;
            if (Timer >= 1f)
            {
                Timer = 0;
                canMove = false;
            }
        }
        else 
        {
            print("Error");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Stein")
        {
            Drinks--;
            isLeaving = true;
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.right*Time.deltaTime*Speed);
    }
    private void Leave()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Speed*2);
    }
}
