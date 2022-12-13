using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public GameStatus GameStatus;
    public float Acceleration;

    public Platform CurrentPlatform;
    AudioManager audioManager;

    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("BackroundMusic");
    }

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
        audioManager.Play("ballBounce");
    }
    public void Die()
    {
        GameStatus.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }

    public void ReachFinish()
    {
        GameStatus.OnPlayerReachFinish();
        Rigidbody.velocity = Vector3.zero;
    }
}
