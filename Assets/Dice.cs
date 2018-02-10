using UnityEngine;
using System.Collections;

[System.Serializable]
public class Dice
{

    // initialize rng (Random Number Generator)
    static System.Random rng = new System.Random();

    static void Start()
    {
        
    }

    // Update is called once per frame
    static void Update()
    {
            
    }

    public static int RollStat()
    {
        //initialize
        int i, ii, iii;
        int lowest, total = 0;
        int[] rolls = new int[4] { 0, 0, 0, 0 };


        //roll 4d6
        for (i = 0; i < 4; i++)
        {
            rolls[i] = rng.Next(1, 7);
        }


        //calculate lowest
        lowest = rolls[0];

        for (ii = 1; ii < rolls.Length; ii++)
        {
            if (lowest > rolls[ii])
            {
                lowest = rolls[ii];
            }
        }

        //Sum rolls
        for (iii = 0; iii < rolls.Length; iii++)
        {
            total += rolls[iii];
        }

        //drop lowest
        total -= lowest;

        //return result cast as an int. Floats were used in the first place because thats what Random.Range outputs.
        return total;
    }


}
