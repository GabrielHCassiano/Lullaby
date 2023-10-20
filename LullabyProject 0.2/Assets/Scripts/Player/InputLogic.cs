using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLogic : MonoBehaviour
{
    private LifeControl lifeControl;
    private TransformControl transformControl;
    private SpriteControl spriteControl;
    private LantenaControl lantenaControl;

    private float inputHori;
    private float inputVert;

    private bool pegarLantena;
    private bool pegarPilha;
    private bool pegarTeddy;
    private bool abrirPorao;
    private bool usarGeladeira;
    private bool pegarChave;
    private bool lant;

    private bool andar1;
    private bool andar1_2;
    private bool andar2;
    private bool porao;

    private bool banho;

    private bool spawn;

    private bool key;
    private bool teddy;
    private bool missao;

    private bool secret;
    private bool mudar;

    // Start is called before the first frame update
    void Start()
    {
        lifeControl = GetComponent<LifeControl>();
        transformControl = GetComponent<TransformControl>();
        spriteControl = GetComponent <SpriteControl>();
        lantenaControl = GetComponent<LantenaControl>();

        secret = PlayerPrefs.GetInt("Color") != 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float InputHoriLogic
    {
        get { return inputHori; }
        set { inputHori = value; }
    }

    public float inputVertLogic
    {
        get { return inputVert; }
        set { inputVert = value; }
    }

    public bool pegarLantenaLogic
    {
        get { return pegarLantena; }
        set { pegarLantena = value; }
    }


    public bool pegarPilhaLogic
    {
        get { return pegarPilha; }
        set { pegarPilha = value; }
    }

    public bool pegarTeddyLogic
    {
        get { return pegarTeddy; }
        set { pegarTeddy = value; }
    }

    public bool abrirPoraoLogic
    {
        get { return abrirPorao; }
        set { abrirPorao = value; }
    }

    public bool usarGeladeiraLogic
    {
        get { return usarGeladeira; }
        set { usarGeladeira = value; }
    }

    public bool pegarChaveLogic
    {
        get { return pegarChave; }
        set { pegarChave = value; }
    }

    public bool andar1Logic
    {
        get { return andar1; }
        set { andar1 = value; }
    }

    public bool andar1_2Logic
    {
        get { return andar1_2; }
        set { andar1_2 = value; }
    }

    public bool andar2Logic
    {
        get { return andar2; }
        set { andar2 = value; }
    }

    public bool poraoLogic
    {
        get { return porao; }
        set { porao = value; }
    }

    public bool keyLogic
    {
        get { return key; }
        set { key = value; }
    }

    public bool teddyLogic
    {
        get { return teddy; }
        set { teddy = value; }
    }

    public bool lantLogic
    {
        get { return lant; }
        set { lant = value; }
    }

    public bool spawnLogic
    {
        get { return spawn; }
        set { spawn = value; }
    }

    public bool banhoLogic
    {
        get { return banho; }
        set { banho = value; }
    }
    public bool missaoLogic
    {
        get { return missao; }
        set { missao = value; }
    }


    public void InputGet()
    {
        inputHori = Input.GetAxisRaw("Horizontal");
        inputVert = Input.GetAxisRaw("Vertical");

        if (lifeControl.coolDownLogic)
        {
            return;
        }

        if (secret == true)
        {
            if (Input.GetKeyDown(KeyCode.E)) mudar = !mudar;
            if (mudar == false) lantenaControl.luzLogic.color = Color.white;
            if (mudar == true) lantenaControl.luzLogic.color = Color.blue;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (usarGeladeira == true && lifeControl.recuperaLogic == true && lifeControl.VidaLogic < lifeControl.MaxVidaLogic)
            {
                StartCoroutine(lifeControl.Recuperar());
            }
            if (abrirPorao == true && key == true)
            {
                spriteControl.keyImage.enabled = false;
                abrirPorao = false;
                andar1 = false;
                andar1_2 = false;
                andar2 = false;
                porao = true;
                transform.position = transformControl.pontoPLogic.transform.position;
            }
            if (pegarLantena == true)
            {
                lant = true;
                transformControl.lantHud.gameObject.SetActive(true);
                Destroy(lantenaControl.obj_lantLogic.gameObject);
            }
            if (pegarChave == true)
            {
                key = true;
                spriteControl.keyImage.enabled = true;
                Destroy(transformControl.obj_key.gameObject);
            }
            if (pegarTeddy == true && spawn == true)
            {
                teddy = true;
                transformControl.obj_teddyLogic.SetActive(false);
            }
            if (teddy == true && banho == true)
            {
                missao = true;
            }
            if (pegarPilha == true)
            {
                secret = true;
                PlayerPrefs.SetInt("Color", secret ? 1 : 0);
            }
        }
    }

    public void Missao()
    {
        if (spawn == true)
        {
            transformControl.spawnPilha.gameObject.SetActive(true);
            Destroy(transformControl.keyPilhaLogic.gameObject);
        }
    }

}
