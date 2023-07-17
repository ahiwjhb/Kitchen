using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hepler
{ 
    public class TreadHelper : MonoSingleton<TreadHelper>
    {

        private LinkedList<ActionInfor> actionInfors;

        protected override void Awake()
        {
            base.Awake();
            actionInfors = new LinkedList<ActionInfor>();
        }

        public void Update()
        {
            for (LinkedListNode<ActionInfor> node = actionInfors.First; node != null;)
            {
                if (node.Value.executeTime >= DateTime.Now)
                {
                    node = node.Next;
                }
                else
                {
                    node.Value.action();
                    var temp = node;
                    node = node.Next;
                    actionInfors.Remove(temp);
                }
            }
        }

        public void ExecuteInMainThread(Action action, float delayTime = 0)
        {
            DateTime executeTime = DateTime.Now.AddSeconds(delayTime);
            ActionInfor actionInfor = new ActionInfor(action, executeTime);
            lock (actionInfors)
            {
                actionInfors.AddFirst(actionInfor);
            }
        }

        private class ActionInfor
        {
            public Action action;

            public DateTime executeTime;
            public ActionInfor(Action action, DateTime executeTime)
            {
                this.action = action;
                this.executeTime = executeTime;
            }
        }
    }
}
