using UnityEngine.UI;
using UnityEngine;

public class Points : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        
    }

    public void UpdateText()
    {
        GetComponent<Text>().text = "Punteggio: "+ ResurcesManager.GetPoints().ToString();
    }
}
