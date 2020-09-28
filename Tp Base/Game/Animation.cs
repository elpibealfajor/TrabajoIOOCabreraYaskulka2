﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Animation
    {
        private string name;
        private List<Texture> frames;
        private int currentFrameIndex = 0;
        private float speed = 0.5f;
        private float currentAnimationTime;
        private bool isLoopEnabled;


        public int FramesCount => frames.Count;
        public int CurrentFrameIndex => currentFrameIndex;
        public Texture CurrentFrame => frames[currentFrameIndex];

        public Animation(List<Texture> frames, float speed, bool isLoopEnabled = true, string name = "Default")
        {
            if (frames != null)
            {
                this.frames = frames;
            }

            this.name = name;
            this.speed = speed;
            this.isLoopEnabled = isLoopEnabled;
        }

        public void Update()
        {
            currentAnimationTime += Program.deltaTime;

            if (currentAnimationTime >= speed)
            {
                currentFrameIndex++;
                currentAnimationTime = 0;

                if (currentFrameIndex >= frames.Count)
                {
                    if (isLoopEnabled)
                    {
                        currentFrameIndex = 0;
                    }
                    else
                    {
                        currentFrameIndex = frames.Count - 1;
                    }
                }
            }
        }
    }
}
