using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpriteControl : MonoBehaviour
{

    public Image[] coracao;

    public Image keyImage;

    private LifeControl lifeControl;

    // Start is called before the first frame update
    void Start()
    {
        lifeControl = GetComponent<LifeControl>();
        keyImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Vida()
    {

        switch (lifeControl.VidaLogic)
        {
            case 6:
                for (int i = 0; i < coracao.Length; i++)
                    coracao[i].enabled = true;
                break;
            case 5:
                for (int i = 0; i < coracao.Length; i++)
                    coracao[i].enabled = true;
                    coracao[5].enabled = false;
                break;
            case 4:
                for (int i = 0; i < coracao.Length; i++)
                    coracao[i].enabled = true;
                    coracao[5].enabled = false;
                    coracao[4].enabled = false;
                break;
            case 3:
                for (int i = 0; i < coracao.Length; i++)
                    coracao[i].enabled = true;
                for (int i = 3; i < coracao.Length; i++)
                    coracao[i].enabled = false;
                break;
            case 2:
                for (int i = 0; i < coracao.Length; i++)
                    coracao[i].enabled = false;
                    coracao[1].enabled = true;
                    coracao[0].enabled = true;
                break;
            case 1:
                for (int i = 0; i < coracao.Length; i++)
                    coracao[i].enabled = false;
                    coracao[0].enabled = true;
                break;
        }
    }


}
