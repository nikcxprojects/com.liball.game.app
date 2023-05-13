using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private const float force = 7.5f;
    public bool OnCollided { get; set; }

    private Animation Animation { get; set; }

    public static Action OnPlatformCollided { get; set; }

    private void Awake()
    {
        Animation = GetComponent<Animation>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.position.y < transform.position.y)
        {
           return;
        }

        if(!OnCollided)
        {
            OnPlatformCollided?.Invoke();
            OnCollided = true;
        }

        Animation.Play();
    }
}
