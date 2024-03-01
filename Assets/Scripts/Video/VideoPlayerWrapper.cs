using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace AS.Framework
{
	public class VideoPlayerWrapper : MonoBehaviour,
		IVideoPlayerWrapper
	{
		[SerializeField] private VideoPlayer _videoPlayer;

		public VideoPlayerState State { get; private set; }
		public float FramesCount => _videoPlayer.frameCount;
		public float FrameRate => _videoPlayer.frameRate;
		public float CurrentFrame => _videoPlayer.frame;

		public void Play()
		{
			_videoPlayer.Play();
			State = VideoPlayerState.Play;
		}

		public void Stop()
		{
			_videoPlayer.Stop();
			State = VideoPlayerState.Stop;
		}

		public void Pause()
		{
			_videoPlayer.Pause();
			State = VideoPlayerState.Pause;
		}

		public void Setup(VideoClip videoClip, Action onCompleteCallback = null)
		{
			_videoPlayer.source = VideoSource.VideoClip;
			_videoPlayer.clip = videoClip;

			StartCoroutine(PreparePlayerCoroutine(onCompleteCallback));
		}

		public void Setup(string videoUrl, Action onCompleteCallback = null)
		{
			_videoPlayer.source = VideoSource.Url;
			_videoPlayer.url = videoUrl;

			StartCoroutine(PreparePlayerCoroutine(onCompleteCallback));
		}

		public void Play(VideoClip videoClip)
		{
			_videoPlayer.source = VideoSource.VideoClip;
			_videoPlayer.clip = videoClip;

			StartCoroutine(PreparePlayerCoroutine(Play));
		}

		public void Play(string videoUrl)
		{
			_videoPlayer.source = VideoSource.Url;
			_videoPlayer.url = videoUrl;

			StartCoroutine(PreparePlayerCoroutine(Play));
		}

		public void Warmup(params VideoClip[] videoClips)
		{
			State = VideoPlayerState.Warmup;

			IEnumerator WarmupVideoClipsCoroutine(IReadOnlyList<VideoClip> videoClipsToWarmup)
			{
				foreach (var videoClip in videoClipsToWarmup)
				{
					_videoPlayer.source = VideoSource.VideoClip;
					_videoPlayer.clip = videoClip;
					_videoPlayer.Prepare();

					while (_videoPlayer.isPrepared == false)
					{
						yield return null;
					}
				}

				State = VideoPlayerState.Stop;
			}

			StartCoroutine(WarmupVideoClipsCoroutine(videoClips));
		}

		public void Warmup(params string[] videoUrls)
		{
			State = VideoPlayerState.Warmup;

			IEnumerator WarmupVideoClipsCoroutine(IReadOnlyList<string> videoUrlsToWarmup)
			{
				foreach (var videoUrl in videoUrlsToWarmup)
				{
					_videoPlayer.source = VideoSource.Url;
					_videoPlayer.url = videoUrl;
					_videoPlayer.Prepare();

					while (_videoPlayer.isPrepared == false)
					{
						yield return null;
					}
				}

				State = VideoPlayerState.Stop;
			}

			StartCoroutine(WarmupVideoClipsCoroutine(videoUrls));
		}

		private IEnumerator PreparePlayerCoroutine(Action onCompleteCallback = null)
		{
			_videoPlayer.Prepare();

			while (_videoPlayer.isPrepared == false)
			{
				yield return null;
			}

			_videoPlayer.frame = 0;

			onCompleteCallback?.Invoke();
		}
	}
}