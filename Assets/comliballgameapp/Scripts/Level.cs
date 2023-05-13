using UnityEngine;

public class Level : MonoBehaviour
{
    private float y = 0.0f;
    private const float yOffset = 2.5f;
    private const float xRangle = 1.5f;

    [SerializeField] int platformCount;

    private void Start()
    {
        BuildLevel();
    }

    private void Update()
    {
        foreach(Transform t in transform.GetChild(0))
        {
            if(t.position.y > CameraFollower.target.position.y)
            {
                continue;
            }

            if(Mathf.Abs(t.position.y - CameraFollower.target.position.y) > 10)
            {
                t.GetComponent<Platform>().OnCollided = false;

                var x = Random.Range(-xRangle, xRangle);
                t.position = new Vector2(x, y);

                y += yOffset;
            }
        }
    }

    private void BuildLevel()
    {
        var PlatformPrefab = Resources.Load<GameObject>("platform");
        var PlatformParent = GameObject.Find("platforms").transform;

        var yOffset = 2.5f;
        var xRangle = 1.5f;

        for (int i = 0; i < platformCount; i++)
        {
            var x = Random.Range(-xRangle, xRangle);

            var platform = Instantiate(PlatformPrefab, PlatformParent);
            platform.transform.position = new Vector2(x, y);

            y += yOffset;
        }

        var ballPrefab = Resources.Load<GameObject>("ball");
        var instantPosition = PlatformParent.GetChild(0).position;
        var ball = Instantiate(ballPrefab, transform);
        ball.transform.position = instantPosition + Vector3.up * 1;

        CameraFollower.target = ball.transform;
    }
}
