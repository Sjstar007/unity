//using System;
//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Gmscript : MonoBehaviour
{
    public static Gmscript gm;
    public Sprite[] Card;
    public GameObject cardprfabs;
    public static string[] Typeofcard = { "S", "C", "D", "H" };
    public static string[] valueofcard = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13" };
    public List<string> Deck;
    public GameObject CardContainer;
    public GameObject JokerContainer;
    public GameObject carddropcontainer;
    public GameObject player1;
    public GameObject player2;

    public List<string> playercard;
    public int score;
    public Text scoretext;
    public List<string> Playercardname;


    // [SerializeField] private GameObject Player_Hand, TablePool, cardPreFab, dummyCardPrefab;


    

    private void Awake()
    {
        gm = this;
    }
    void Start()
    {
        Gamestart();
    }
    public void Gamestart()
    {
        CreatingDeck();
        Deck = CreatingDeck();
        shuffle(Deck);
        CardSpwn();
        Gettingjoker();
        setting();
        setting1();
    }
    public List<string> CreatingDeck()
    {
        List<string> newdeck = new List<string>();
        foreach (string toc in Typeofcard)
        {
            foreach (string voc in valueofcard)
            {
                newdeck.Add(toc + voc);
            }
        }
        return newdeck;
    }
    public void shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;

            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }
    public void CardSpwn()
    {
        foreach (string cardname in Deck)
        {
            GameObject cards = Instantiate(cardprfabs, CardContainer.transform);
            cards.name = cardname;
        }
    }

    void Gettingjoker()
    {
        int index = Random.Range(0, CardContainer.transform.childCount);

        CardContainer.transform.GetChild(index).transform.SetParent(JokerContainer.transform);
        JokerContainer.transform.GetChild(0).gameObject.transform.GetComponent<Updatecardinfo>().Isfaceon = true;
        JokerContainer.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0, 0, 0);
        //JokerContainer.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    void setting()
    {
        float z = -2;
        for (int i = 0; i < playercard.Count; i++)
        {
            for(int k=0;k< CardContainer.transform.childCount; k++)
            {
                if(playercard[i] == CardContainer.transform.GetChild(k).gameObject.name)
                {
                    Playercardname.Add(CardContainer.transform.GetChild(k).gameObject.name);
                }
            }
            //Playercardname.Add(CardContainer.transform.GetChild(i).gameObject.name);
        }
        Playercardname.Sort();

        foreach (var cardname in Playercardname)
        {
            CardContainer.transform.Find(cardname).gameObject.transform.SetParent(player1.transform);
            player1.transform.Find(cardname).gameObject.GetComponent<Updatecardinfo>().Isfaceon = true;
            player1.transform.Find(cardname).gameObject.transform.localPosition = new Vector3(0, 0, z);
            z -= 2;
        }
    }
    void setting1()
    {
        Playercardname.Clear();
        float z = -1;
        for (int i = 0; i < 13; i++)
        {
            Playercardname.Add(CardContainer.transform.GetChild(i).gameObject.name);
        }
        Playercardname.Sort();

        foreach (var cardname in Playercardname)
        {
            //CardContainer.transform.Find(cardname).transform.SetParent(player.transform);
            //player.transform.Find(cardname).gameObject.transform.GetComponent<Updatecardinfo>().Isfaceon = true;
            CardContainer.transform.Find(cardname).gameObject.transform.SetParent(player2.transform);
            player2.transform.Find(cardname).gameObject.GetComponent<Updatecardinfo>().Isfaceon = true;
            player2.transform.Find(cardname).gameObject.transform.localPosition = new Vector3(0, 0, z);
            z -= 2;
        }
        Invoke("UpdatePlayerScore", 1);
    }

    
    // Update is called once per frame
    public void UpdatePlayerScore()
    {
        for(int i =0;i < player1.transform.childCount; i++)
        {
            if (player1.transform.GetChild(i).GetComponent< Updatecardinfo>() != null)
            {
                score += player1.transform.GetChild(i).GetComponent<Updatecardinfo>().myvalue;
            }
        }
        if(score > 80)
        {
            score = 80;
        }
        //scoretext.text = score.ToString();
    }
}
