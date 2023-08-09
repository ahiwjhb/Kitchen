using Helper;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using FSM;
using static GameController;

public class GameRemaningTimeUI : UIWindow
{
    [SerializeField] Image timeClockImage;

    private Timer timer;

    protected override void Awake() {
        base.Awake();
        timer = new Timer();
        IStateEvent playingStateEvent = GameController.Instance.FSM.GetStateEvent(GameState.Playing);
        playingStateEvent.OnEnterState += StartCountDownUI;
    }
    private void StartCountDownUI() {
        timeClockImage.fillAmount = 0;
        timer.ReStart(GameController.Instance.PlayGameTimeSecond);
        StartCoroutine(CoutDonwUICoroutine());
    }

    private IEnumerator CoutDonwUICoroutine() {
        while (!timer.IsTimeUp()) {
            timeClockImage.fillAmount = timer.Progress();
            yield return null;
        }
    }
}
