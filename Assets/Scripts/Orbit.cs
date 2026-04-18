using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform center;
    public float speed = 10f;

    void Update()
    {
        transform.RotateAround(center.position, Vector3.up, speed * Time.deltaTime);
    }
}