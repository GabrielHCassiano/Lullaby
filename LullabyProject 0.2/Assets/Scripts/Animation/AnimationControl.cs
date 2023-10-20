using System.Collections;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    private LifeControl lifeControl;
    private MoveLogic moveLogic;
    private LantenaControl lantenaControl;

    public Animator anim;
    public Animator animStamina;
    public Animator animLantena;
    public Animator animGeladeira;


    // Start is called before the first frame update
    void Start()
    {
        moveLogic = GetComponent<MoveLogic>();
        lifeControl = GetComponent<LifeControl>();
        lantenaControl = GetComponent<LantenaControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void animControler()
    {
        anim.SetFloat("Horizontal", moveLogic.velocityLogic.x);
        anim.SetFloat("Vertical", moveLogic.velocityLogic.y);
        anim.SetBool("Crawl", moveLogic.crawlLogic);
        anim.SetBool("Lant", lantenaControl.ligarLogic);
        animLantena.SetFloat("Bateria", lantenaControl.bateriaLogic);
        animStamina.SetFloat("Stamina", moveLogic.staminaLogic);
        animGeladeira.SetBool("Abrir", lifeControl.coolDownLogic);
    }

}
