using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using XLua;

public class MessagePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public static void ShowAlertPanel(string message, string title, Action onFinished = null)
    {
        Debug.Log("显示提示弹框");
        var rootPanel = GameObject.Find("Panel").transform;
        var alertPanel = rootPanel.Find("AlertPanel");
        Debug.Log("11111");
        if (alertPanel == null)
        {
            alertPanel = (Instantiate(Resources.Load("AlertPanel")) as GameObject).transform;
            alertPanel.gameObject.name = "AlertPanel";
            alertPanel.SetParent(rootPanel);
            alertPanel.localPosition = Vector3.zero;
            alertPanel.localScale = Vector3.one;
        }
        Debug.Log("22222");
        alertPanel.Find("Title").GetComponent<Text>().text = title;
        alertPanel.Find("Content").GetComponent<Text>().text = message;

        var button = alertPanel.Find("BtnBuy").GetComponent<Button>();
        UnityAction onclick = () =>
        {
            if (onFinished != null)
            {
                onFinished();
            }
            button.onClick.RemoveAllListeners();
            alertPanel.gameObject.SetActive(false);
        };
        //防止消息框未关闭时多次被调用
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(onclick);
        alertPanel.gameObject.SetActive(true);
    }

    public static void ShowConfirmPanel(string message, string title, Action<bool> onFinished = null)
    {
        Debug.Log("00000");
        var rootPanel = GameObject.Find("Panel").transform;
        var confirmPanel = rootPanel.Find("ConfirmPannel");
        if (confirmPanel == null)
        {
            confirmPanel = (Instantiate(Resources.Load("ConfirmPannel")) as GameObject).transform;
            confirmPanel.gameObject.name = "ConfirmPannel";
            confirmPanel.SetParent(rootPanel);
            confirmPanel.localPosition = Vector3.zero;
            confirmPanel.localScale = Vector3.one;
        }
        confirmPanel.Find("Title").GetComponent<Text>().text = title;
        confirmPanel.Find("Content").GetComponent<Text>().text = message;
        confirmPanel.gameObject.SetActive(true);
        Debug.Log("ShowConfirmPanel");
        if (onFinished != null)
        {
            var confirmBtn = confirmPanel.Find("BtnBuy").GetComponent<Button>();
            var cancelBtn = confirmPanel.Find("CancelBuy").GetComponent<Button>();
 
            Action cleanup = () =>
            {
                confirmBtn.onClick.RemoveAllListeners();
                cancelBtn.onClick.RemoveAllListeners();
                confirmPanel.gameObject.SetActive(false);
            };

            UnityAction onconfirm = () =>
            {
                if (onFinished != null)
                {
                    onFinished(true);
                }
                cleanup();
            };

            UnityAction oncancel = () =>
            {
                if (onFinished != null)
                {
                    onFinished(false);
                }
                cleanup();
            };

            //防止消息框未关闭时多次被调用
            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(onconfirm);
            cancelBtn.onClick.RemoveAllListeners();
            cancelBtn.onClick.AddListener(oncancel);
            confirmPanel.gameObject.SetActive(true);
        }

    }

    public static class MessagePanelConfig
    {
        [CSharpCallLua]
        public static List<Type> CSharpCallLua = new List<Type>()
        {
            typeof(Action),
            typeof(Action<bool>),
            typeof(UnityAction),
        };
    }
}
