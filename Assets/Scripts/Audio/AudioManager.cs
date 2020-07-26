using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    private static bool _initialized = false;
    private static AudioSource _audioSource;
    private static Dictionary<AudioClipName, AudioClip> _audioClips = new Dictionary<AudioClipName, AudioClip>();

    public static bool Initialized => _initialized;

    public static void Initialize(AudioSource source)
    {
        _initialized = true;
        _audioSource = source;
        _audioClips.Add(AudioClipName.Lose, Resources.Load<AudioClip>("Audio/lose"));
        _audioClips.Add(AudioClipName.Win, Resources.Load<AudioClip>("Audio/Win"));
        _audioClips.Add(AudioClipName.HitBlock, Resources.Load<AudioClip>("Audio/HitBlock"));
        _audioClips.Add(AudioClipName.BonusBlock, Resources.Load<AudioClip>("Audio/BonusBlock"));
        _audioClips.Add(AudioClipName.SpeedupEffect, Resources.Load<AudioClip>("Audio/SpeedupEffect"));
        _audioClips.Add(AudioClipName.FreezeEffectStart, Resources.Load<AudioClip>("Audio/FreezeEffectStart"));
        _audioClips.Add(AudioClipName.FreezeEffectFinish, Resources.Load<AudioClip>("Audio/FreezeEffectFinish"));
        _audioClips.Add(AudioClipName.ClickButton, Resources.Load<AudioClip>("Audio/ClickButton"));
        _audioClips.Add(AudioClipName.HitPaddle, Resources.Load<AudioClip>("Audio/HitPaddle"));
        _audioClips.Add(AudioClipName.LossBall, Resources.Load<AudioClip>("Audio/LossBall"));
    }

    public static void Play(AudioClipName name)
    {
        _audioSource.PlayOneShot(_audioClips[name]);
    }
}

public enum AudioClipName
{
    HitBlock,
    BonusBlock,
    SpeedupEffect,
    FreezeEffectStart,
    FreezeEffectFinish,
    Lose,
    Win,
    ClickButton,
    HitPaddle,
    LossBall
}
