using UnityEngine;

public class Ball : MonoBehaviour
{
    private const float xForce = 3.0f;
    private const float force = 7.5f;

    private Rigidbody2D Rigidbody { get; set; }
    private AudioSource Source { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && Time.timeScale > 0)
        {
            var inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(inputPosition.x > transform.position.x)
            {
                Rigidbody.position += Time.deltaTime * xForce * Vector2.right;
            }
            else if(inputPosition.x < transform.position.x)
            {
                Rigidbody.position += Vector2.left * xForce * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.position.y > transform.position.y)
        {
            return;
        }

        Rigidbody.velocity = Vector2.zero;
        Rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);

        if(SettingsManager.VibraEnbled)
        {
            Handheld.Vibrate();
        }

        if (SettingsManager.SoundsEnabled)
        {
            if(Source.isPlaying)
            {
                Source.Stop();
            }

            Source.Play();
        }
    }
}
