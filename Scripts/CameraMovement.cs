using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 2f;
    public float yOffset = 5f;

    void Update()
    {
        if (target != null)
        {
            Vector3 newPos = transform.position;
            newPos.y = Mathf.Lerp(transform.position.y, target.position.y + yOffset, Time.deltaTime * followSpeed);
            transform.position = newPos;
        }
    }
}