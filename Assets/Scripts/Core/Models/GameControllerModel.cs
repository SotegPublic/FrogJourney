﻿using System;
using System.Collections.Generic;

namespace Platformer.Core
{
    public class GameControllerModel
    {
        private readonly List<IFixedUpdateble> _fixedControllers;
        private readonly List<IUpdateble> _updateControllers;
        private readonly List<ILateUpdateble> _lateUpdateControllers;
        private readonly List<IDisposable> _disposables;
        public GameControllerModel()
        {
            _updateControllers = new List<IUpdateble>(8);
            _lateUpdateControllers = new List<ILateUpdateble>(8);
            _fixedControllers = new List<IFixedUpdateble>(8);
            _disposables = new List<IDisposable>(8);
        }

        public List<IUpdateble> UpdateControllers => _updateControllers;
        public List<ILateUpdateble> LateUpdateControllers => _lateUpdateControllers;
        public List<IFixedUpdateble> FixedControllers => _fixedControllers;
        public List<IDisposable> Disposables => _disposables;
    }
}