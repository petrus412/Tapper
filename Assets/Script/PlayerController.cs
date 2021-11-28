using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("DefaultPawn")]
    public GameObject Player;
    [SerializeField, Tooltip("Possible position")]
    Lane[] Lanes;
    [SerializeField, Tooltip("Player speed")]
    float Speed;
    [SerializeField]
    Image FillBar;
    int Index;
    bool Versando;
    float Timer;
    public float TempoPerVersare;
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
        if(Versando)
        {
            FillBar.gameObject.SetActive(true);
            Timer += Time.deltaTime;
            FillBar.fillAmount = Timer / TempoPerVersare;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(Timer>TempoPerVersare)
            {
                var Stein=ResurcesManager.Get(0);
                Stein.SetActive(true);
                Stein.GetComponent<Stein>().SetLane(Lanes[Index]);
                Stein.transform.position = Lanes[Index].SteinPosition.transform.position;
            }
            FillBar.gameObject.SetActive(false);
            Versando = false;
            Timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.transform.position = Lanes[Index].PlayerPosition.transform.position;
            Versando = true;
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
        if(!Versando)
        {
            Player.transform.Translate(Direction*Time.deltaTime*Speed);
            if(Player.transform.position.x>Lanes[Index].PlayerPosition.transform.position.x|| Player.transform.position.x < Lanes[Index].EndOfTheLane.transform.position.x)
            {
                Player.transform.Translate(-Direction * Time.deltaTime * Speed);
            }
        }
    }
}
