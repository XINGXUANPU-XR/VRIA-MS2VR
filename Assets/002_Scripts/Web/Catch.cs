using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Catch : MonoBehaviour
{
   

    public Text ResultText_;    //結果を格納するテキスト
    public InputField InputText_;     //idを入力するインプットフィールド
    

    public string ServerAddress = "localhost/selecttest.php";  //selecttest.phpを指定　今回のアドレスはlocalhost

    //SendSignalボタンを押した時に実行されるメソッド
    public void SendSignal_Button_Push() {
        StartCoroutine(Access());   //Accessコルーチンの開始
    }

    private IEnumerator Access() {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        dic.Add("id", InputText_.text);  //インプットフィールドからidの取得);
        //複数phpに送信したいデータがある場合は今回の場合dic.Add("hoge", value)のように足していけばよい
        //Debug.Log(dic.Keys );
        //Debug.Log(dic.Values);

        //foreach(string value in dic.Values){
        //    Debug.Log(value);
        //} foreach(string value in dic.Keys){
        //    Debug.Log(value);
        //}

        StartCoroutine(Post(ServerAddress, dic));  // POST
        
        yield return null;
    }

    private IEnumerator Post(string url, Dictionary<string, string> post) {

        WWWForm form = new WWWForm();

        foreach (KeyValuePair<string, string> post_arg in post) {
            form.AddField(post_arg.Key, post_arg.Value);

            //Debug.Log(form);
        }

        //WWW www = new WWW(url, form);
        UnityWebRequest www = UnityWebRequest.Post(url, form);//変更点　Unity webRequest に変更
        www.certificateHandler = new SSL();//変更点

        var requestOperetion = www.SendWebRequest();//変更点　


        yield return CheckTimeOut(requestOperetion, 3f); //TimeOutSecond = 3s;

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log("HttpPost NG: " + www.error);
            //そもそも接続ができていないとき

        } else if (www.isDone) {
            //送られてきたデータをテキストに反映
            ResultText_.text = www.downloadHandler.text;

        }
    }

    private IEnumerator CheckTimeOut(UnityWebRequestAsyncOperation www, float timeout) {//変更点　UnityWebRequestAsyncOperation
        float requestTime = Time.time;

        while (!www.isDone) {
            if (Time.time - requestTime < timeout)
                yield return null;
            else {
                Debug.Log("TimeOut");  //タイムアウト
                //タイムアウト処理
                //
                //
                break;
            }
        }
        yield return null;
    }
}



