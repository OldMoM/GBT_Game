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
        public GameObject inquireBribeFrame;
        public GameObject dealOnlinePlayer1Button;
        public GameObject dealOnlinePlayer2Button;
        public GameObject bribeButton;

        delegate void EmptyEngine();
        EmptyEngine engine;
        public GameObject inquireRollCardFrame;
        public GameObject rollCardButton;
        public GameObject confirmRollCardButton;
        public GameObject cancelRollCardButton;

        public event Action onRoundStart;
        public event Action onRoundEnd;
        public event Action onRollCard;
        public event Action rejectBribe;
        public event Action approveBribe;
        public event Action bribeMessageReceived;
        public event Action bribeMessageSent;
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

        #region//Bribe
        public void OnBribeButtonPressed()
        {
            print("点击了贿赂按钮");
            //if (director.state == PlayState.Paused)
            //{
            //    director.playableAsset = timeLines[1];
            //    director.Play();
            //}
            dealOnlinePlayer1Button.SetActive(true);
            bribeButton.SetActive(false);
            
        }

        public void OnDealPlayer1ButtonPressed()
        {
            inquireBribeFrame.SetActive(true);
            dealOnlinePlayer1Button.SetActive(false);
        }

        public void OnDealPlayer2ButtonPressed()
        {

        }

        public void OnConfirmBribeButtonPressed()
        {
            print("confirm bribe button press");
            inquireBribeFrame.SetActive(false);
            bribeButton.SetActive(true);
        }

        public void OnCancelBribeButtonPressed()
        {
            print("cancel bribe button press");
            inquireBribeFrame.SetActive(false);
            bribeButton.SetActive(true);
        }

        /// <summary>
        /// 外界向本地玩家发送BribeMessage时使用此方法
        /// </summary>
        public void OnBribeMessageReceived()
        {
            if (bribeMessageReceived != null)
            {
                bribeMessageReceived.Invoke();
            }
            print("收到其他玩家的悄悄话");
        }

        public void AgreeBribeButtonPressed()
        {

        }

        public void DisagreeBribeButtonPressed()
        {

        }

        public void OnBribeRequsetRejected()
        {

        }
        
        public void OnBribeRequestApproved()
        {

        }
        #endregion

        #region//RollCard
        public void OnRollCardButtonPressed()
        {
            print("press roll card button");
            rollCardButton.SetActive(false);
            inquireRollCardFrame.SetActive(true);
        }

        public void OnConfirmRollCardButtonPressed()
        {
            print("confirm roll card");
            rollCardButton.SetActive(true);
            inquireRollCardFrame.SetActive(false);
        }

        public void OnCancelRollCardButtonPressed()
        {
            print("cancel roll card");
            rollCardButton.SetActive(true);
            inquireRollCardFrame.SetActive(false);
        }
        #endregion

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