using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collectible>() != null)
        {
            Destroy(other.gameObject);
        }
    }
}