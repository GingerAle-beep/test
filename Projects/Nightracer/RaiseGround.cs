using UnityEngine;

// RaiseGround class responsible for elevating the GameObject's position over time
public class RaiseGround : MonoBehaviour
{
    // Speed at which the ground is raised
    public float _raisingSpeed = 2.5f;

    // Update is called once per frame
    void Update()
    {
        // Adjust the vertical position of the GameObject over time based on the raising speed
        transform.position = new Vector3(transform.position.x, transform.position.y + _raisingSpeed * Time.deltaTime, transform.position.z);
    }
}
