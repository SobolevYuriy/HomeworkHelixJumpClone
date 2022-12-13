using UnityEngine;

public class PlayerDestroyPL : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.gameObject.CompareTag("Player") && collision.relativeVelocity.magnitude >= 28)
        {
            Destroy(gameObject);
            
        }
        return;
    }
}
