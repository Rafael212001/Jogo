using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pontuacao : MonoBehaviour
{
    public int pontuacaoTotal;

    public static Pontuacao instance;
    public Text pontuacaotext;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void UpdateText()
    {
        pontuacaotext.text = pontuacaoTotal.ToString();
    }
}
