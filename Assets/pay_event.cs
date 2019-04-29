using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class pay_event : MonoBehaviour {
    [SerializeField]
    Sprite wx, zfb,yhk;
    [SerializeField]
    Image pic;
    public void getpay(string value)
    {
        switch (value)
        {
            case "微信":
                pic.sprite = wx;
                break;
            case "支付宝":
                pic.sprite = zfb;
                break;
            default:
                pic.sprite = yhk;
                if(transform.parent.Find("Image"))
                transform.parent.Find("Image").gameObject.SetActive(false) ;
                break;
        }
    }
    [SerializeField]
    UnityEvent suc, fal;
    public void LoadImage(string obj)
    {
        if (obj != null)
        {
            IEnumerator loadimage = loadtexture(obj);
            StartCoroutine(loadimage);
        }

    }

    IEnumerator loadtexture(string obj)
    {
        Debug.Log(obj);

        //foreach (Image i in sprit)
        //    i.sprite = default_image;

        WWW www = new WWW(obj);
        yield return www;
        if (www.error != null)
        {
            Debug.Log(www.error);
            fal.Invoke();
        }
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            Debug.Log(1231231);
            Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
            pic.sprite = sprite;
            suc.Invoke();
        }
    }
}
