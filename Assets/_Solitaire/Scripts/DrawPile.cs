using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrawPile : MonoBehaviour
{
    public List <Card> cards = new List <Card> ();
    public GameObject cardPrefab;
    public CardMaterialAutomation cardSource;
    public void GenerateCards()
    {
        for(Card.Suit suit = Card.Suit.Spade; suit < Card.Suit.Count; suit++)
        {
            for(Card.Rank rank = Card.Rank.Ace; rank < Card.Rank.Count; rank++)
            {
                //suitCount : 5 rankCount : 14 
                //               s,r
                //13 SpadeAce    1,1 s * 13 + r - 1
                //14 SpadeTwo    1,2 
                //15 SpadeThree  1,3
                //16 SpadeFour   1,4
                //25 SpadeKing   1,13
                //26 HeartAce    2,1
                //39 DiamondAce  3,1
                //
                int i = ((int)suit - 1) * ((int)Card.Rank.Count - 1) + (int)rank - 1;
                Card card = Instantiate(cardPrefab).GetComponent<Card>();
                card.transform.position = i / 10f * Vector3.right + i / 10f * Vector3.forward;
                card.Moveable = true;
                card.GetComponentInChildren<Renderer>().material = cardSource.materials[i + 13];
                card.name = card.GetComponentInChildren<Renderer>().material.name;
                cards.Add(card);
            }
        }
        ShuffleCards();
    }
    public void ShuffleCards() 
    {
        Shuffle(cards);
        for(int i = 0; i < cards.Count; i++)
        {
            Card card = cards[i];
            card.transform.position = i / 10f * Vector3.right + i / 10f * Vector3.forward;
        }
    }
    static void Shuffle(List<Card> array)
    {
        int n = array.Count;
        for (int i = 0; i < (n - 1); i++)
        {
            // Use Next on random instance with an argument.
            // ... The argument is an exclusive bound.
            //     So we will not go past the end of the array.
            int r = i + UnityEngine.Random.Range(0, n - i);
            Card t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
