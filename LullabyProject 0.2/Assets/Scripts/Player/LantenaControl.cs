using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LantenaControl : MonoBehaviour
{
    private InputLogic inputLogic;

    public Light2D luz;
    public Light2D luz2;
    private bool ligar;
    private bool lantenaCooldown;

    public AIPath aiPath;

    private GameObject obj_lant;
    private GameObject lantena;

    public Transform visao;
    public Transform point;

    public Transform inim;

    private float currentTime = 0f;
    private float bateria;

    public AudioSource SomLantena;

    // Start is called before the first frame update
    void Start()
    {
        inputLogic = GetComponent<InputLogic>();
        obj_lant = GameObject.FindWithTag("Lant");
        lantena = GameObject.FindWithTag("Lantena");

        bateria = 2000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obj_lantLogic
    {
        get { return obj_lant; }
        set { obj_lant = value; }
    }

    public bool ligarLogic
    {
        get { return ligar; }
        set { ligar = value; }
    }
    public float bateriaLogic
    {
        get { return bateria; }
        set { bateria = value; }
    }
    public Light2D luzLogic
    {
        get { return luz; }
        set { luz = value; }
    }
    public bool lantenaCooldownLogic
    {
        get { return lantenaCooldown; }
        set { lantenaCooldown = value; }
    }

    public void Lantena()
    {
        if (Input.GetKeyDown(KeyCode.R) && bateria > 0 && inputLogic.lantLogic == true)
        {
            SomLantena.Play();
            ligar = !ligar;
        }
        if (ligar == true)
        {
            lantena.SetActive(ligar);
            currentTime += 1 * Time.deltaTime;
        }
        if (currentTime >= 0.2f)
        {
            currentTime = 0.2f;
        }
        if (ligar == false)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            lantena.SetActive(ligar);
        }
        luz.pointLightInnerAngle = 450 * currentTime;
        luz.pointLightOuterAngle = 450 * currentTime;
        RayHit();
        LatenaDirecao();
        Bateria();
    }

    void Bateria()
    {
        if (ligar == true)
        {
            bateria--;
        }
        if (bateria <= 0)
        {
            ligar = false;
        }
    }

    void LatenaDirecao()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direcao = new Vector2(mousePos.x - visao.position.x, mousePos.y - visao.position.y);
        visao.up = direcao;
    }

    void RayHit()
    {
        Vector2 dir = inim.position - lantena.transform.position;
        float angle = Vector3.Angle(dir, point.up);
        RaycastHit2D hit = Physics2D.Raycast(point.position, dir, 3f);

        if (lantenaCooldown)
        {
            return;
        }

        if (angle < 90 / 2 && hit.collider != null && ligar == true && lantenaCooldown == false)
        {
            if (hit.collider.CompareTag("Inimigo") && hit.collider != null)
            {
                print("ok");
                StartCoroutine(CooldownInimigo());
            }
            print("Quase");
        }
    }
    private IEnumerator CooldownInimigo()
    {
        lantenaCooldown = true;
        aiPath.canMove = false;
        yield return new WaitForSeconds(3f);
        aiPath.canMove = true;
        yield return new WaitForSeconds(10f);
        lantenaCooldown = false;
    }
}
