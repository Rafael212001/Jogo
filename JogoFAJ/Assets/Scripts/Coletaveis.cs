using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Pego do canal Crie Seus jogos https://www.youtube.com/channel/UCXxkw9HWPVXVZsi1oTVvKCQ
//Mais pegando como referencia
//Link Playlist https://www.youtube.com/watch?v=Vt7VtkWb3R4&list=PLW-9djkTMdfVNJD9aEnoOzkrU8dUoD7j4

public class Coletaveis : MonoBehaviour
{
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Pontuacao.instance.pontuacaoTotal += Score;
            Pontuacao.instance.UpdateText();
            Destroy(gameObject);
        }
    }
}
