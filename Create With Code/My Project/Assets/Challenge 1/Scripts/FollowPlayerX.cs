using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(0, 3, -10);

    void Update()
    {
        
    }
    void LateUpdate()
    {
        transform.position = plane.transform.position + offset;
    }
}