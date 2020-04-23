using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Peixi
{
    public class PrepareStateEvent : MonoBehaviour
    {
        public PlayableDirector director;
        public PlayableAsset[] timeLines;
        public GameObject inquireFrame;

        delegate void EmptyEngine();
        EmptyEngine engine;

        public event Action onRoundStart;
        public event Action onRoundEnd;
        // Start is called before the first frame update
        void Start()
        {
            director = GetComponent<PlayableDirector>();

            onRoundEnd += OnPrepareStateEnd;
            onRoundStart += OnPrepareStateStart;
        }

        // Update is called once per frame
        void Update()
        {
            if (engine != null)
            {
                engine();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                OnTimeOut();
            }
        }

        public void OnBribeButtonPressed()
        {
            print("点击了贿赂按钮");
            if (director.state == PlayState.Paused)
            {
                director.playableAsset = timeLines[1];
                director.Play();
            }
        }

        public void OnDealPlayer1ButtonPressed()
        {
            inquireFrame.SetActive(true);
        }

        /// <summary>
        /// 接收开始准备阶段的消息
        /// </summary>
        public void OnPrepareStateStart()
        {

        }
        /// <summary>
        /// 发出结束准备阶段的消息
        /// </summary>
        public void OnPrepareStateEnd()
        {

        }

        public void OnConfirmBribeButtonPressed()
        {

        }

        public void OnCancelBribeButtonPressed()
        {

        }

        public void OnBribeMessageReceived()
        {

        }

        public void OnRollCardButtonPressed()
        {

        }

        public void OnConfirmRollCardButtonPressed()
        {

        }

        public void OnCancelRollCardButtonPressed()
        {

        }
        /// <summary>
        /// 时间到或者按下结束按钮
        /// </summary>
        public void OnTimeOut()
        {
            //play round end aniamtion
            director.playableAsset = timeLines[0];
            director.time = director.duration;
            engine += PlayStateEndAnim;
        }

        void PlayStateEndAnim()
        {
            director.time -= Time.deltaTime;
            director.Evaluate();
            if (director.time <= 0)
            {
                director.time = 0;
                director.Pause();
                engine -= PlayStateEndAnim;
            }
        }
    }
}