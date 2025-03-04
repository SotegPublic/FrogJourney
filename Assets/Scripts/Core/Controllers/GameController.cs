using System;

namespace Platformer.Core
{
    public class GameController : IController, IDisposable
    {
        private GameControllerModel _model;

        public GameController()
        {
            _model = new GameControllerModel();
        }

        public void AddController(IController controller)
        {
            if (controller is IUpdateble updateController)
            {
                _model.UpdateControllers.Add(updateController);
            }

            if (controller is ILateUpdateble lateUpdateController)
            {
                _model.LateUpdateControllers.Add(lateUpdateController);
            }

            if (controller is IFixedUpdateble fixedController)
            {
                _model.FixedControllers.Add(fixedController);
            }

            if (controller is IDisposable disposable)
            {
                AddDisposable(disposable);
            }
        }

        public void AddDisposable(IDisposable disposable)
        {
            _model.Disposables.Add(disposable);
        }

        public void Update(float deltaTime)
        {
            for (var element = 0; element < _model.UpdateControllers.Count; ++element)
            {
                _model.UpdateControllers[element].Update(deltaTime);
            }
        }

        public void LateUpdate(float deltaTime)
        {
            for (var element = 0; element < _model.LateUpdateControllers.Count; ++element)
            {
                _model.LateUpdateControllers[element].LateUpdate(deltaTime);
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            for (var element = 0; element < _model.FixedControllers.Count; ++element)
            {
                _model.FixedControllers[element].FixedUpdate(fixedDeltaTime);
            }
        }

        public void Dispose()
        {
        }
    }
}