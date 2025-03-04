namespace Platformer.Core
{
    public interface IUpdateble : IController
    {
        public void Update(float deltaTime);
    }
}