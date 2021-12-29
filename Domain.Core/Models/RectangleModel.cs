using System;

namespace Domain.Core.Models
{
    public class RectangleModel
    {
        public long Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public DateTime Time { get; set; }
    }
}
