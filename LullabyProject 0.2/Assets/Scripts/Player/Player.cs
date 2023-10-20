using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputLogic))]
[RequireComponent(typeof(MoveLogic))]
[RequireComponent(typeof(TriggerControl))]
[RequireComponent(typeof(LifeControl))]
[RequireComponent(typeof(TransformControl))]
[RequireComponent(typeof(SpriteControl))]
[RequireComponent(typeof(LantenaControl))]
[RequireComponent(typeof(FlipControl))]
[RequireComponent(typeof(AnimationControl))]

public class Player : MonoBehaviour
{
    private InputLogic inputLogic;
    private MoveLogic moveLogic;
    private SpriteControl spriteControl;
    private FlipControl flipControl;
    private LantenaControl lantenaControl;
    private TriggerControl triggerControl;
    private LifeControl lifeControl;
    private AnimationControl animationControl;

    public float times = 4f;

    public bool esconder;
    public bool dentro;
    public bool jogar;

    // Start is called before the first frame update
    void Start()
    {

        inputLogic = GetComponent<InputLogic>();
        moveLogic = GetComponent<MoveLogic>();
        lantenaControl = GetComponent<LantenaControl>();
        triggerControl = GetComponent<TriggerControl>();
        lifeControl = GetComponent<LifeControl>();
        flipControl = GetComponent<FlipControl>();
        spriteControl = GetComponent<SpriteControl>();
        animationControl = GetComponent<AnimationControl>();

    }

    // Update is called once per frame
    void Update()
    {
        inputLogic.InputGet();
        flipControl.Flip();
        lantenaControl.Lantena();
        animationControl.animControler();
        spriteControl.Vida();
        inputLogic.Missao();
    }

    void FixedUpdate()
    {
        moveLogic.Movimento();
    }
}