using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Playercontroler : MonoBehaviour
{
    public bool iscardselected = false;
    public Transform Selectedcard;
    public Transform Lastcard;
    public float clicktime;
    public List<Transform> cards;


    public void submitgroup()
    {
        GameCondition.gc.cardsname.Clear();
        for (int i = 0; i < cards.Count; i++)
        {
            GameCondition.gc.cardsname.Add(cards[i].name);
        }
        GameCondition.gc.ValidateCardsType();
    }

    public void Cardlistupdate()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].GetComponent<SpriteRenderer>().color = Color.gray;
        }
        clicktime = 0;
        if(cards.Count == 0)
        {
            iscardselected = false;
        }
    }

    public void updateselectedcard(Transform selcard)
    {
        bool iscardfound = false;
        if (iscardselected)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (selcard.name == cards[i].name)
                {
                    cards.Remove(cards[i]);
                    Lastcard.GetComponent<SpriteRenderer>().color = Color.white;
                    break;
                }
            }
        }
        if (!iscardfound)
        {
            cards.Add(selcard);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickpos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            RaycastHit2D hit = Physics2D.Raycast(clickpos, Vector2.zero, 0f);

            if (hit)
            {
                if (hit.collider.gameObject.transform.tag == "Card")
                {
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;

                    Lastcard = Selectedcard;
                    Selectedcard = hit.collider.gameObject.transform;
                    if (!iscardselected)
                    {
                        if (Lastcard == null)
                        {
                            Lastcard = Selectedcard;
                        }
                        else
                        {
                            Cardlistupdate();
                            Lastcard.GetComponent<SpriteRenderer>().color = Color.white;

                        }
                    }
                    else
                    {
                        cards.Add(Selectedcard);
                        updateselectedcard(Selectedcard);
                        Cardlistupdate();
                    }
                    print(hit.collider.gameObject.transform.tag);
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            clicktime++;
            if (!iscardselected)
            {
                if (clicktime > 50)
                {
                    iscardselected = true;
                    updateselectedcard(Selectedcard);
                    Cardlistupdate();
                }
            }
        }
    }

}
