using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        Before,
        Play,
        Finish,
        None = -1
    }

    public event Action<GameState> OnGameStateChange;
    public event Action<int> OnScoreChange;

    [SerializeField]
    private int badCountAuthorized = 20;
    private int badCount = 0;

    private int score = 0;

    public Character character;

    private GameState state = GameState.None;

    public int Score
    {
        get { return score; }
        private set
        {
            if (score != value)
                return;
            score = value;
            OnScoreChange.Invoke(score);
        }
    }

    public float OrgasmJauge
    {
        get { return BrushRythmManager.Instance.PercentRythmCompleted; }
    }

    public float FrustrationJauge
    {
        get { return badCount / badCountAuthorized; }
    }

    public GameState State
    {
        get
        {
            return state;
        }
        set
        {
            if (state != value)
                return;

            state = value;
            OnGameStateChange.Invoke(state);
        }
    }

    public override void Awake()
    {
        base.Awake();
        character = Instantiate(CharacterDataKeeper.Instance.characterPrefab);
        BrushRythmManager.Instance.OnBrushCompleted += this.Instance_OnBrushCompleted;
    }

    public void Start()
    {
        State = GameState.Before;
        Invoke("StartGame", 3.0f);
    }

    public void OnDestroy()
    {
        BrushRythmManager.Instance.OnBrushCompleted -= this.Instance_OnBrushCompleted;
    }

    private void StartGame()
    {
        State = GameState.Play;
    }

    private void Instance_OnBrushCompleted(BrushRythm rythm, AraToothbrushZone zone, Accuracy accuracy)
    {
        switch (accuracy)
        {
            case Accuracy.None:
                break;
            case Accuracy.Bad:
                ++badCount;
                if (badCount == badCountAuthorized)
                    State = GameState.Finish;
                break;
            case Accuracy.Good:
                Score = Score +1;
                break;
            case Accuracy.Perfect:
                Score = Score + 2;
                break;
            case Accuracy.Completed:
                break;
        }
    }

    public void OnEnable()
    {
        OnGameStateChange += this.GameManager_OnGameStateChange;
    }

    public void OnDisable()
    {
        OnGameStateChange -= this.GameManager_OnGameStateChange;
    }

    private void GameManager_OnGameStateChange(GameState state)
    {
        if (!state.Equals(GameState.Play))
        {
            BrushRythmManager.Instance.enabled = false;
        }
        else
        {
            BrushRythmManager.Instance.enabled = true;
        }
    }
}
