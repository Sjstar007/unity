using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCondition : MonoBehaviour
{
    public static GameCondition gc;

    public string joker;
    public List<string> cardsname;
    public bool iscardtypeuniq = false;
    public bool isjokerinlist = false;

    private void Awake()
    {
        gc = this;
    }

    public void ValidateCardsType()
    {
        int cardmathcount = 0;
        string commoncard = "";
        for (int j = 0; j < cardsname.Count; j++)
        {
            print(cardsname[j]);
            if (cardsname[j].Remove(0, 1) != joker.Remove(0, 1))
            {
                commoncard = cardsname[j];
                break;
            }
        }

        for (int i = 0; i < cardsname.Count; i++)
        {
            if(i+1 < cardsname.Count)
            {
                string card = cardsname[i];
                string card2 = cardsname[i + 1];
                if(card.Substring(0,1) == card2.Substring(0, 1))
                {
                    if (int.Parse(card.Remove(0, 1)) != int.Parse(joker.Remove(0, 1)) && int.Parse(card2.Remove(0, 1)) != int.Parse(joker.Remove(0, 1))){
                        cardmathcount++;
                       
                    }
                    else {
                        cardmathcount++;
                        isjokerinlist = true;
                    }
                }else if(int.Parse(card.Remove(0, 1)) == int.Parse(joker.Remove(0, 1)))
                {
                    if(commoncard.Substring(0, 1) == card2.Substring(0, 1))
                    {
                        cardmathcount++;
                        isjokerinlist = true;
                    }
                }else if(int.Parse(card2.Remove(0, 1)) == int.Parse(joker.Remove(0, 1)))
                {
                    cardmathcount++;
                    isjokerinlist = true;
                }
            }
            
        }
        if(cardmathcount  == cardsname.Count-1)
        {
            iscardtypeuniq = true;
            checkpureseq();
        }
        else
        {
            iscardtypeuniq = false;

            bool issetmatch = setcheck();
            if (issetmatch)
            {
                print("set matched!!!");
            }
            else
            {
                print("set not matched");
            }
        }
    }

    public bool setcheck()
    {
        int cardnum = 0;
        int matchcount = 0;
        int jokker = int.Parse(joker.Remove(0,1));

        for(int i =0;i < cardsname.Count; i++)
        {
            if (cardsname[i].Remove(0, 1) != joker.Remove(0, 1))
            {
                cardnum = int.Parse(cardsname[i].Remove(0,1));
                break;
            }
        }
        for (int i = 0; i < cardsname.Count; i++)
        {
            if (i + 1 < cardsname.Count)
            {
                int fcard = int.Parse(cardsname[i].Remove(0, 2));
                int scard = int.Parse(cardsname[i + 1].Remove(0, 2));

                if(fcard == scard)
                {
                    matchcount++;
                }else if(fcard == jokker)
                {
                    if(scard == cardnum)
                    {
                        matchcount++;
                    }
                }else if (scard == jokker)
                {
                    matchcount++;
                }
            }
        }

        if (matchcount == cardsname.Count - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Start is called before the first frame update



    bool Validatepuresqu(int cavalue)
    {
        bool ismatched = false;
        for(int i = 0; i < cardsname.Count; i++)
        {
            if(cavalue == int.Parse(cardsname[i].Remove(0, 1))){
                ismatched = true;
            }
        }
        return ismatched;
    }


    public void checkpureseq()
    {
        int totaljoker = 0;
        int cardnum = 0;
        int purematchcount = 0;
        int impurematchcount = 0;
        int jokker = int.Parse(joker.Remove(0, 1));
        bool isAfound = false;

        for (int i = 0; i < cardsname.Count; i++)
        {
            if (cardsname[i].Remove(0, 1) == joker.Remove(0, 1))
            {
                totaljoker++;
            }
        }

        for (int i = 0; i < cardsname.Count; i++)
        {
            if (cardsname[i].Remove(0, 1) != joker.Remove(0, 1))
            {
                cardnum = int.Parse(cardsname[i].Remove(0, 1));
                break;
            }
        }

        for (int i = 0; i < cardsname.Count; i++)
        {
            if (i + 1 < cardsname.Count)
            {
                int fcard = int.Parse(cardsname[i].Remove(0, 1));
                //int scard = int.Parse(cardsname[i].Remove(0, 2)+1);
                bool issequence = Validatepuresqu(fcard+1);
                if (issequence)
                {
                    purematchcount++;

                }
                else
                {
                    int ncard = 2;
                    if(totaljoker > 0)
                    {
                        impurematchcount++;
                        totaljoker -= 1;

                        for (int j = 0; j < cardsname.Count; j++)
                        {
                            int card2 = int.Parse(cardsname[i].Remove(0, 2));
                            card2 += ncard;
                            bool isressequence = Validatepuresqu(card2);
                            if (isressequence)
                            {
                                impurematchcount++;
                                break;
                            }
                            else
                            {
                                if (totaljoker > 0)
                                {
                                    impurematchcount++;
                                    totaljoker -= 1;
                                }
                                else
                                {
                                    print("crad sequence not matched!!");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        //bool isAcardisthere = false;
                        for (int x = 0; x < cardsname.Count; x++)
                        {
                            if(int.Parse(cardsname[x].Remove(0, 1)) == 1)
                            {
                                //isAcardisthere = true;
                                isAfound = true;
                                break;
                            }
                        }
                        if (isAfound)
                        {
                            bool isj = Validatepuresqu(11);
                            if (isj)
                            {
                                bool isq = Validatepuresqu(12);
                                if (isq)
                                {
                                    bool isk = Validatepuresqu(13);
                                    if (isk)
                                    {
                                        isAfound = true;
                                        purematchcount++;
                                    }
                                    else
                                    {
                                        isAfound = false;
                                    }
                                }
                                else
                                {
                                    isAfound = false;
                                }
                            }
                            else
                            {
                                isAfound = false;
                            }

                          
                        }
                        else
                        {
                            print("card seq not matched!!");
                        } 
                    }
                }
            }
        }
        if (purematchcount == cardsname.Count -1 && !isjokerinlist)
        {
            print("Pure Sequence");
        }
        else if(purematchcount + impurematchcount == cardsname.Count-1 && isjokerinlist)
        {
            print("Impure Sequence");
        }
        else
        {
            checkAQK();
        }
      }


    public void checkAQK()
    {
        int matckcount = 0;
        if (cardsname.Count == 3)
        {
            for(int i = 0; i < cardsname.Count; i++)
            {
                if(int.Parse(cardsname[i].Remove(0,1)) == 1 || int.Parse(cardsname[i].Remove(0, 1)) == 12 || int.Parse(cardsname[i].Remove(0, 1)) == 13)
                {
                    matckcount++;
                }
            }
        }

        if(matckcount == cardsname.Count)
        {
            print("Pure Sequence");
        }
    }
}
