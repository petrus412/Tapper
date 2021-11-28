using UnityEngine.SceneManagement;
using UnityEngine;

public class Client : MonoBehaviour
{
    bool canMove;
    bool isLeaving;
    float Timer;
    float Speed;
    float TipProb;
    float EndTimer;
    int Drinks;
    Lane Lane;


    public void Update()
    {
        if (isLeaving)
        {
            Leave();
            if (transform.position.x < Lane.EndOfTheLane.transform.position.x)
            {
                if (Drinks <= 0)
                {
                    ResurcesManager.IncrementPoints(50);
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
            if(transform.position.x > Lane.PlayerPosition.transform.position.x)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene("LoseMenu");
            }
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
   

    private void Move()
    {
        transform.Translate(Vector3.right*Time.deltaTime*Speed);
    }
    private void Leave()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Speed*2);
    }
    public void Init(Lane lane,float Time,int Drink,float Tips,float speed)
    {
        Lane=lane;
        transform.position = Lane.EndOfTheLane.transform.position;
        EndTimer =Time;
        Drinks=Drink;
        TipProb=Tips;
        Speed = speed;
    }
    public void Interaction(GameObject Stein)
    {
        if(Random.Range(0f,1f)>TipProb)
        {
            GameObject Tip = Instantiate(Resources.Load<GameObject>("Tip"));
            Tip.transform.position = Stein.transform.position;
        }
        Drinks--;
        isLeaving = true;
        if (Drinks > 0)
        {
            Stein.gameObject.GetComponentInParent<Stein>().isEmpty = true;
        }
        else
        {
            Stein.gameObject.SetActive(false);
        }
    }
    public bool isLeavingNow()
    {
        return isLeaving;
    }
}
