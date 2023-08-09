using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameController;

public class GameOverUI : UIWindow
{
    private Animator gameoverUIAnimator;

    protected override void Awake() {
        base.Awake();
        gameoverUIAnimator = GetComponent<Animator>();
    }

    public void Start() {
        GameController.Instance.FSM.GetStateEvent(GameState.Over).OnEnterState += PlayGameOverAnimation;
    }

    private void PlayGameOverAnimation() {
        gameoverUIAnimator.enabled = true;
    }
}
