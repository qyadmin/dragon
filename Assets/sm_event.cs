using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sm_event : MonoBehaviour {

    [SerializeField]
    Transform flag0, flag1, flag2;


    public void get_sm_flag(object value)
    {
        flag0.gameObject.SetActive(false);
        flag1.gameObject.SetActive(false);
        flag2.gameObject.SetActive(false);

        if (value.ToString() == "0")
            flag0.gameObject.SetActive(true);

        if (value.ToString() == "1")
        {
            flag1.gameObject.SetActive(false);

            ShowOrHit._Instance.Worning.gameObject.SetActive(true);
            ShowOrHit._Instance.msg.text = "实名未通过，请重新实名认证";
        }

        if (value.ToString() == "2")
            flag2.gameObject.SetActive(true);


    }
}
