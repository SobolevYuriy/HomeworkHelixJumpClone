using UnityEngine;

public class Camera : MonoBehaviour
{
    public Player Player;
    public Vector3 PlatformDelta;
    public float Speed;

    void Update()
    {
        if (Player.CurrentPlatform == null) return;

        Vector3 targetposition = Player.CurrentPlatform.transform.position + PlatformDelta;
        transform.position = Vector3.MoveTowards(transform.position, targetposition, Speed * Time.deltaTime);
    }
}
