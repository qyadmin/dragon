using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class my_event : MonoBehaviour {

    [SerializeField]
    Text ly_tital, zr_tital;


    [SerializeField]
    string ly_name,zr_name;

    public void Get_ly_num(object value)
    {
        if (int.Parse(value.ToString()) > 0)
        {
            ly_tital.text = string.Format("{0}<color=#F81616FF>({1})</color>", ly_name, value.ToString());
        }
        if (int.Parse(value.ToString()) == 0)
        {
            ly_tital.text = string.Format("{0}", ly_name);
        }
    }

    public void Get_zr_num(object value)
    {
        if (int.Parse(value.ToString()) > 0)
        {
            zr_tital.text = string.Format("{0}<color=#F81616FF>({1})</color>", zr_name, value.ToString());
        }
        if (int.Parse(value.ToString()) == 0)
        {
            zr_tital.text = string.Format("{0}", zr_name);
        }
    }

}
