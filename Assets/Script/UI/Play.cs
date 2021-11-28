using UnityEngine.SceneManagement;
using UnityEngine;

public class Play : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
