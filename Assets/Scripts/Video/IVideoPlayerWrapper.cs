using System;
using UnityEngine.Video;

namespace AS.Framework
{
    public interface IVideoPlayerWrapper
    {
        VideoPlayerState State { get; }

        float FramesCount { get; }
        float FrameRate { get; }
        float CurrentFrame { get; }

        void Play();
        void Stop();
        void Pause();

        void Setup(VideoClip videoClip, Action onCompleteCallback = null);
        void Setup(string videoUrl, Action onCompleteCallback = null);

        void Play(VideoClip videoClip);
        void Play(string videoUrl);

        void Warmup(params VideoClip[] videoClips);
        void Warmup(params string[] videoUrls);
    }
}