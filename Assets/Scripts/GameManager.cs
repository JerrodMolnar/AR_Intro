using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
