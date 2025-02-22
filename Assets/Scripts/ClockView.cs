using TMPro;
using UnityEngine;

public class ClockView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCounter;
    [SerializeField] private Clock _currentTime;

    private void Start()
    {
        _textCounter.text = "0";  
    }

    private void OnEnable()
    {
        _currentTime.TimeChanged += ShowCounter;
    }

    private void OnDisable()
    {
        _currentTime.TimeChanged -= ShowCounter;
    }

    private void ShowCounter(int current)
    {
        _textCounter.text = current.ToString("");
    }
}
