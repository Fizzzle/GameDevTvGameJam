using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // синглтон
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _inGameSounds;

    // Звук победы
    private AudioClip _victorySound => _inGameSounds[0];

    // Звук проиграша
    private AudioClip _loseSound => _inGameSounds[1];

    // Звук поворота блока (убрать если не нужно)
    private AudioClip _turnBlock => _inGameSounds[2];

    // Звук переключения иллюзии (убрать если не нужно)
    private AudioClip _illusionSwitch => _inGameSounds[3];


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // функция для звука победы
    public void PlayVictorySound()
    {
        _audioSource.PlayOneShot(_victorySound);
    }

    // функция для звука проигрша (смерти)
    public void PlayLoseSound()
    {
        _audioSource.PlayOneShot(_loseSound);
    }

    public void PlayTurnBlockSound()
    {
        _audioSource.PlayOneShot(_turnBlock);
    }

    public void PlayIllusionSwitchSound()
    {
        _audioSource.PlayOneShot(_illusionSwitch);
    }
}
