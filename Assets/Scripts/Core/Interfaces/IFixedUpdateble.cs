namespace Platformer.Core
{
    public interface IFixedUpdateble : IController
    {
        public void FixedUpdate(float fixedDeltaTime);
    }
}