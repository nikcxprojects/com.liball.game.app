using UnityEngine;

public class OverZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player"))
        {
            return;
        }

        UIManager.Instance.GameOver();
    }
}
