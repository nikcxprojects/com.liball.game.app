using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public static Transform target;

    private void LateUpdate()
    {
        if(!target)
        {
            return;
        }

        if(target.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(0, target.position.y, -10);
        }
    }
}
