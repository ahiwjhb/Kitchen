using FSM;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using static GameController;

public class GameWaitingUI : UIWindow
{
    [SerializeField] TMP_Text timerNumberText;

    protected override void Awake() {
        base.Awake();

        IStateEvent waitStateEvent = GameController.Instance.FSM.GetStateEvent(GameState.Wait);
        waitStateEvent.OnEnterState += () =>SetVisible(true);
        waitStateEvent.OnEnterState += StartCountDownUI;

        IStateEvent playingStateEvent = GameController.Instance.FSM.GetStateEvent(GameState.Playing);
        playingStateEvent.OnEnterState += () => SetVisible(false);
    }

    private void StartCountDownUI() {
        float time = GameController.Instance.PlayGameWaitTimeSecond;
        int timerNumber = (int)MathF.Ceiling(time);
        timerNumberText.text = timerNumber.ToString();
        StartCoroutine(CountDownCoroutinue(timerNumber));
    }

    private IEnumerator CountDownCoroutinue(int timerNumber) {
        WaitForSeconds waitOneSecond = new WaitForSeconds(1);
        while(timerNumber > 0) {
            yield return waitOneSecond;
            StartCoroutine(RotateUI(--timerNumber));
        }
    }

    private IEnumerator RotateUI(int timerNumber) {
        float roateTime = 0.5f;
        int clockwise = 1, anticlockwise = -1;
        yield return RotateTimerNumberQuarterTurn(roateTime / 2, anticlockwise);
        timerNumberText.text = timerNumber.ToString();
        yield return RotateTimerNumberQuarterTurn(roateTime / 2, clockwise);
    }

    private IEnumerator RotateTimerNumberQuarterTurn(float rotateTime, int vector) {
        float quarterAngle = 90;
        for (float t = rotateTime; t >= 0; t -= Time.deltaTime) {
            float rotateAngleOnY = quarterAngle / rotateTime * Time.deltaTime * vector;
            timerNumberText.transform.eulerAngles += new Vector3(0, rotateAngleOnY, 0);
            yield return null;
        }
    }
}
