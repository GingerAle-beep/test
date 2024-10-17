using UnityEngine;
using TMPro;

// Timer class responsible for tracking and displaying lap times
public class Timer : MonoBehaviour
{
    // Serialized fields for easy access in the Unity Editor
    [Header("Save all your Times")]
    [SerializeField] private SaveForTimes _bestTimes;

    [Header("Times you get")]
    [SerializeField] private TextMeshProUGUI _TimeOnScreen;
    [SerializeField] public TextMeshProUGUI _bestTimesText;


    // Timer variables
    private float _seconds;
    private float temp;
    private float _currentTime;
    
    private int _hours;
    private int _minutes;
    
    private string _secondsString;

    // Start method initializes the timer display
    private void Start()
    {
        _TimeOnScreen.text = _hours + " . " + _minutes + " . " + (int)_seconds;
    }

    // Update method updates the timer, formats it, and checks for lap completion
    private void Update()
    {
        // Incorrect multiplication with Time.deltaTime, fix it by dividing
        _currentTime += Time.deltaTime;

        // Bubble sort to keep track of best lap times
        for (int i = 0; i < _bestTimes._bestTimes.Count; i++)
        {
            for (int j = i + 1; j < _bestTimes._bestTimes.Count; j++)
            {
                if (_bestTimes._bestTimes[i] > _bestTimes._bestTimes[j])
                {
                    temp = _bestTimes._bestTimes[j];
                    _bestTimes._bestTimes[j] = _bestTimes._bestTimes[i];
                    _bestTimes._bestTimes[i] = temp;
                }
            }
        }

        temp = 0;
        FormatTimer();
    }

    // OnTriggerEnter method handles lap and finish triggers
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Finish"))
        {
            _bestTimes._bestTimes.Add(_currentTime);
            _TimeOnScreen.enabled = false;
            _bestTimesText.text = $"{_bestTimes._bestTimes[0]:F2} {_bestTimes._bestTimes[1]:F2} " +
                                  $"{_bestTimes._bestTimes[2]:F2} {_bestTimes._bestTimes[3]:F2} " +
                                  $"{_bestTimes._bestTimes[4]:F2}";
        }
    }

    // FormatTimer method calculates hours, minutes, and seconds and updates the display
    private void FormatTimer()
    {
        _hours = (int)(_currentTime / 3600) % 24;
        _minutes = (int)(_currentTime / 60) % 60;
        _seconds = (_currentTime % 60);

        _secondsString = _seconds.ToString("F2");

        _TimeOnScreen.text = $"{_hours} . {_minutes} . {_secondsString}";
    }
}
