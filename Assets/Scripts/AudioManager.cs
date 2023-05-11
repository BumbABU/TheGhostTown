using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : BaseManager<AudioManager> 
{
    private const string BGM_VOLUME_KEY = "BGM_VOLUME_KEY";
    private const string SE_VOLUME_KEY = "SE_VOLUME_KEY";
    private const float BGM_VOLUME_DEFAULT = 0.2f;
    private const float SE_VOLUME_DEFAULT = 1.0f;

    public const float BGM_FADE_SPEED_RATE_HIGH = 0.9f;
    public const float BGM_FADE_SPEED_RATE_LOW = 0.3F;
    private float bgmFadeSpeedRate = BGM_FADE_SPEED_RATE_HIGH;

    private string nextBGMName;
    private string nextSEName; //Sound Ecfact

    private bool isFadeout = false;

    public AudioSource AttachBGMSource;
    public AudioSource AttachSESource;

    private Dictionary<string, AudioClip> bgmDic, seDic;

    protected override void Awake()
    {
        base.Awake();

        bgmDic = new Dictionary<string, AudioClip>();
        seDic = new Dictionary<string, AudioClip>();
        //Resources.load all Resources.LoadAll là một phương thức của lớp Resources trong Unity
        //được sử dụng để tải tất cả các tài nguyên trong thư mục được chỉ định và các thư mục con của nó vào một mảng.
        object[] bgmList = Resources.LoadAll("Audio/BGM"); // nếu chọn hàm Load nó chỉ load 1 file ví dụ file text file ảnh hay audio, còn nếu chon Loadout sẽ Load hết cái file BGm trong audio
        object[] seList = Resources.LoadAll("Audio/SE"); // những file load đc , filetext, jsontextfile, sprite, audioclip, texture

        foreach (AudioClip bgm in bgmList)
        {
            bgmDic[bgm.name] = bgm; // duyệt qua từng phần tử bgmList với key là tên của bgm (bgm.name)
        }                           // và value là chính nó ( là bgm)

        foreach (AudioClip se in seList)
        {
            seDic[se.name] = se;

        }
    }

    private void Start()
    {
        AttachBGMSource.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, BGM_VOLUME_DEFAULT); // hàm này ta vừa set và get luôn , ở đây ta set 1 key có giá trị là volume default
        AttachSESource.volume = PlayerPrefs.GetFloat(SE_VOLUME_KEY, SE_VOLUME_DEFAULT);
    }

    public void PlaySE(string seName, float delay = 0.0f)
    {
        if (!seDic.ContainsKey(seName))
        {
            Debug.Log(seName + "There is no SE named");
            return;
        }

        nextSEName = seName;
        Invoke("DelayPlaySE", delay);
    }

    private void DelayPlaySE()
    {
        AttachSESource.PlayOneShot(seDic[nextSEName] as AudioClip);
    }

    public void PlayBGM(string bgmName, float fadeSpeedRate = BGM_FADE_SPEED_RATE_HIGH)
    {
        if (!bgmDic.ContainsKey(bgmName))
        {
            Debug.Log(bgmName + "There is no BGM named");
            return;
        }

        if (!AttachBGMSource.isPlaying)
        {
            nextBGMName = "";
            AttachBGMSource.clip = bgmDic[bgmName] as AudioClip;
            AttachBGMSource.Play();
        }

        else if (AttachBGMSource.clip.name != bgmName)
        {
            nextBGMName = bgmName;
            FadeOutBGM(fadeSpeedRate);
        }
    }

    public void FadeOutBGM(float fadeSpeedRate = BGM_FADE_SPEED_RATE_LOW)
    {
        bgmFadeSpeedRate = fadeSpeedRate;
        isFadeout = true;
    }

    private void Update()
    {
        if (!isFadeout)
        {
            return;
        }

        AttachBGMSource.volume -= Time.deltaTime * bgmFadeSpeedRate;
        if (AttachBGMSource.volume <= 0)
        {
            AttachBGMSource.Stop();
            AttachBGMSource.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, BGM_VOLUME_DEFAULT);
            isFadeout = false;

            if (!string.IsNullOrEmpty(nextBGMName))
            {
                PlayBGM(nextBGMName);
            }
        }
    }

    public void ChangeBGMVolume(float BGMVolume)
    {
        AttachBGMSource.volume = BGMVolume;
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, BGMVolume);
    }

    public void ChangeSEVolume(float SEVolume)
    {
        AttachSESource.volume = SEVolume;
        PlayerPrefs.SetFloat(SE_VOLUME_KEY, SEVolume);
    }
}
