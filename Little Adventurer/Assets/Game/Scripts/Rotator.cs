using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 80f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f), Space.World);
    }
}
