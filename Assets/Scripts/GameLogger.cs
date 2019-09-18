using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class GameLogger
{
    public static string levelName = "Test Level";
    public static string gameTime = "00:00";
    public static int numSmallBoardsPlaced = 0;
    public static int numMedBoardsPlaced = 0;
    public static int numLargeBoardsPlaced = 0;
    //public static int numRegBoardsPlaced = 0;
    private static string fileToWriteTo;

    public static void SetupFiles()
    {
        int count = 0;
        if (!Directory.Exists("Game Logs"))
        {
            Debug.Log("Game Logs directory does not exist! Creating now...");
            Directory.CreateDirectory("Game Logs");
        }

        string fileName = "Game Logs/Log";
        string tempFileName = fileName;
        /*
        if (File.Exists(filePath))
        {
            
            Debug.Log("File doesnt exist! Creating now...");
            File.CreateText(filePath);
        }*/

        Find:
        if (File.Exists(fileName + ".txt"))
        {
            fileName = tempFileName + "(" + count.ToString() + ")";
            count++;
            goto Find;
        }
        else
        {
            File.Create(fileName + ".txt").Dispose();
            fileToWriteTo = fileName + ".txt";
        }
        
    }

    public static void LogData()
    {
        StreamWriter writer = new StreamWriter(fileToWriteTo, true);

        writer.WriteLine("Level Name: " + levelName);
        writer.WriteLine("Game Time: " + gameTime);
        writer.WriteLine("Number of Small Boards Placed: " + numSmallBoardsPlaced);
        writer.WriteLine("Number of Medium Boards Placed: " + numMedBoardsPlaced);
        writer.WriteLine("Number of Large Boards Placed: " + numLargeBoardsPlaced);
        //writer.WriteLine("Number of Regular Boards Placed: " + numRegBoardsPlaced);
        writer.WriteLine("");
        writer.Close();
    }
}
