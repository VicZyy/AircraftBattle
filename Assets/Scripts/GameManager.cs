using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Canvas _runCanvas;
    public Canvas _gameOverCanvas;

    public Text _textScore;
    public Text _textBest;
    public Text _textLife;

    private int _score = 0;
    private Player _player;
    private int _bestScore = 0;

    private AudioSource _audioSource;
    public AudioClip _musicClip;

    public Button _btnRestart;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        //设置音乐
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _musicClip;
        _audioSource.loop = true;
        _audioSource.Play();

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _textBest.text = 0.ToString();
        _textLife.text = _player.Life.ToString();
        _textScore.text = 0.ToString();
        
        _btnRestart.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int point)
    {
        _score+=point;
        if(_bestScore<_score)
        {
            _bestScore=_score;
        }
        _textBest.text=_bestScore.ToString();
        _textScore.text=_score.ToString();
    }

    public void ChangeLife(int damage)
    {
        _player.Life-=damage;
        _textLife.text=_player.Life.ToString();
        if(_player.Life<=0)
        {
            _gameOverCanvas.gameObject.SetActive(true);
        }
    }
}
