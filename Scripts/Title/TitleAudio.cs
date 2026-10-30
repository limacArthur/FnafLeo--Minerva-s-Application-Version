using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace FNAFLEOv2.Scripts.Title
{
	public partial class TitleAudio : AudioStreamPlayer
	{
		VideoStreamPlayer video;

		public override void _Ready()
		{
			video = GetParent().GetNode<VideoStreamPlayer>("/root/TitleScreen/CanvasLayer/VideoStreamPlayer");
			video.Finished += OnVideoFinished;
		}

		void OnVideoFinished()
		{
			Play();
		}
		

	}
}
