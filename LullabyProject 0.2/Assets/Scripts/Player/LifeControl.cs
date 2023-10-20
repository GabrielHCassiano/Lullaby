using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LifeControl : MonoBehaviour
{

    private int vida;
    private int maxVida;
    private bool morte;

    private bool recupera;
    private bool inRecupera;
    // Start is called before the first frame update
    void Start()
    {
        recupera = true;
        maxVida = 6;
        vida = maxVida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int VidaLogic
    {
        get { return vida; }
        set { vida = value; }
    }

    public int MaxVidaLogic
    {
        get { return maxVida; }
        set { maxVida = value; }
    }

    public bool morteLogic
    {
        get { return morte; }
        set { morte = value; }
    }

    public bool recuperaLogic
    {
        get { return recupera; }
        set { recupera = value; }
    }


    public bool coolDownLogic
    {
        get { return inRecupera; }
        set { inRecupera = value; }
    }

    public IEnumerator Recuperar()
    {
        recupera = false;
        inRecupera = true;
        yield return new WaitForSeconds(6f);
        vida++;
        inRecupera = false;
        yield return new WaitForSeconds(6f);
        recupera = true;
    }
}
