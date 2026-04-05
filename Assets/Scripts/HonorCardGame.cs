using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class HonorCardGame : MonoBehaviour
{

    bool win = false;

    string drawn;
    string discarded;

    // create empty stack
    Stack<string> deck = new Stack<string>();

    List<string> hand = new List<string>();

    List<string> suits = new List<string>() {"\u2660", "\u2663", "\u2665", "\u2666" };



    void CheckForWin()
    {


        foreach (string suit in suits)
        {
            int suitCount = 0;

            foreach (string item in hand)
            {
                if (item.Contains(suit.ToString()))
                {
                    suitCount++;
                }
            }
            if (suitCount >= 3)
            {
                win = true;
                return;
            }
        }

        return;
    }



    void Start()
    {
        // add all cards to stack
        deck.Push("K\u2660");
        deck.Push("Q\u2660");
        deck.Push("J\u2660");
        deck.Push("A\u2660");
        deck.Push("K\u2663");
        deck.Push("Q\u2663");
        deck.Push("J\u2663");
        deck.Push("A\u2663");
        deck.Push("K\u2665");
        deck.Push("Q\u2665");
        deck.Push("J\u2665");
        deck.Push("A\u2665");
        deck.Push("K\u2666");
        deck.Push("Q\u2666");
        deck.Push("J\u2666");
        deck.Push("A\u2666");

        // shuffle deck
        deck = new Stack<string>(deck.OrderBy(x => UnityEngine.Random.value));

        //Debug.Log(string.Join(", ", deck));


        hand.Add(deck.Pop()); 
        hand.Add(deck.Pop()); 
        hand.Add(deck.Pop()); 
        hand.Add(deck.Pop());

        Debug.Log("I made the initial deck and draw. My hand is: " + string.Join(", ", hand));

        CheckForWin();

        if (win == true){

            Debug.Log("I won!");

        }


        while(deck.Count > 0)
        {
           
            // discard random card, draw a card
            int randomIndex = UnityEngine.Random.Range(0, hand.Count);
            string discarded = hand[randomIndex];
            hand.RemoveAt(randomIndex);
            string drawn = deck.Peek();
            hand.Add(deck.Pop());
            CheckForWin();

            if (win == true)
            {

                Debug.Log("I discarded " + discarded + " and drew " + drawn + ". My hand is: " + string.Join(", ", hand) + ". The game is WON.");

                break;
            }
            else
            {
                Debug.Log("I discarded " + discarded + " and drew " + drawn + ". My hand is: " + string.Join(", ", hand) + ". This is not a winning hand. I will attempt to play another round.");
            }
           

        }
        
        if (deck.Count == 0)
        {
            Debug.Log("The deck is empty. The game is LOST.");
        }









    }



    void Update()
    {
        
    }
}
