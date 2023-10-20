using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
//using static UnityEditor.PlayerSettings;
//using static UnityEditor.Progress;

public class Inimigo : MonoBehaviour
{
    private MoveLogic moveLogic;

    public float velocidade;
    public float tempoInimigo;

    public Transform inimigo;
    public Transform[] posInim;
    public int idPos;
    private GameObject jogador;
    private GameObject som;
    private GameObject item;
    private GameObject visao;

    public bool charRun;
    public bool strop;
    public bool pess;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        visao = GameObject.FindWithTag("Visão");
        jogador = GameObject.FindWithTag("Player");
        som = GameObject.FindWithTag("Som");
        item = GameObject.FindWithTag("Item");
        inimigo.position = posInim[0].position;
        idPos = 1;

        moveLogic = FindAnyObjectByType<MoveLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        animControler();
        if (strop == true)
        {
            velocidade = 0;
        }
        if(strop == false)
        {
            StartCoroutine(StropInimigo());
        }
        if (charRun == false)
        {
            VisoDirecao();
            inimigo.position = Vector3.MoveTowards(inimigo.position, posInim[idPos].position, velocidade * Time.deltaTime);
        }
        /*if (item.GetComponent<Item>().jogar == false)
        {
            charRun = true;
            inimigo.position = Vector3.MoveTowards(inimigo.position, item.transform.position, velocidade * Time.deltaTime);
        }*/
        if (charRun == true)
        {
            VisoSom();
            inimigo.position = Vector3.MoveTowards(inimigo.position, som.transform.position, velocidade * Time.deltaTime);
            som.transform.parent = null;
            StartCoroutine(TimeInimigo());
        }
        if (moveLogic.runLogic == true || pess == true) 
        {
            VisoJogador();
            charRun = true;
            som.transform.parent = jogador.transform;
            som.transform.position = jogador.transform.position;
            inimigo.position = Vector3.MoveTowards(inimigo.position, jogador.transform.position, velocidade * Time.deltaTime);
        }
        if (inimigo.position == posInim[idPos].position)
        {
            idPos += 1;
        }

        if (idPos == posInim.Length)
        {
            idPos = 0;
        }
    }
    void VisoDirecao()
    {
        if (inimigo.position.y < posInim[idPos].position.y) visao.transform.rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        if (inimigo.position.y > posInim[idPos].position.y) visao.transform.rotation = Quaternion.AngleAxis(-180f, Vector3.forward);
        if (inimigo.position.x < posInim[idPos].position.x) visao.transform.rotation = Quaternion.AngleAxis(-90f, Vector3.forward);
        if (inimigo.position.x > posInim[idPos].position.x) visao.transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
        if (inimigo.position.x < posInim[idPos].position.x && inimigo.position.y < posInim[idPos].position.y) visao.transform.rotation = Quaternion.AngleAxis(-45f, Vector3.forward);
        if (inimigo.position.x < posInim[idPos].position.x && inimigo.position.y > posInim[idPos].position.y) visao.transform.rotation = Quaternion.AngleAxis(-135f, Vector3.forward);
        if (inimigo.position.x > posInim[idPos].position.x && inimigo.position.y < posInim[idPos].position.y) visao.transform.rotation = Quaternion.AngleAxis(45f, Vector3.forward);
        if (inimigo.position.x > posInim[idPos].position.x && inimigo.position.y > posInim[idPos].position.y) visao.transform.rotation = Quaternion.AngleAxis(135f, Vector3.forward);
    }

    void VisoSom()
    {
        if (inimigo.position.y < som.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        if (inimigo.position.y > som.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(-180f, Vector3.forward);
        if (inimigo.position.x < som.transform.position.x) visao.transform.rotation = Quaternion.AngleAxis(-90f, Vector3.forward);
        if (inimigo.position.x > som.transform.position.x) visao.transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
        if (inimigo.position.x < som.transform.position.x && inimigo.position.y < som.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(-45f, Vector3.forward);
        if (inimigo.position.x < som.transform.position.x && inimigo.position.y > som.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(-135f, Vector3.forward);
        if (inimigo.position.x > som.transform.position.x && inimigo.position.y < som.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(45f, Vector3.forward);
        if (inimigo.position.x > som.transform.position.x && inimigo.position.y > som.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(135f, Vector3.forward);
    }

    void VisoJogador()
    {
        if (inimigo.position.y < jogador.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        if (inimigo.position.y > jogador.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(-180f, Vector3.forward);
        if (inimigo.position.x < jogador.transform.position.x) visao.transform.rotation = Quaternion.AngleAxis(-90f, Vector3.forward);
        if (inimigo.position.x > jogador.transform.position.x) visao.transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
        if (inimigo.position.x < jogador.transform.position.x && inimigo.position.y < jogador.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(-45f, Vector3.forward);
        if (inimigo.position.x < jogador.transform.position.x && inimigo.position.y > jogador.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(-135f, Vector3.forward);
        if (inimigo.position.x > jogador.transform.position.x && inimigo.position.y < jogador.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(45f, Vector3.forward);
        if (inimigo.position.x > jogador.transform.position.x && inimigo.position.y > jogador.transform.position.y) visao.transform.rotation = Quaternion.AngleAxis(135f, Vector3.forward);

    }

    private IEnumerator TimeInimigo()
    {
        yield return new WaitForSeconds(tempoInimigo);
        charRun = false;
    }
    private IEnumerator StropInimigo()
    {
        yield return new WaitForSeconds(5f);
        velocidade = 3;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Lantena"))
        {
            strop = true;
        }
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            pess = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Lantena"))
        {
            strop = false;
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            pess = false;
        }
    }

    void animControler()
    {
        anim.SetFloat("Horizontal", jogador.transform.position.x);
        anim.SetFloat("Vertical", jogador.transform.position.y);
    }

}
