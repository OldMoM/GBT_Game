using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Peixi;

[CustomEditor(typeof(ControlConsole))]
public class ControlConsoleEditor : Editor
{
    ControlConsole control;
    bool test;
    private void OnEnable()
    {
        control = (ControlConsole)target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("在线玩家向发送悄悄话"))
        {
            PrepareStateEvent prepare = FindObjectOfType<PrepareStateEvent>();
            prepare.OnBribeMessageReceived();
        }
        if (GUILayout.Button("收到同意消息"))
        {
           
        }
        if (GUILayout.Button("收到拒绝消息"))
        {

        }
    }
}
