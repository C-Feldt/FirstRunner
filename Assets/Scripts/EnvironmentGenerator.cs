using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private Transform target = null;       // The character's position for terrain generation
    [SerializeField] private HeroCharacterController hero;  // Hero's script for GameState management
    [SerializeField] private GameObject[] envBlocks = new GameObject[20];    // Array of blocks (Change size as necessary, along with other arrays)
    private int numOfBlocks;                                // The number of blocks (set in the Start() function)
    private int currentBlockIndex = 0;                      // The currently selected block in the array
    private Vector3[] startingPositions = new Vector3[20];  // Where the blocks should start
    private int yRawNum;                                    // Stores the raw random number returned
    private int yFinNum;                                    // Stores the final number to be used
    private int yPreviousVal = 0;                               // Stores the previous y Value
    private int yPreviousVal2 = 0;                              // Stores the previous, previous y Value
    private int xGenerationPoint = -10;                     // Where blocks will be generated on the x-axis (start at -10)
    private int playerPositionInt;                          // The player's position on the x-axis in Integer represenation (to drop off extra digits)
    private bool hasBeenChanged = false;                    // Whether the next block has been moved
    private bool hasBeenReset = true;

    void Start()
    {
        numOfBlocks = envBlocks.Length;     // Sets number of blocks to variable (useful later)

        // Generates starting positions for the blocks, along the x-axis
        for(currentBlockIndex = 0; currentBlockIndex < numOfBlocks; currentBlockIndex++)
        {
            startingPositions[currentBlockIndex] = new Vector3(xGenerationPoint, 0, 0);
            envBlocks[currentBlockIndex].transform.position = startingPositions[currentBlockIndex];
            xGenerationPoint += 2;
        }
        currentBlockIndex = 0;  // Resets currentBlockIndex to 0
    }

    void Update()
    {
        playerPositionInt = (int) target.position.x;    // Sets player's position to an integer

        if(hero.gameState == "Playing")
        {
            hasBeenReset = false;
            if(!hasBeenChanged && playerPositionInt % 2 == 0)
            {
                yFinNumSet();
                // Set new position
                envBlocks[currentBlockIndex].transform.position = new Vector3(xGenerationPoint, yFinNum, 0);

                // Set values to next phases
                xGenerationPoint += 2;
                currentBlockIndex++;
                if(currentBlockIndex > 19) currentBlockIndex = 0;
                hasBeenChanged = true;
            }
            else if(hasBeenChanged && playerPositionInt % 2 == 1)
            {
                hasBeenChanged = false;
            }
        }
        if(hero.gameState == "StartMenu" && !hasBeenReset)
        {
            xGenerationPoint = -10;
            for(currentBlockIndex = 0; currentBlockIndex < numOfBlocks; currentBlockIndex++){
                envBlocks[currentBlockIndex].transform.position = startingPositions[currentBlockIndex];
                xGenerationPoint += 2;
            }
            currentBlockIndex = 0;
            hasBeenReset = true;
            yPreviousVal = 0;
            yPreviousVal2 = 0;
        }
    }

    private void yFinNumSet()
    {
        if(yPreviousVal == -20)
        {
            yRawNum = Random.Range(-1, yPreviousVal2 + 3);
            if(yRawNum < -1){
                yFinNum = -1;
            }
            else if(yRawNum > 6){
                yFinNum = 6;
            }
            else {
                yFinNum = yRawNum;
            }
        }
        else {
            yRawNum = Random.Range(-4, yPreviousVal + 3);
            if(yRawNum < -1){
                yFinNum = -20;
            }
            else if(yRawNum < -1){
                yFinNum = -1;
            }
            else if(yRawNum > 6){
                yFinNum = 6;
            }
            else {
                yFinNum = yRawNum;
            }
        }
                
        yPreviousVal2 = yPreviousVal;
        yPreviousVal = yFinNum;
    }
}
