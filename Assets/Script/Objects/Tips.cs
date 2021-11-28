using UnityEngine;

public class Tips : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            ResurcesManager.IncrementPoints(1500);
            Destroy(gameObject);
        }
    }
}
