using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System;

public class NowTimeDataProxy : PureMVC.Patterns.Proxy
{
    public new static string NAME = "NowTimeProxy";

    public NowTimeDataModel nowTimeDataModel;


    public NowTimeDataProxy(string name)
         : base(name, null)
    {
        nowTimeDataModel = new NowTimeDataModel();
    }
    public void GetNowTime()
    {
        nowTimeDataModel.shi= DateTime.Now.Hour;
        nowTimeDataModel.fen= DateTime.Now.Minute;
        nowTimeDataModel.miao= DateTime.Now.Second;
        //发送消息 更新MainPanelView UI组件 通知订阅者
        SendNotification(MyFacade.UPDATE_NOWTIME_DATA);
    }

    public override void OnRegister()
    {
        Debug.Log("PlayerDataProxy OnRegister");
    }

    /// <summary>
    /// Called by the Model when the Proxy is removed
    /// </summary>
    public override void OnRemove()
    {
        Debug.Log("PlayerDataProxy OnRemove");
    }
}
