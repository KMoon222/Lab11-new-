using System.Xml.Linq;
using UnityEngine;
using System.Collections.Generic;

public class DuplicateNameDetector : MonoBehaviour
{

    string namex;

    List<string> firstNames = new List<string>() { "Adam", "Bob", "Christina", "Dean", "Elizabeth", "Fred", "Greta", "Helen", "Jessica", "Kayla", "Lana",
        "Mike", "Nina", "Opal", "Rachael", "Selena", "Tina", "John", "Alex", "Will", "Leo", };

    List<string> chosenNames = new List<string>();


    HashSet<string> seen = new HashSet<string>();

    HashSet<string> duplicates = new HashSet<string>();


    void Start()
    {

        for (int i = 0; i < 15; i++)
        {
            namex = firstNames[Random.Range(0, firstNames.Count)];
            chosenNames.Add(namex);
        }
        

        Debug.Log("Created the name array: " + string.Join(", ", chosenNames));


        foreach (string name in chosenNames)
        {
            if (!seen.Add(name))
            {
                duplicates.Add(name);
            }

        }


        if (duplicates.Count > 0)
        {
            Debug.Log("The array has duplicate names: " +  string.Join(", ", duplicates));
        }
        else
        {
            Debug.Log("The array has no duplicate names");
        }




    }





    void Update()
    {
        
    }
}
