using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
//static UnityEditor.PlayerSettings;
using Unity.VisualScripting;
using System.IO;
using UnityEngine.UIElements;
using UnityEngine.Rendering.Universal;

public class InimigoMove : MonoBehaviour
{
    private InputLogic inputLogic;
    private MoveLogic moveLogic;

    public AIPath aiPath;
    public AIDestinationSetter destinationSetter;

    public float fovAngle;
    public Transform fovPoint;
    public float range;

    public float velocidade;
    public float corrida;
    public int dano;

    public Transform jogador;

    public Transform passos;
    public Transform spawnInimigo;
    public Transform inimigo;
    public Transform[] pontos;

    public bool charRun;

    public Vector2 dir;
    public Vector2 destino;

    public int num;
    public int pos;
    public int min;
    public int max;

    public bool form2;
    public bool form3;
    public bool form4;

    public Animator anim;

    private GameObject player;

    public Light2D luz;
    public Light2D luz2;
    public bool box;
    public GameObject boxx;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        min = num;
        max = 7;
        player = GameObject.FindWithTag("Player");
        boxx = GameObject.FindWithTag("Box");

        inputLogic = FindAnyObjectByType<InputLogic>();
        moveLogic = FindAnyObjectByType<MoveLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        position();
        FormS();
        RayHit();
        animControl();
    }

    void position()
    {
        if (inputLogic.andar2Logic == true)
        {
            inputLogic.andar2Logic = false;
            aiPath.canMove = false;
            num = 0;
            pos = 0;
            min = 0;
            max = 7;
            StartCoroutine(Templo());
        }
        if (inputLogic.andar1Logic == true)
        {
            inputLogic.andar1Logic = false;
            aiPath.canMove = false;
            num = 8;
            pos = 16;
            min = 8;
            max = 16;
            StartCoroutine(Templo());
        }
        if (inputLogic.andar1_2Logic == true)
        {
            inputLogic.andar1_2Logic = false;
            aiPath.canMove = false;
            num = 16;
            pos = 8;
            min = 8;
            max = 16;
            StartCoroutine(Templo());
        }
        if (inputLogic.poraoLogic == true)
        {
            inputLogic.poraoLogic = false;
            aiPath.canMove = false;
            num = 17;
            pos = 17;
            min = 17;
            max = 19;
            StartCoroutine(Templo());
        }
    }

    private IEnumerator Templo()
    {
        yield return new WaitForSeconds(6f);
        aiPath.canMove = true;
        spawnInimigo.position = pontos[pos].position;
        charRun = false;
        box = false;
    }

    void FormS()
    {
        if (form2 == true)
        {
            fovAngle = 120f;
            range = 8f;
            luz.pointLightInnerAngle = fovAngle;
            luz.pointLightOuterAngle = fovAngle;
            luz.pointLightOuterRadius = range;
        }
        if (form3 == true)
        {
            velocidade = 6;
            corrida = 9;
        }

        if (form4 == true)
        {
            dano = 2;
            luz.color = Color.magenta;
            luz2.color = Color.magenta;
        }
    }
    void RayHit()
    {
        aiPath.maxSpeed = velocidade;
        dir = jogador.position - transform.position;
        float angle = Vector3.Angle(dir, fovPoint.up);
        RaycastHit2D hit = Physics2D.Raycast(fovPoint.position, dir, range);

        if (angle < fovAngle / 2 && hit.collider != null && hit.collider.CompareTag("Player"))
        {
            print("oi");
            destinationSetter.target = jogador;
            aiPath.maxSpeed = corrida;
            box = true;
            Debug.DrawRay(fovPoint.position, dir, Color.blue);
        }

        else if (moveLogic.runLogic == true || box == true)
        {
            charRun = true;
            passos.parent = jogador;
            passos.position = jogador.position;
            destinationSetter.target = jogador;
            aiPath.maxSpeed = corrida;
        }

        else if (charRun == true)
        {
            passos.parent = null;
            destinationSetter.target = passos;
            aiPath.maxSpeed = corrida;
            if (inimigo.position == passos.position) charRun = false;
        }

        /*else if (box == true)
        {
            if (player.GetComponent<Player>().run == false)
            {
                charRun = true;
                box = false;
            }
            passos.parent = jogador;
            passos.position = jogador.position;
            destinationSetter.target = jogador;
            aiPath.maxSpeed = corrida;
        }*/
        else if (inimigo.position == pontos[num].position)
        {
            num = Random.Range(min, max);
        }

        else
        {
            destinationSetter.target = pontos[num];
        }
    }

     void animControl()
    {
        destino = destinationSetter.target.position - transform.position;
        anim.SetFloat("Horizontal", destino.x);
        anim.SetFloat("Vertical", destino.y);
        anim.SetBool("Form2", form2);
        anim.SetBool("Form3", form3);
        anim.SetBool("Form4", form4);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
        {
            box = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
        {
            box = false;
        }
    }
}
