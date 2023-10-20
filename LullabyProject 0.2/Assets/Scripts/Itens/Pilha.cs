using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pilha : MonoBehaviour
{
    private LantenaControl lantenaControl;
    private GameObject jogador;
    private float pilha;
    private bool pegar;
    private float maxBateria;
    // Start is called before the first frame update
    void Start()
    {
        lantenaControl = FindAnyObjectByType<LantenaControl>();
        jogador = GameObject.FindWithTag("Player");
        maxBateria = 2000;
    }

    // Update is called once per frame
    void Update()
    {
        pilha = lantenaControl.bateriaLogic;
        if (Input.GetKeyDown(KeyCode.F) && pegar == true && pilha + 500 < maxBateria)
        {
            lantenaControl.bateriaLogic = pilha + 500;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        pegar = true;
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        pegar = false;
    }
}
