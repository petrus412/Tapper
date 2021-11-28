using UnityEngine;

public class ClientManager : MonoBehaviour
{
      float Timer;
      [SerializeField]
      Lane[] Lanes;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var client = ResurcesManager.Get(1);
            client.GetComponent<Client>().Init(Lanes[0],2f,2,0,6f);
            client.SetActive(true);
        }
    }
}
