using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DatabaseController
{
    public static void saveHighScore(Score score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/score.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        Score data = new Score();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Score loadHighScore()
    {
        string path = Application.dataPath + "/score.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Score data = formatter.Deserialize(stream) as Score;
            stream.Close();
            return data;
        }
        return new Score();
    }
}
