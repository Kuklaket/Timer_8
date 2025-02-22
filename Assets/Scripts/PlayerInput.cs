using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action ScreenPressed;

    private void Update()
    {
        Pressed();
    }

    public void Pressed()
    {
        if (Input.GetMouseButtonDown(0))      
            ScreenPressed?.Invoke();                
    }
}
