using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System;
using PureMVC.Core;
using UnityEngine.UI;

public class NowTimePanelMediator : PureMVC.Patterns.Mediator
{
   
    public new const string NAME = "NowTimePanelMediator";

    private NowTimePanelView view;

    NowTimeDataProxy nowTimeProxy;

    public NowTimePanelMediator(object viewComponent) : base(NAME,viewComponent)
    {
        view = ((GameObject)viewComponent).GetComponent<NowTimePanelView>();

        nowTimeProxy = Facade.RetrieveProxy(NowTimeDataProxy.NAME) as NowTimeDataProxy;

        view.RefreshBut.onClick.AddListener(OnClick);

    }

    private void OnClick()
    {
        //Debug.Log("µã»÷Ë¢ÐÂ");
        nowTimeProxy.GetNowTime();
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case MyFacade.REFRESH_NOWTIME_UI:
                Debug.Log("REFRESH_NOWTIME_UI");
                if (!view.isActiveAndEnabled)
                {
                    view.gameObject.SetActive(true);
                }
                break;
            case MyFacade.UPDATE_NOWTIME_DATA:
                {
                   string str = $"{nowTimeProxy.nowTimeDataModel.shi}:{nowTimeProxy.nowTimeDataModel.fen}:{nowTimeProxy.nowTimeDataModel.miao}";
                   view.Timetext.text = str;//string.Format("{0}{1}{2}", nowTimeProxy.nowTimeDataModel.shi, nowTimeProxy.nowTimeDataModel.fen, nowTimeProxy.nowTimeDataModel.miao);
                }
                break;
        }
        ;
    }
    public override void OnRegister()
    {
        base.OnRegister();

    }
    public override void OnRemove()
    {
        base.OnRemove();

    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>()
            {
                MyFacade.REFRESH_NOWTIME_UI,
                MyFacade.UPDATE_NOWTIME_DATA,
            };

        return list;
    }

}
