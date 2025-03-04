
using Platformer.Core;
using System;
using UnityEngine;

namespace Platformer.Input
{
    public class InputSystemController : IDisposable, IFixedUpdateble
    {
        private UserInput _userInputSystem;
        private InputSystemModel _model;

        public InputSystemModel InputModel => _model;

        public InputSystemController()
        {
            _model = new InputSystemModel();

            _userInputSystem = new UserInput();
            _userInputSystem.Enable();

            _userInputSystem.Player.Jump.performed += context => OnJumpButtonClick();
        }

        private void OnJumpButtonClick()
        {
            _model.OnJumpButtonClick?.Invoke();
        }

        public void Dispose()
        {
            _userInputSystem.Player.Jump.performed -= context => OnJumpButtonClick();
            _userInputSystem.Disable();
        }

        public void FixedUpdate(float deltaTime)
        {
            _model.MoveDirection = _userInputSystem.Player.Move.ReadValue<Vector2>();
        }
    }
}