using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class TimeTime : MonoBehaviour
{
    private InputLogic inputLogic;
    private LifeControl lifeControl;

    float currentTime =  0f;
    float startingTime = 400f;

    public TextMeshProUGUI timeText;

    public Light2D global;
    public Light2D keyTeddy;

    public Image teddy;
    public Transform miss1;
    public Transform miss2;
    public Transform miss3;
    public Transform miss0;
    public Transform win;
    public Transform loss;

    public Transform secret;

    private GameObject jogo;
    private GameObject inimigo;
    private GameObject jogador;
    private GameObject texts;

    public bool end;
    public bool tempo;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        inimigo = GameObject.FindWithTag("Inimigo");
        jogo = GameObject.FindWithTag("Jogo");
        texts = GameObject.FindWithTag("texts");
        currentTime = startingTime;
        lifeControl = FindAnyObjectByType<LifeControl>();
        inputLogic = FindAnyObjectByType<InputLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tempo == true && jogo.activeSelf == true)
        {
            global.intensity -= 0.00001f ;

            currentTime -= 1 * Time.deltaTime;
            timeText.text = currentTime.ToString("0");
        }
        if (currentTime <= 0 && inputLogic.missaoLogic == true)
        {
            /*win.gameObject.SetActive(true);
            end = true;
            texts.SetActive(false);
            teddy.enabled = false;
            currentTime = 0;
            StartCoroutine(TimeCena());*/
            SceneManager.LoadScene(3);
        }
        else if (currentTime <= 0 && inputLogic.missaoLogic == false) lifeControl.morteLogic = true;

        if (lifeControl.morteLogic == true)
        {
            end = true;
            currentTime = 1;
            teddy.enabled = false;
            miss1.gameObject.SetActive(false);
            miss2.gameObject.SetActive(false);
            miss3.gameObject.SetActive(false);
            miss0.gameObject.SetActive(false);
            texts.SetActive(false);
            jogo.SetActive(false);
            loss.gameObject.SetActive(true);
            StartCoroutine(TimeLoss());
        }

        if(inputLogic.keyLogic == true)
        {
            miss1.gameObject.SetActive(false);
            miss2.gameObject.SetActive(true);
            //global.intensity = 0.1f;
            if (currentTime <= 300) inimigo.GetComponent<InimigoMove>().form2 = true;
        }

        if (inputLogic.spawnLogic == true)
        {
            keyTeddy.gameObject.SetActive(true);
            miss2.gameObject.SetActive(false);
            miss3.gameObject.SetActive(true);
            //global.intensity = 0.06f;
            if (currentTime <= 200) inimigo.GetComponent<InimigoMove>().form3 = true;
        }

        if (inputLogic.missaoLogic == true)
        {
            miss3.gameObject.SetActive(false);
            miss0.gameObject.SetActive(true);
            //global.intensity = 0.02f;
            if (currentTime <= 100) inimigo.GetComponent<InimigoMove>().form4 = true;
        }
        if(end == true) miss0.gameObject.SetActive(false);

        if(currentTime <= 7) secret.gameObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.K)) inputLogic.missaoLogic = true;

    }

    /*private IEnumerator TimeCena()
    {
        SceneManager.LoadScene(3);
        /*yield return new WaitForSeconds(0.2f);
        jogo.SetActive(false);
        yield return new WaitForSeconds(82f);
        SceneManager.LoadScene("Menu");
    }*/
    private IEnumerator TimeLoss()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu");
    }

}
