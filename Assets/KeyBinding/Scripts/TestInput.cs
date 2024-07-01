using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    public InputActionReference input_a;
    public InputActionReference input_b;
    public InputActionReference input_c;
    public InputActionReference input_d;

    void Start()
    {
        input_a.action.performed += TestInputA;
        input_b.action.performed += TestInputB;
        input_c.action.performed += TestInputC;
        input_d.action.performed += TestInputD;
    }

    private void TestInputA(InputAction.CallbackContext context)
    {
        Debug.Log("Input A");
    }

    private void TestInputB(InputAction.CallbackContext context)
    {
        Debug.Log("Input B");
    }

    private void TestInputC(InputAction.CallbackContext context)
    {
        Debug.Log("Input C");
    }

    private void TestInputD(InputAction.CallbackContext context)
    {
        Debug.Log("Input D");
    }
}
