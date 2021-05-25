using System;
namespace ImPossibleFoundation.Shared.Dtos
{
    public class SlideItemDto
    {
        public string Label { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public TransitionType Transition { get; set; } = TransitionType.Slide;
        public string Height { get; set; } = "100%";

    }

    public enum TransitionType
    {
        None = 0,
        Fade = 1,
        Slide = 2,
        Custom = 99
    }
}