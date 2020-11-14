using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace  ForEach
{
    public class UIProgressBar : MonoBehaviour
    {
        public Image ProgressImage;
        public float progresstimer = 1f;
        public Text PercentText;

        private System.Action OnProgressChange;

        public void Start()
        {
            OnProgressChange = () =>
              {
                  if(PercentText)
                  {
                      PercentText.text = ((int)(ProgressImage.fillAmount*100)).ToString();
                  }
              };

        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                AddProgress(0.5f);
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                AddProgress(-0.3f);
            }
        }

        public void SetProgress(float progressamount)
        {
            ProgressImage.fillAmount = progressamount;
            OnProgressChange?.Invoke();
        }


        public void AddProgress(float progressamount) 
        {
            StartCoroutine(AddProgressIE(progressamount));
        }
        private IEnumerator AddProgressIE(float progressamount)
        {
            for (float i =0; i <progresstimer; i+=0.1f)
            {
                ProgressImage.fillAmount += (progressamount / (progresstimer/0.1f));
                yield return new WaitForSeconds(0.05f);
                OnProgressChange?.Invoke();
            }
            
        }
        public void ChangeFillType(Image.FillMethod fillmethod)
        {
            ProgressImage.fillMethod = fillmethod;
        }
    }
}
