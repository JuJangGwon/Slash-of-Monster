using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    private static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    public void LoadData(string kyestring)
    {

    }
    public void SaveData(string kyestring,int intdata)
    {

    }
}