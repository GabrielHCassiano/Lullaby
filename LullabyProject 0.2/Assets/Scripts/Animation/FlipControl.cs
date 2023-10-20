using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipControl : MonoBehaviour
{
    private InputLogic inputLogic;

    private bool direcaoLado;

    // Start is called before the first frame update
    void Start()
    {
        inputLogic = GetComponent<InputLogic>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Flip()
    {
        if (direcaoLado && inputLogic.InputHoriLogic > 0) FlipLogic();

        if (!direcaoLado && inputLogic.InputHoriLogic < 0) FlipLogic();
    }

    void FlipLogic()
    {
        direcaoLado = !direcaoLado;
        transform.Rotate(0f, -180, 0f);
    }
}
