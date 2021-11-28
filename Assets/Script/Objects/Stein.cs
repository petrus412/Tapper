using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Stein : MonoBehaviour
{
    [SerializeField, Tooltip("Stein speed")]
    float Speed;
    [HideInInspector]
    public bool isEmpty;
    Lane _Lane;
    public UnityEvent Lose;

    // Update is called once per frame
    void Update()
    {
        if(isEmpty)
        {
            transform.Translate(-Vector3.left*Speed*Time.deltaTime);
            if (transform.position.x >=_Lane.PlayerPosition.transform.position.x+3)
            {
                isEmpty = false;
                gameObject.SetActive(false);
                SceneManager.LoadScene("LoseMenu");
            }
        }
        else
        {
            transform.Translate(Vector3.left*Speed*Time.deltaTime);
            if(transform.position.x <= _Lane.EndOfTheLane.transform.position.x-10)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene("LoseMenu");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(isEmpty)
        {
            if(other.tag=="Player")
            {
                ResurcesManager.IncrementPoints(100);
                isEmpty = false;
                gameObject.SetActive(false);
            }
            else if(other.tag==("End")) 
            {
                isEmpty = false;
                gameObject.SetActive(false);
                SceneManager.LoadScene("LoseMenu");
            }
        }
        else if(other.tag=="Client"&& !other.gameObject.GetComponentInParent<Client>().isLeavingNow())
        {
            other.gameObject.GetComponentInParent<Client>().Interaction(gameObject);
        }
    }
    public void SetLane(Lane Lane)
    {
        _Lane = Lane;
    }
}
