using System;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.CurrentPlatform = this;
        }
    }
}
