using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTimer : MonoBehaviour
{
    [SerializeField]
    private float _startingTime = 60.0f;

    [SerializeField]
    private TextMeshProUGUI _timeText;

    private float _timeRemaining;

    public float TimeRemaning { get { return _timeRemaining; } }

    private void Start()
    {
        _timeRemaining = _startingTime;
        if (_timeText)
            _timeText.text = _timeRemaining.ToString("0.0");
    }

    private void Update()
    {
        _timeRemaining -= Time.deltaTime;
        _timeRemaining = Mathf.Clamp(_timeRemaining, 0, _startingTime);

        if (_timeText)
            _timeText.text = _timeRemaining.ToString();
    }
}
