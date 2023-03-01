using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public GameObject goalPrefab;
    public GameObject waterPrefab;
    public GameObject coinPrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }
    
    public void onDeath(){
        ReloadLevel();
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            char[] letters = currentLine.ToCharArray();
            for (int column = 0; column < letters.Length; column++)
            {
                var letter = letters[column];

                if (letter == 'x')
                {
                    var newRock = Instantiate(rockPrefab, new Vector3(column, row, 0f), Quaternion.identity);
                    newRock.transform.parent = environmentRoot;
                }
                else if (letter == 's')
                {
                    var newStone = Instantiate(stonePrefab, new Vector3(column, row, 0f), Quaternion.identity);
                    newStone.transform.parent = environmentRoot;
                }
                else if (letter == 'b')
                {
                    var newBrick = Instantiate(brickPrefab, new Vector3(column, row, 0f), Quaternion.identity);
                    newBrick.transform.parent = environmentRoot;
                }
                else if (letter == '?')
                {
                    var newQBox = Instantiate(questionBoxPrefab, new Vector3(column, row, 0f), Quaternion.identity);
                    newQBox.transform.parent = environmentRoot;
                }
                else if (letter == 'g')
                {
                    var newGoal = Instantiate(goalPrefab, new Vector3(column, row, 0f), Quaternion.identity);
                    newGoal.transform.parent = environmentRoot;
                }
                else if (letter == 'c')
                {
                    var newCoin = Instantiate(coinPrefab, new Vector3(column, row, 0f), Quaternion.identity);
                    newCoin.transform.parent = environmentRoot;
                }
                else if (letter == 'w')
                {
                    var newWater = Instantiate(waterPrefab, new Vector3(column, row, 0f), Quaternion.identity);
                    newWater.transform.parent = environmentRoot;
                }
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
