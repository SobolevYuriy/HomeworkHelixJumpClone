using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Player Player;
    public Text PointsText;
    public int points;
    public Sector Sector;

    public void Start()
    {
        points = PlayerPrefs.GetInt("Points");
        PointsText.text = points.ToString();
    }

    public void OnTriggerEnter(Collider platforms)
    {
        if (platforms.gameObject.CompareTag("Pl"))
        {
            if (Sector.IsGood)
            {
                PointsText.text = (points += 10).ToString();
                PlayerPrefs.SetInt("Points", points);
                PlayerPrefs.Save();
            }
            PlayerPrefs.DeleteKey("Points");
        }
        Destroy(platforms);
    }

}
