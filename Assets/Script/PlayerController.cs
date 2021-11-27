using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("DefaultPawn")]
    public GameObject Player;
    [SerializeField, Tooltip("Possible position")]
    Lane[] Lanes;
    [SerializeField, Tooltip("Player speed")]
    float Speed;
    int Index;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (!Player)
        {
            print("NoPlayer");
        }
        else 
        {
            Index = 0;
            Player.transform.position= Lanes[Index].PlayerPosition.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var Stein=ResurcesManager.Get(0);
            Stein.SetActive(true);
            Stein.transform.position = Lanes[Index].SteinPosition.transform.position;
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            SwitchLane(1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchLane(-1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
    }

    void SwitchLane(int Direction)
    {
        int temp = Index + Direction;
        if (temp > 3 || temp < 0)
        {

        }
        else 
        {
            Index += Direction;
        }
        Player.transform.position = Lanes[Index].PlayerPosition.transform.position;
    }
    private void Move(Vector3 Direction)
    {
        Player.transform.Translate(Direction*Time.deltaTime*Speed);
        
    }
}
