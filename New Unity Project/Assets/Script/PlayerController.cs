using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("DefaultPawn")]
    public GameObject Player;
    [SerializeField, Tooltip("PossiblePosition")]
    public GameObject[] Positions;
    int Index = 0;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (!Player)
        {
            print("NoPlayer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.transform.position = Positions[0].transform.position;
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            //player.Move(Up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //player.Move(Down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //player.Move(Left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //player.Move(Right);
        }
    }

    void Move(int Direction)
    {
        int temp = Index + Direction;
        if (temp > 4 || temp < 0)
        {
        }
        else 
        {
            Index += Direction;
        }
        Player.transform.position = Positions[Index].transform.position;
    }
}
