using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class Predict_people : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SendPredictionRequest());
    }

    // �� ��û �ڷ�ƾ
    IEnumerator SendPredictionRequest()
    {
        //���� ��¥, �ð� �޾ƿ��� 
        DateTime now = DateTime.Now;

        PredictRequestData data = new PredictRequestData
        {
            ds = now.ToString("yyyy-MM-dd HH:mm:ss"),
            is_weekend = (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday) ? 1 : 0,
            is_halloween = (now.Month == 10 && now.Day == 31) ? 1 : 0
        };

        //���� üũ 
        int dayOfWeek = ((int)now.DayOfWeek+1);

        if (dayOfWeek == 1) dayOfWeek = 7;
        typeof(PredictRequestData).GetField($"dayofweek_{dayOfWeek}").SetValue(data, 1);

        // ��
        typeof(PredictRequestData).GetField($"month_{now.Month}").SetValue(data, 1);

        // �ð� (1~24 �������� ����)
        int hour = now.Hour + 1;
        typeof(PredictRequestData).GetField($"hour_{hour}").SetValue(data, 1);

        // JSON ��ȯ
        string jsonData = JsonUtility.ToJson(data);
        Debug.Log("���� JSON: " + jsonData);

        // FastAPI POST ��û
        UnityWebRequest www = new UnityWebRequest("http://127.0.0.1:8000/predict", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("���� ���: " + www.downloadHandler.text);
        }

        else
        {
            Debug.LogError("��û ����: " + www.error);
        }

    }
}