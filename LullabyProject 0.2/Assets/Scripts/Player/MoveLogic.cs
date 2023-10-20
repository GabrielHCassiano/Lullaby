using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveLogic : MonoBehaviour
{

    private Rigidbody2D rb;
    private InputLogic inputLogic;
    private TriggerControl triggerControl;

    private float velocidade;

    private float maxStamina;
    private float stamina;

    private bool canMove;
    private bool run;
    private bool crawl;

    public AudioSource SomPassos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputLogic = GetComponent<InputLogic>();
        triggerControl = GetComponent<TriggerControl>();

        canMove = true;

        maxStamina = 500;
        stamina = maxStamina;

        velocidade = 2;

    }

    // Update is called once per frame

    public Vector2 velocityLogic
    {
        get { return rb.velocity; }
        set { rb.velocity = value; }
    }

    public float velocidadeLogic
    {
        get { return velocidade; }
        set { velocidade = value; }
    }

    public float maxStaminaLogic
    {
        get { return maxStamina; }
        set { maxStamina = value; }
    }

    public float staminaLogic
    {
        get { return stamina; }
        set { stamina = value; }
    }

    public bool canMoveLogic
    {
        get { return canMove; }
        set { canMove = value; }
    }

    public bool runLogic
    {
        get { return run; }
        set { run = value; }
    }


    public bool crawlLogic
    {
        get { return crawl; }
        set { crawl = value; }
    }

    public void Movimento()
    {
        if (canMove == true)
        {
            SomPassos.Pause();
            triggerControl.boxCollisionLogic.edgeRadius = 4;
            Vector2 direcao = new Vector2(inputLogic.InputHoriLogic, inputLogic.inputVertLogic);
            direcao = direcao.normalized;
            rb.velocity = direcao * velocidade;
            if (rb.velocity != new Vector2(0f, 0f))
            {
                SomPassos.Play();
            }
            Run();
            if (Input.GetKey(KeyCode.LeftControl) && run == false)
            {
                crawl = true;
                SomPassos.Pause();
                triggerControl.boxCollisionLogic.edgeRadius = 0;
                rb.velocity = rb.velocity / 1.2f;
            }
            else crawl = false;
            if (rb.velocity == Vector2.zero) triggerControl.boxCollisionLogic.edgeRadius = 0;
        }
    }

    void Run()
    {

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            run = true;
            stamina--;
            triggerControl.boxCollisionLogic.edgeRadius = 8;
            rb.velocity = rb.velocity * 3;
        }
        else if (stamina == 0)
        {
            run = false;
            if (!Input.GetKey(KeyCode.LeftShift)) stamina++;
        }
        else if (stamina != maxStamina)
        {
            run = false;
            stamina++;
        }
    }
}
