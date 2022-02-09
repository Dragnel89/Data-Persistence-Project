using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class NameAndScore : MonoBehaviour
{
    public Text highScoreText;
    public InputField nameInput;
    public string userName;

    public int highScore;
    public string highScoreUser;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadHighScore();

        highScoreText.text = "High Score : " + highScoreUser + " : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateUserName()
    {
        userName = nameInput.text;
    }
    [System.Serializable]
    class SaveData
    {
        public string highScoreUser;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScoreUser = highScoreUser;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscoresavefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscoresavefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreUser = data.highScoreUser;
        }
    }
}
