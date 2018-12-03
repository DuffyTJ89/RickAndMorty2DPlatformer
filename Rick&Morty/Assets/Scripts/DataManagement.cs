using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManagement : MonoBehaviour {

    public static DataManagement dataManagement;

    public int highScore;

    void Awake()
    {
        if (dataManagement == null) //set this object for use across all scenes 
        {
            DontDestroyOnLoad(gameObject);
            dataManagement = this;
        }
        else if (dataManagement != this) //if there is a dataManagement present in the scene destroy it
        {
            Destroy(gameObject);
        }
    }

    public void saveData()
    {
        BinaryFormatter BinForm = new BinaryFormatter(); //creates a bonary formatter
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); //creates file
        gameData data = new gameData(); //creates container for data
        data.highscore = highScore;
        BinForm.Serialize(file, data);  
        file.Close();
    }

    public void loadData()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat")) //dont load if there has been nothing saved
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file); //decripts the binary
            file.Close();
            highScore = data.highscore;
        }
    }
}

[Serializable] //storing the state
class gameData
{
    public int highscore;
}
