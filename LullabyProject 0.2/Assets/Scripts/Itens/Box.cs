using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UIElements;
using JetBrains.Annotations;
using Pathfinding;

public class Box : MonoBehaviour
{
    private LantenaControl lantenaControl;

    private LifeControl lifeControl;
    private MoveLogic moveLogic;

    public AIPath aiPath;
    private GameObject jogador;
    private bool esconder;
    private bool dentro;

    public Transform jogadorMesa;

    private GameObject inimigo;
    private GameObject timetime;

    private Vector2 anterior;
    // Start is called before the first frame update
    void Start()
    {
        lantenaControl = FindAnyObjectByType<LantenaControl>();
        jogador = GameObject.FindWithTag("Player");
        inimigo = GameObject.FindWithTag("Inimigo");
        timetime = GameObject.FindWithTag("Times");

        lifeControl = FindAnyObjectByType<LifeControl>();
        moveLogic = FindAnyObjectByType<MoveLogic>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && esconder == true)
        {
            timetime.GetComponent<TimeTime>().tempo = false;
            lantenaControl.lantenaCooldownLogic = false;
            lifeControl.recuperaLogic = true;
            moveLogic.runLogic = false;
            inimigo.GetComponent<InimigoMove>().charRun = false;
            inimigo.GetComponent<InimigoMove>().box = false;
            jogador.SetActive(false);
            esconder = false;
            dentro = true;
            anterior = jogador.transform.position;
            aiPath.canMove = true;
            jogador.transform.position = transform.position;
            jogadorMesa.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.F) && dentro == true)
        {
            timetime.GetComponent<TimeTime>().tempo = true;
            jogador.SetActive(true);
            dentro = false;
            jogador.transform.position = anterior;
            jogadorMesa.gameObject.SetActive(false);
        }
    }

    public bool dentroLogic
    {
        get { return dentroLogic; } 
        set { dentro = value; }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            esconder = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            esconder = false;
        }
    }

}
