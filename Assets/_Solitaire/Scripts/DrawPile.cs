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
            }
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
