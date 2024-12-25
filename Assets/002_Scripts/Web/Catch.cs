using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Catch : MonoBehaviour
{
   

    public Text ResultText_;    //���ʂ��i�[����e�L�X�g
    public InputField InputText_;     //id����͂���C���v�b�g�t�B�[���h
    

    public string ServerAddress = "localhost/selecttest.php";  //selecttest.php���w��@����̃A�h���X��localhost

    //SendSignal�{�^�������������Ɏ��s����郁�\�b�h
    public void SendSignal_Button_Push() {
        StartCoroutine(Access());   //Access�R���[�`���̊J�n
    }

    private IEnumerator Access() {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        dic.Add("id", InputText_.text);  //�C���v�b�g�t�B�[���h����id�̎擾);
        //����php�ɑ��M�������f�[�^������ꍇ�͍���̏ꍇdic.Add("hoge", value)�̂悤�ɑ����Ă����΂悢
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
        UnityWebRequest www = UnityWebRequest.Post(url, form);//�ύX�_�@Unity webRequest �ɕύX
        www.certificateHandler = new SSL();//�ύX�_

        var requestOperetion = www.SendWebRequest();//�ύX�_�@


        yield return CheckTimeOut(requestOperetion, 3f); //TimeOutSecond = 3s;

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log("HttpPost NG: " + www.error);
            //���������ڑ����ł��Ă��Ȃ��Ƃ�

        } else if (www.isDone) {
            //�����Ă����f�[�^���e�L�X�g�ɔ��f
            ResultText_.text = www.downloadHandler.text;

        }
    }

    private IEnumerator CheckTimeOut(UnityWebRequestAsyncOperation www, float timeout) {//�ύX�_�@UnityWebRequestAsyncOperation
        float requestTime = Time.time;

        while (!www.isDone) {
            if (Time.time - requestTime < timeout)
                yield return null;
            else {
                Debug.Log("TimeOut");  //�^�C���A�E�g
                //�^�C���A�E�g����
                //
                //
                break;
            }
        }
        yield return null;
    }
}



