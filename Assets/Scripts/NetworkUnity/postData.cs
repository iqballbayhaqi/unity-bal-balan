using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class postData : MonoBehaviour
{
    string[] parameter;
    public string urlSearch;
    public string userId;
    public string gameId;
    public string url = "http://134.209.107.79/games/api/scoregameapi2.php";
    [SerializeField] bool modeFikri;

    private void Awake()
    {
        URLParameters.Instance.RegisterOnDone((url) => {
            urlSearch = url.Search;
            string parameter = urlSearch.Remove(0, 1);
            string user = parameter.Split('&')[0];
            string game = parameter.Split('&')[1];

            userId = user.Substring(7);
            gameId = game.Substring(8);

            Debug.Log("userID = " + userId);
            Debug.Log("gameID = " + gameId);

        });
    }

    [SerializeField] Transform imageScale;
    [SerializeField] float currentScale = 0;
    private void Update()
    {
        if (modeFikri)
        {
            if (imageScale.localScale.x != currentScale)
            {
                currentScale = imageScale.localScale.x;
                postDataScore(imageScale.localScale.x);
            }
        }
    }
    public void postDataScore(float score)
    {
        string jsonData = @"{'customerid':" + userId + ",'gameid':" + gameId + " ,'score':" + score + "}";
        jsonData = jsonData.Replace("'", "\"");
        StartCoroutine(sendData(url, jsonData));
    }
    public IEnumerator sendData(string url, string logindataJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(logindataJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            Debug.Log("Erro: " + request.error);
        }
        else
        {
            Debug.Log("All OK");
            Debug.Log("Status Code: " + request.responseCode);
        }

    }
}
