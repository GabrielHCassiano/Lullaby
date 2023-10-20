using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
//using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    /*private GameObject jogador;
    public bool pegar;
    public bool jogar;
    public float inputJogador;
    public float inputJogador2;
    public Vector3 posisaoJogar;
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");   
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && pegar == true)
        {
            pegar = false;
            jogar = true;
            transform.parent = jogador.transform;
        }
        else if (Input.GetKeyDown(KeyCode.F) && jogar == true)
        {
            inputJogador = jogador.GetComponent<Player>().inputHori;
            inputJogador2 = jogador.GetComponent<Player>().inputVert;
            jogar = false;
            transform.parent = null;
            posisaoJogar = new Vector3(2 * inputJogador, 2 * inputJogador2, 0f);
            transform.position = jogador.transform.position + posisaoJogar;
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

    */
}
