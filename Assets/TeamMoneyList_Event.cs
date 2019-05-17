using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.Text.RegularExpressions;

public class TeamMoneyList_Event : MonoBehaviour {

    [SerializeField]
    Transform ListPrefab,Count;


    int OnePageCount = 10;

    int PageNumCount;
    int PageNum;

    [SerializeField]
    Text prompt;

    [SerializeField]
    Button addbutton, ReductionButton;

    List<JsonData> listjson = new List<JsonData>();

    private void Start()
    {
        addbutton.onClick.AddListener(delegate() {
            AddPage();
        });

        ReductionButton.onClick.AddListener(delegate () {
            ReductionPage();
        });
    }

    public void GetJson(JsonData json)
    {
        Debug.Log(JsonMapper.ToJson(json));
        listjson.Clear();

        JsonData data = json["data"];

        for (int i = 0; i < data.Count; i++)
        {
            listjson.Add(data[i]);
        }
        PageNumCount = Mathf.CeilToInt(listjson.Count / OnePageCount);

        Debug.Log(listjson.Count + "   "+ OnePageCount);
        PageNum = 1;
        refresh();
    }

    void refresh()
    {
        Cleangglist();
        if (PageNumCount > PageNum)
            for (int i = (1 + (PageNum - 1) * OnePageCount - 1); i < (1 + (PageNum - 1) * OnePageCount - 1 + 10); i++)
            {
                GameObject newobj = Instantiate(ListPrefab.gameObject);
                newobj.transform.parent = Count;
                newobj.transform.localScale = new Vector3(1, 1, 1);
                newobj.gameObject.SetActive(true);

                newobj.transform.Find("sl").GetComponent<Text>().text = Regex.Unescape(JsonMapper.ToJson(listjson[i]["sl"]).Replace("\"", ""));
                newobj.transform.Find("sj").GetComponent<Text>().text = Regex.Unescape(JsonMapper.ToJson(listjson[i]["sj"]).Replace("\"", ""));
                newobj.transform.Find("ms").GetComponent<Text>().text = Regex.Unescape(JsonMapper.ToJson(listjson[i]["ms"]).Replace("\"", ""));
            }
        if (PageNumCount == PageNum)
        {
            for (int i = (1 + (PageNum - 1) * OnePageCount - 1); i < listjson.Count; i++)
            {
                GameObject newobj = Instantiate(ListPrefab.gameObject);
                newobj.transform.parent = Count;
                newobj.transform.localScale = new Vector3(1, 1, 1);
                newobj.gameObject.SetActive(true);

                newobj.transform.Find("sl").GetComponent<Text>().text = Regex.Unescape(JsonMapper.ToJson(listjson[i]["sl"]).Replace("\"", ""));
                newobj.transform.Find("sj").GetComponent<Text>().text = Regex.Unescape(JsonMapper.ToJson(listjson[i]["sj"]).Replace("\"", ""));
                newobj.transform.Find("ms").GetComponent<Text>().text = Regex.Unescape(JsonMapper.ToJson(listjson[i]["ms"]).Replace("\"", ""));
            }
        }
        prompt.text = string.Format("{0}/{1}",PageNum,PageNumCount);
    }


    public void AddPage()
    {
        if (PageNum < PageNumCount)
        {
            PageNum++;
            refresh();
        }      
    }

    public void ReductionPage()
    {
        if (PageNum >1)
        {
            PageNum--;
            refresh();
        }
    }

    public void Cleangglist()
    {
        for (int i = 0; i < Count.childCount; i++)
        {
            Destroy(Count.GetChild(i).gameObject);
        }
    }
}
