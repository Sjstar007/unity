using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updatecardinfo : MonoBehaviour
{
    Gmscript gm;
    public Sprite Cardface;
    public Sprite CardBack;
    public bool Isfaceon = false;
    public SpriteRenderer sprenderer;
    public int myvalue;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<Gmscript>();

        sprenderer = GetComponent<SpriteRenderer>();

        Setingcardface();
    }

    void Setingcardface()
    {
        List<string> cardname = gm.CreatingDeck();
        int i = 0;
        foreach (string card in cardname)
        {
            if (this.name == card)
            {
                Cardface = gm.Card[i];
                sprenderer.sprite = Cardface;
                updatemyvalue();
                break;
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Isfaceon)
            sprenderer.sprite = Cardface;
        else
            sprenderer.sprite = CardBack;
    }
    public void updatemyvalue()
    {
        myvalue = int.Parse(gameObject.name.Remove(0, 1));
        if (myvalue > 10 || myvalue == 1 )
        {
            myvalue = 10;
        }
    }
}
