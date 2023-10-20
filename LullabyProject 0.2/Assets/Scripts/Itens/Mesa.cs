using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mesa : MonoBehaviour
{
    public Transform jogador;
    private GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        box = GameObject.FindWithTag("Box");
    }

    // Update is called once per frame
    void Update()
    {
        if(box.GetComponent<Box>().dentroLogic == true)
        {
            jogador.gameObject.SetActive(true);
        }else jogador.gameObject.SetActive(false);
    }
}
