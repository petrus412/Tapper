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
            if (transform.position.x >=_Lane.PlayerPosition.transform.position.x)
            {
                isEmpty = false;
                gameObject.SetActive(false);
                SceneManager.LoadScene("LoseMenu");
            }
        }
        else
        {
            transform.Translate(Vector3.left*Speed*Time.deltaTime);
            if(transform.position.x <= _Lane.EndOfTheLane.transform.position.x-2)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene("LoseMenu");
            }
        }
    }
    public void SetLane(Lane Lane)
    {
        _Lane = Lane;
    }
}
