using System;
using System.Collections.Generic;

namespace MoneysoftTechTest
{
    class TrafficIntersection
    {
        public List<TrafficQueue> AllTraffic { get; set; }
        public TrafficQueue ActiveTraffic { get; set; }
    }

    class TrafficLight
    {
        public LightColour CurrentColour { get; set; }
        public DateTime LastGreenTime { get; set; }
    }

    class TrafficQueue
    {
        public TrafficLight Light { get; set; }
        public Direction TrafficDirection { get; set; }
        public List<TrafficQueue> BlockedTraffic { get; set; }
        public Dictionary<TrafficQueue, Direction> OtherTraffic { get; set; } //What side the other traffic queues are in relation to this queue
    }

    enum LightColour
    {
        Red,
        Amber,
        Green
    }

    [Flags]
    enum Direction
    {
        Left = 1,
        Straight = 2,
        Right = 4
    }
}
