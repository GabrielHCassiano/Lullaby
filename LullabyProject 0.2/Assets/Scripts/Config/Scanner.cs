using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{

    public Transform andar1;
    public Transform andar2;
    public Transform porao;

    public bool irAndar1;
    public bool irAndar2;
    public bool irPorao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {

    }

}
