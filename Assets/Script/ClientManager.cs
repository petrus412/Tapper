using UnityEngine.SceneManagement;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    float Timer;
    [SerializeField]
    int NumberOfClient;
    [SerializeField]
    Lane[] Lanes;

    private void Update()
    {
        if(NumberOfClient>0)
        {
            Timer += Time.deltaTime;
            if(Timer>=Random.Range(2f,4f))
            {
                Timer = 0;
                var client = ResurcesManager.Get(1);
                client.GetComponent<Client>().Init(Lanes[Random.Range(0,4)],Random.Range(1f,2.5f),Random.Range(1,3),0,6f);
                client.SetActive(true);
                NumberOfClient--;
            }
        }
        else
        {
            if (!ResurcesManager.ActiveClient())
            {
                SceneManager.LoadScene("EndMenu");
            }
        }
    }
}
