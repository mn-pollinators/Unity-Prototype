using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundHandler : MonoBehaviour
{

    private int Round;

    /// <summary>
    /// The total number of rounds minus one
    /// </summary>
    private readonly int NUMROUNDS = 1;

    /// <summary>
    /// Advances the round by one. If it is already the final round, reset to round 0
    /// </summary>
    public void NextRound()
    {
        Round++;
        if(Round>NUMROUNDS)
        {
            Round = 0;
        }
    }

    /// <summary>
    /// Go back one round, unless it is already the first round
    /// </summary>
    public void PreviousRound()
    {
        if(Round>0)
        {
            Round--;
        }
    }

    public int ConvertImageToSprite(int imageIndex)
    {
        if(Round==0)
        {
            return imageIndex % 2;
        }

        if(Round==1)
        {
            return (imageIndex + 1) % 2;
        }

        return 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        Round = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
