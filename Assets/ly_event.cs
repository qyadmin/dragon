using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ly_event : MonoBehaviour {


    [SerializeField]
    Transform loading,lypanle;
    [SerializeField]
    Text waitsecond;

    Timer _timer = new Timer(1);
    [SerializeField]
    HttpModel refrece;
    int time;

    public void Gettime(int value)
    {
        _timer.tickEvnet -= time_event;
        _timer.EndTimer();
        time = value;
        _timer.tickEvnet += time_event;
        _timer.StartTimer();
    }
    void time_event()
    {
        if (time <= 0)
        {
            failure();
            _timer.EndTimer();
        }
        else
        {          
            time--;
        }
    }


    private void Update()
    {
        _timer.UpdateRepeatTimer(Time.deltaTime);
    }

    [SerializeField]
    Sprite suc_spr, fal_spr;
    [SerializeField]
    AudioClip suc_aud, fal_aud;
    [SerializeField]
    Image img;
    [SerializeField]
    AudioSource audio;

    public void successful()
    {
        img.sprite = suc_spr;
        if (Static.Instance.MusicSwich)
        {           
            audio.clip = suc_aud;
        }
        loading.gameObject.SetActive(false);
        lypanle.gameObject.SetActive(true);
        if (Static.Instance.MusicSwich)
            audio.Play();
        stopupdate();
        refrece.Get();
    }

    public void failure()
    {
        img.sprite = fal_spr;
        if (Static.Instance.MusicSwich)
            audio.clip = fal_aud;
        loading.gameObject.SetActive(false);
        lypanle.gameObject.SetActive(true);
        if (Static.Instance.MusicSwich)
            audio.Play();
        stopupdate();
        refrece.Get();
    }

    string cg_flag;

    public void set()
    {
        if (cg_flag == "1")
            successful();
    }


    public void get_cg_flag(object value)
    {
        cg_flag = value.ToString();
    }
    [SerializeField]
    HttpModel lingyang;

    public void startUpdate(object value)
    {
        if (value.ToString() == "1")
        {
            loading.gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(updateHttp());
            Gettime(360);
        }
        else
        {
            ShowOrHit._Instance.Worning.gameObject.SetActive(true);           
        }
       
    }

    IEnumerator updateHttp()
    {
        lingyang.Get();
        yield return new WaitForSeconds(5);
        StartCoroutine(updateHttp());
    }

    public void stopupdate()
    {
        StopAllCoroutines();
        _timer.EndTimer(); 
    }

}
