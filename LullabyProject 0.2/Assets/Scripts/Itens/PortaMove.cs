using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PortaMove : MonoBehaviour
{
    public bool abrir;
    public bool open;
    public bool inimigoP;
    public float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Porta();
       /* if (Input.GetKeyDown(KeyCode.F) && abrir == true && open == false || inimigoP == true)
        {
            open = true;
            transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.F) && abrir == true && open == true)
        {
            open = false;
            transform.rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        }*/
    }

    void Porta()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            open = !open;
        }
        if (open == true  && abrir == true || inimigoP == true)
        {
            currentTime += 1 * Time.deltaTime;
        }
        if (currentTime >= 0.2f)
        {
            currentTime = 0.2f;
        }
        if (open == false && abrir == true)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        if (currentTime <= 0f)
        {
            currentTime = 0f;
        }
        transform.rotation = Quaternion.AngleAxis(450 * currentTime, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            abrir = true;
        }
        if(col.gameObject.layer == LayerMask.NameToLayer("Inimigo"))
        {
            inimigoP = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            abrir = false;
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Inimigo"))
        {
            inimigoP = false;
        }
    }


}
