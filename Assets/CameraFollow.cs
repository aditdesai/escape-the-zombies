using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform lookTarget;

    private void Update()
    {
        transform.position = player.position;
        transform.LookAt(new Vector3(lookTarget.position.x, player.position.y, lookTarget.position.z));
    }
}
