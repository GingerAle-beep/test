using UnityEngine;
using TMPro;

// Speedometer class responsible for displaying the boat's speed
public class Speedometer : MonoBehaviour
{
    // Reference to the boat's rigidbody
    [SerializeField] private Rigidbody _boat;

    // Maximum speed of the boat
    [Header("Max Speed")]
    [SerializeField] private float _maxspeed;

    // Arrow angle settings for indicating speed on UI
    [Header("Arrow")]
    [SerializeField] private float _minSpeedArrowAngle;
    [SerializeField] private float _maxSpeedArrowAngle;

    // UI elements for displaying speed
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI speedLabel;
    [SerializeField] private RectTransform _arrow;

    // Variable to store the boat's speed
    private float speed;

    // Update is called once per frame
    private void Update()
    {
        // Calculate the boat's speed in kilometers per hour
        speed = _boat.velocity.magnitude * 3.6f;

        // Update the speed label on the UI
        if (speedLabel != null)
        {
            speedLabel.text = ((int)speed) + " KM/H";
        }

        // Update the arrow rotation on the UI based on the boat's speed
        if (_arrow != null)
        {
            // Use Mathf.Lerp to interpolate between min and max arrow angles based on speed ratio
            _arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(_minSpeedArrowAngle, _maxSpeedArrowAngle, speed / _maxspeed));
        }
    }
}