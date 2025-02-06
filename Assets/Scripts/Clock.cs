using TMPro;
using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCounter;
    
    private bool _isCounting = false;
    private int _currentTime = 0;
    private float _delay = 0.5f;
    private int _counterTick = 1;

    private void Start()
    {
        _textCounter.text = "0";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {           
                _isCounting = !_isCounting;
                StopCoroutine(Counter());
            }
            else
            {
                _isCounting = !_isCounting;
                StartCoroutine(Counter());   
            }
        }      
    }

    private IEnumerator Counter()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_isCounting)
        {                
            _currentTime += _counterTick;
            _textCounter.text = _currentTime.ToString("");

            yield return wait;
        }  
    }
}


    
    


