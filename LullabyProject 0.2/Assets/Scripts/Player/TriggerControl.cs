using System;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{

    public BoxCollider2D boxCollision;
    private LifeControl lifeControl;
    private InputLogic inputLogic;
    private TransformControl transformControl;

    private GameObject inimigo;

    // Start is called before the first frame update
    void Start()
    {
        lifeControl = GetComponent<LifeControl>();
        inputLogic =  GetComponent<InputLogic>();
        transformControl = GetComponent<TransformControl>();

        inimigo = GameObject.FindWithTag("Inimigo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BoxCollider2D boxCollisionLogic
    {
        get { return boxCollision; }
        set { boxCollision = value; }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Inimigo"))
        {
            lifeControl.VidaLogic -= inimigo.GetComponent<InimigoMove>().dano;
            if (lifeControl.VidaLogic <= 0)
            {
                lifeControl.morteLogic = true;
            }
        }

        switch (col.gameObject.layer)
        {
            case 22:
                inputLogic.pegarLantenaLogic = true;
                break;
            case 21:
                inputLogic.pegarChaveLogic = true;
                break;
            case 25:
                inputLogic.pegarTeddyLogic = true;
                break;
            case 26:
                inputLogic.banhoLogic = true;
                break;
            case 14:
                inputLogic.usarGeladeiraLogic = true;
                break;
            case 15:
                transform.position = transformControl.ponto1Logic.transform.position;
                inputLogic.andar1Logic = true;
                inputLogic.andar1_2Logic = false;
                inputLogic.andar2Logic = false;
                inputLogic.poraoLogic = false;
                break;
            case 16:
                transform.position = transformControl.ponto2Logic.transform.position;
                inputLogic.andar1Logic = false;
                inputLogic.andar1_2Logic = false;
                inputLogic.andar2Logic = true;
                inputLogic.poraoLogic = false;
                break;
            case 17:
                transform.position = transformControl.pontoP1Logic.transform.position;
                inputLogic.andar1Logic = false;
                inputLogic.andar1_2Logic = true;
                inputLogic.andar2Logic = false;
                inputLogic.poraoLogic = false;
                break;
            case 18:
                inputLogic.abrirPoraoLogic = true;
                break;
            case 24:
                inputLogic.spawnLogic = true;
                break;
            case 28:
                transformControl.telaSecret.gameObject.SetActive(false);
                break;
            case 29:
                inputLogic.pegarPilhaLogic = true;
                break;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        switch (col.gameObject.layer)
        {
            case 22:
                inputLogic.pegarLantenaLogic = false;
                break;
            case 21:
                inputLogic.pegarChaveLogic = false;
                break;
            case 25:
                inputLogic.pegarTeddyLogic = false;
                break;
            case 26:
                inputLogic.banhoLogic = false;
                break;
            case 14:
                inputLogic.usarGeladeiraLogic = false;
                break;
            case 18:
                inputLogic.abrirPoraoLogic = false;
                break;
            case 29:
                inputLogic.pegarPilhaLogic = true;
                break;
        }
    }

}
