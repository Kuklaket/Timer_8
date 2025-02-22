using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private bool _isCounting = false;
    private float _delay = 0.5f;
    private int _counterTick = 1;
    private Coroutine _coroutine;

    public int CurrentTime { get; private set; }

    public event Action<int> TimeChanged;  

    private void OnEnable()
    {
        _playerInput.ScreenPressed += MakeTick;
    }

    private void OnDisable()
    {
        _playerInput.ScreenPressed -= MakeTick;
    }

    private void MakeTick()
    {
        if (_isCounting)
        {
            _isCounting = !_isCounting;
            Stop();
        }
        else
        {
            _isCounting = !_isCounting;
            Restart();
        }
    }

    private void Restart()
    {
        _coroutine = StartCoroutine(IncreaseCounter());
    }

    private void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }   

    private IEnumerator IncreaseCounter()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_isCounting)
        {                
            CurrentTime += _counterTick;
            TimeChanged?.Invoke(CurrentTime);

            yield return wait;
        }  
    }
}


    
    


