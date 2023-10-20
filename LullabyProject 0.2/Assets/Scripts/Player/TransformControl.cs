using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformControl : MonoBehaviour
{
    public Transform lantHud;
    public Transform spawnPilha;

    public Transform loss;
    public Transform win;

    private GameObject pilha;

    private GameObject keyPilha;

    public GameObject obj_key;

    private GameObject obj_teddy;

    private GameObject geladeira;

    private GameObject box;

    private GameObject item;

    private GameObject inimigo;

    private GameObject ponto1;
    private GameObject ponto2;
    private GameObject pontoP1;
    private GameObject pontoP;

    private GameObject jogo;

    private Vector3 mousePos;

    public Vector2 anterior;
    public Vector3 posisaoJogar;

    public Transform telaSecret;
    // Start is called before the first frame update
    void Start()
    {
        box = GameObject.FindWithTag("Box");
        item = GameObject.FindWithTag("Item");
        obj_key = GameObject.FindWithTag("Key");
        obj_teddy = GameObject.FindWithTag("Teddy");
        inimigo = GameObject.FindWithTag("Inimigo");
        pilha = GameObject.FindWithTag("Bateria");
        ponto1 = GameObject.FindWithTag("Andar1");
        ponto2 = GameObject.FindWithTag("Andar2");
        pontoP = GameObject.FindWithTag("Porao");
        pontoP1 = GameObject.FindWithTag("Andar1_2");
        jogo = GameObject.FindWithTag("Jogo");
        keyPilha = GameObject.FindWithTag("KeyPilha");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject keyPilhaLogic
    {
        get { return keyPilha; }
        set { keyPilha = value; }
    }

    public GameObject obj_teddyLogic
    {
        get { return obj_teddy; }
        set { obj_teddy = value; }
    }

    public GameObject ponto1Logic
    {
        get { return ponto1; }
        set { ponto1 = value; }
    }

    public GameObject ponto2Logic
    {
        get { return ponto2; }
        set { ponto2 = value; }
    }

    public GameObject pontoP1Logic
    {
        get { return pontoP1; }
        set { pontoP1 = value; }
    }

    public GameObject pontoPLogic
    {
        get { return pontoP; }
        set { pontoP = value; }
    }

}
