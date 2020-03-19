using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class SaveLoadSystem : MonoBehaviour
{
    //Done
    private Config conf = new Config();
    private string path;
    public int[] coins;
    public GameObject[] coinsObj;
    public int Score;
    public Text ScoreText;
    void Awake()
    {
        //инициализируем путь к файлу сохранения
        path = Path.Combine(Application.dataPath, "Config.json");
        //проверяем наличие файла созранения
        ControlIni();
        //файл сохранения переводим в структуру данных
        conf = JsonUtility.FromJson<Config>(File.ReadAllText(path));
    }
    void Start()
    {
        Load();
    }
    void ControlIni()
    {
        if (!File.Exists(path))
            Defaults();           
    }
    void Defaults()
    {
        conf.Score = 0;
        for (int i = 0; i < coins.Length; i++) conf.coins[i] = 1;
        File.WriteAllText(path, JsonUtility.ToJson(conf));        
    }
    void Update()
    {
        ScoreText.text = "Score: " + Score;
    }
    //сохраняем
    public void Save()
    {
        int count = -1;
        foreach(GameObject coinObj in coinsObj)
        {
            count++;
            if (coinObj.activeInHierarchy) coins[count] = 1;
            else                           coins[count] = 0;          
        }
        conf.coins = coins;
        conf.Score = Score;
        File.WriteAllText(path, JsonUtility.ToJson(conf));
    }
    //загружаем
    public void Load()
    {
        conf = JsonUtility.FromJson<Config>(File.ReadAllText(path));
        int count = -1;
        foreach (int coin in conf.coins)
        {
            count++;
            if (coin == 0) coinsObj[count].SetActive(false); 
            else           coinsObj[count].SetActive(true);
        }
        Score = conf.Score;
    }
    //класс сохранения
    public class Config
    {
        public int[] coins;
        public int Score;
    }
}
