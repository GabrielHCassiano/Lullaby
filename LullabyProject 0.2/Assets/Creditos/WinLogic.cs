using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLogic : MonoBehaviour
{
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject GameDesings;
    [SerializeField] private GameObject Programadores;
    [SerializeField] private GameObject Art;
    [SerializeField] private GameObject Music;
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject Lullaby;
    [SerializeField] private GameObject play;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WinCooldown());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator WinCooldown()
    {
        yield return new WaitForSeconds(21.4f);
        GameDesings.SetActive(true);
        yield return new WaitForSeconds(5f);
        Programadores.SetActive(true);
        yield return new WaitForSeconds(5f);
        Art.SetActive(true);
        yield return new WaitForSeconds(5f);
        Music.SetActive(true);
        yield return new WaitForSeconds(5f);
        obj.SetActive(true);
        yield return new WaitForSeconds(12f);
        Lullaby.SetActive(true);
        yield return new WaitForSeconds(20f);
        play.SetActive(true);
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(0);
    }
}
