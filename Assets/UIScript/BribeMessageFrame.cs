using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peixi
{
    public class BribeMessageFrame : MonoBehaviour
    {
        PrepareStateEvent prepareState;
        Animation anim;
        
        private void Start()
        {
            prepareState = FindObjectOfType<PrepareStateEvent>();
            anim = GetComponent<Animation>();
            prepareState.bribeMessageReceived += OnBribeMessageReceived;
            prepareState.approveBribe += OnApproveButtonPressed;
            prepareState.rejectBribe += OnApproveButtonPressed;
        }

        void OnBribeMessageReceived()
        {
            anim.Play();
            print("弹出悄悄话信息框");
        }

        public void OnApproveButtonPressed()
        {
            print("approve bribe button pressed");
            anim.Rewind("RiseBribeMessage");
        }
        
        public void OnRejectButtonPressed()
        {
            print("reject bribe button pressed");
            anim.Rewind();
        }
    }
}


