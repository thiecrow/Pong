﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class GameObjects
    {
        public Paddle PlayerPaddle { get; set; }
        public Paddle ComputerPaddle { get; set; }
        public Ball Ball { get; set; }
        public Score Score { get; set; }

    }
}
