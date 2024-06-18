using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class NowTimeCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        //base.Execute(notification);
        Debug.Log("创建倒计时面板");
        GameObject go = GameObjectUtility.Instance.CreateGameObject("_Prefabs/NowTimePanelView");

        Facade.RegisterMediator(new NowTimePanelMediator(go));

        SendNotification(MyFacade.REFRESH_NOWTIME_UI);
    }
}
