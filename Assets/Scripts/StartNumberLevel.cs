using UnityEngine;
using UnityEngine.UI;

public class StartNumberLevel : MonoBehaviour
{
    public Text Text;
    public GameStatus GameStatus;

    private void Start()
    {
        Text.text = (GameStatus.LevelIndex).ToString();
    }
}
