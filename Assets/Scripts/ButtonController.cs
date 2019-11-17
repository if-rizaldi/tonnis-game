using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
   
}
