using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodSector;
    public Material BadSector;

    private void Awake()
    {
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsGood ? GoodSector : BadSector;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.relativeVelocity.magnitude >= 28) return;
        if (!collision.collider.TryGetComponent(out Player player)) return;
        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot < 0.5) return;
        if (IsGood)
            player.Bounce();
        else
            player.Die();
    }
    private void OnValidate()
    {
        UpdateMaterial();
    }
}
