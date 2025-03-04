namespace Platformer.Core
{
    public interface ISlideDetectingModel
    {
        public bool IsSlideOnWall { get; }
        public void SetIsSlideOnWall(bool isSlideOnWall);
    }
}