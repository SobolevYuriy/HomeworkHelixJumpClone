using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
