using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    ///  Audioタグがついたオブジェクトを格納する
    /// </summary>
    private GameObject[] audioobj = null;


    void Start()
    {
        //VolumeSetting();
        if(!this.transform.CompareTag("MainCamera"))
            this.transform.gameObject.SetActive(false);
    }

    /// <summary>
    /// スライダーの値が変化した際に呼び出される
    /// </summary>
    public void ChangeVolume()
    {
        GetSliderValue();
        VolumeSetting();
    }

    /// <summary>
    /// スライダーの値を取得
    /// </summary>
    private void GetSliderValue()
    {
        AudioSetting.masterVolume = this.transform.GetComponent<Slider>().value;
    }

    /// <summary>
    /// GetSliderValueで取得した値を各AudioSourceに代入する
    /// </summary>
    private void VolumeSetting()
    {

        audioobj = GameObject.FindGameObjectsWithTag("Audio");
        Debug.Log(audioobj);
        if (audioobj != null)
            for (int num = 0; num < audioobj.Length; num++)
            {
                Debug.Log(audioobj[num]);
                audioobj[num].transform.gameObject.GetComponent<AudioSource>().volume = AudioSetting.masterVolume;
            }
    }
}
