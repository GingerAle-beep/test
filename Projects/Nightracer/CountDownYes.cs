using System.Collections;
using UnityEngine;
using TMPro;

// CountDown class responsible for managing a countdown before enabling other components
public class CountDown1 : MonoBehaviour
{
    // Serialized field for accessing the countdown text in the Unity Editor
    [SerializeField] private TextMeshProUGUI _countDownText;

    [SerializeField] private GameObject _gameObject;
    // Initial countdown duration
    [SerializeField] float _countDown = 3;

    // Called when the script is first started
    void Start()
    {
        FindObjectOfType<MoveBoat>().enabled = false;
        _countDownText = GetComponent<TextMeshProUGUI>();
        // Disable RaiseGround and Timer components at the beginning
        FindObjectOfType<Timer>().enabled = false;
    }

    // Called once per frame
    void Update()
    {
        // Start the WaitCountDown coroutine to manage the countdown
        StartCoroutine(WaitCountDown());

        // Decrease the countdown timer based on real-time
        _countDown -= 1f * Time.deltaTime;

        // Update the countdown text to display the remaining integer value of the countdown
        _countDownText.text = "" + (int)_countDown;

        // When the countdown reaches or goes below 1
        if (_countDown < 1)
        {
            FindObjectOfType<MoveBoat>().enabled = true;

            // Display "GO!" in the countdown text
            _countDownText.text = "GO!";

            // Enable Timer and RaiseGround components
            FindObjectOfType<Timer>().enabled = true;

            // Make the "GO!" text fully visible using CrossFadeAlpha over 0.5 seconds
            _countDownText.CrossFadeAlpha(1, 0.5f, true);
        }
    }

    // Coroutine to handle delays during the countdown
    IEnumerator WaitCountDown()
    {
        // Wait for 0.5 seconds
        yield return new WaitForSeconds(0.5f);

        // Check if the countdown text is "GO!"
        if (_countDownText.text == "GO!")
        {
            // Wait for an additional 0.5 seconds
            yield return new WaitForSeconds(0.5f);

            // Disable the countdown text
            _countDownText.enabled = false;
            gameObject.SetActive(false);
        }
    }
}

