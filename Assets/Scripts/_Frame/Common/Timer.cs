using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Helper
{
    public struct Timer
    {
        private float targetTime;

        private float startTime;

        private bool isUseScaleime;

        //计时器是否完成计时：默认为true
        public bool IsTimeUp()
        {
            return CurrentTime() >= targetTime;
        }

        /// <summary>
        /// 重新计时
        /// </summary>
        /// <param name="time">时间长度</param>
        /// <param name="useScaleime">是否使用缩放时间</param>
        public void ReStart(float time, bool useScaleime = true)
        {
            isUseScaleime = useScaleime;
            startTime = CurrentTime();
            targetTime = startTime + time;
        }

        //返回计时器当前的进度
        public float Progress()
        {
            float t1 = CurrentTime() - startTime;
            float t2 = targetTime - startTime;
            return Mathf.Clamp(t1 / t2, 0f, 1.0f);
        }

        private float CurrentTime()
        {
            return isUseScaleime ? Time.time : Time.unscaledTime;
        }
    }
}
