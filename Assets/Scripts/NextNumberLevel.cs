using UnityEngine;
using UnityEngine.UI;

public class NextNumberLevel : MonoBehaviour
{
    public Text Text;
    public GameStatus GameStatus;

    private void Start()
    {
        Text.text = (GameStatus.LevelIndex+1).ToString();
    }
}
