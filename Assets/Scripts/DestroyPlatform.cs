using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    private Transform player;
    public GameObject[] sectors;
    public float Radius;
    public float Forse;
    public float speed;
    public ParticleSystem ParticleSystem;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (transform.position.y <= player.transform.position.y) return;
        FindObjectOfType<AudioManager>().Play("platformBreak");

        for (int i = 0; i < sectors.Length; i++)
        {
            if (sectors[i] == null) continue;

            sectors[i].GetComponent<Rigidbody>().isKinematic = false;
            sectors[i].GetComponent<Rigidbody>().useGravity = true;

            Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);

            foreach (Collider newCollider in colliders)
            {
                Rigidbody rb = newCollider.GetComponent<Rigidbody>();

                if (rb == null) continue;
                rb.AddExplosionForce(Forse, transform.position, Radius);
            }
            ParticleSystem.GetComponent<ParticleSystem>().Play();
            sectors[i].GetComponent<MeshCollider>().enabled = false;
            sectors[i].transform.parent = null;   
            Destroy(sectors[i].gameObject, 1f);
            Destroy(this.gameObject, 2f);
        }
        this.enabled = false;
    }
}

