using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;


public class LoginQueue : MonoBehaviour
{

    string first;
    string last;
    string nameA;
    
    List<string> namesList = new List<string>();


    string[] firstNames = new string[] { "Adam", "Bob", "Christina", "Dean", "Elizabeth", "Fred", "Greta", "Helen", "Jessica", "Kayla", "Lana", 
        "Mike", "Nina", "Opal", "Rachael", "Selena", "Tina", "John", "Alex", "Will", "Leo", };

    string[] lastInitials = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
        "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", };

    string GetRandomPlayerName()
    {
        first = firstNames[ Random.Range(0, firstNames.Length) ];
        last = lastInitials[Random.Range(0, lastInitials.Length)];
        return first + " " + last;
    }

    Queue<string> loginQueue = new Queue<string>();


    void AddPlayer()
    {
        //Debug.Log("add");
        nameA = GetRandomPlayerName();
        loginQueue.Enqueue(nameA);
        Debug.Log(nameA + " is trying to login and added to the login queue.");

    }

    void LoginPlayer()
    {
        //Debug.Log("login");
        if (loginQueue.Count > 0)
        {
            string item = loginQueue.Dequeue();
            Debug.Log(item + " is now inside the game.");
        }
        else
        {
            Debug.Log("Login server is idle. No players are waiting.");
        }

    }

    void Start()
    {


        nameA = GetRandomPlayerName();
        loginQueue.Enqueue(nameA);
        nameA = GetRandomPlayerName();
        loginQueue.Enqueue(nameA);
        nameA = GetRandomPlayerName();
        loginQueue.Enqueue(nameA);
        nameA = GetRandomPlayerName();
        loginQueue.Enqueue(nameA);
        nameA = GetRandomPlayerName();
        loginQueue.Enqueue(nameA);


        namesList = loginQueue.ToList();


        Debug.Log("Initial login queue created. There are " + namesList.Count + " players in the queue: " + string.Join(", ", namesList));


        InvokeRepeating("AddPlayer", 0f, 5.0f);
        InvokeRepeating("LoginPlayer", 0f, 3.0f);


    }

    void Update()
    {
        
    }
}
