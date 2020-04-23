using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
namespace Peixi
{
    public class Timer : MonoBehaviour
    {
        Text timerNumber;
        Button button;
        Animation anim;
        public int duration = 60;
        int time;
        public PlayableDirector directer;
        // Start is called before the first frame update
        void Start()
        {
            timerNumber = GetComponentInChildren<Text>();
            button = GetComponent<Button>();
            anim = GetComponent<Animation>();

            ResetTimer();
            PrepareStateEvent prepare = FindObjectOfType<PrepareStateEvent>();
            prepare.onRoundStart += ResetTimer;
        }
        void ResetTimer()
        {
            time = duration;
            button.interactable = true;
            StartCoroutine(TimeCountDown());
        }
        public void OnbuttonPressed()
        {
            print("click timer button");
            anim.Play();
            button.interactable = false;
            timerNumber.text = "00";
            FindObjectOfType<PrepareStateEvent>().OnTimeOut();
        }
        IEnumerator TimeCountDown()
        {
            timerNumber.text = time.ToString();
            yield return new WaitForSeconds(1);
            time -= 1;
            if (time <= 0)
            {
                OnbuttonPressed();
            }
            else
            {
                StartCoroutine(TimeCountDown());
            }
        }
    }
}