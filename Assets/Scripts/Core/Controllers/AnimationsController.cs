using System.Collections.Generic;
using System;
using UnityEngine;

namespace Platformer.Core
{
    public class AnimationsController : IDisposable, IUpdateble, ILateUpdateble
    {
        private Dictionary<ActorsTypes, SpriteAnimatorConfig> _animatorsConfigs;
        private Dictionary<SpriteRenderer, ObjectAnimationController> _activeAnimations = new Dictionary<SpriteRenderer, ObjectAnimationController>(20);
        private Dictionary<SpriteRenderer, ObjectAnimationController> _animationsForChange = new Dictionary<SpriteRenderer, ObjectAnimationController>(20);
        private List<SpriteRenderer> _animationsToDelete = new List<SpriteRenderer>(20);

        private bool _isNeedUpdateAnimations;

        public AnimationsController(List<SpriteAnimatorConfig> animationsConfigs)
        {
            Init(animationsConfigs);
        }

        private void Init(List<SpriteAnimatorConfig> animationsConfigs)
        {
            _animatorsConfigs = new Dictionary<ActorsTypes, SpriteAnimatorConfig>(animationsConfigs.Count);

            for (int i = 0; i < animationsConfigs.Count; i++)
            {
                AddAnimatorsConfig(animationsConfigs[i]);
            }
        }

        public void AddAnimatorsConfig(SpriteAnimatorConfig config)
        {
            if(_animatorsConfigs.ContainsKey(config.actorType))
            {
                return;
            }
            else
            {
                _animatorsConfigs.Add(config.actorType, config);
            }
        }

        public void ChangeAnimation(SpriteRenderer spriteRenderer, AnimationsTypes track, ActorsTypes actorType, bool loop, Action OnAnimationEndCallBack = null)
        {
            if (_animationsForChange.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = _animatorsConfigs[actorType].FindSequence(track).AnimationSpeed;
                animation.Sleep = false;
                animation.OnAnimationEndCallBack = OnAnimationEndCallBack;

                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _animatorsConfigs[actorType].FindSequence(track).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _animationsForChange.Add(spriteRenderer, new ObjectAnimationController()
                {
                    Track = track,
                    Sprites = _animatorsConfigs[actorType].FindSequence(track).Sprites,
                    Loop = loop,
                    Speed = _animatorsConfigs[actorType].FindSequence(track).AnimationSpeed,
                    Sleep = false,
                    OnAnimationEndCallBack = OnAnimationEndCallBack
                });
            }

            _isNeedUpdateAnimations = true;
        }

        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            _animationsToDelete.Add(spriteRenderer);
            _isNeedUpdateAnimations = true;
        }

        public void PauseAnimation (SpriteRenderer spriteRenderer)
        {
            if (_activeAnimations.ContainsKey(spriteRenderer))
            {
                _activeAnimations[spriteRenderer].Sleep = true;
            }
        }

        public void Update(float deltaTime)
        {
            foreach (var animation in _activeAnimations)
            {
                if (animation.Key.isVisible)
                {
                    animation.Value.Update(deltaTime);

                    if (animation.Value.Counter < animation.Value.Sprites.Count)
                    {
                        animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                    }
                }
            }
        }

        public void LateUpdate(float deltaTime)
        {
            if(_isNeedUpdateAnimations)
            {
                for (int i = 0; i < _animationsToDelete.Count; ++i)
                {
                    if (_activeAnimations.ContainsKey(_animationsToDelete[i]))
                    {
                        _activeAnimations[_animationsToDelete[i]].Dispose();
                        _activeAnimations.Remove(_animationsToDelete[i]);
                    }
                }

                foreach (var animation in _animationsForChange)
                {
                    if(_activeAnimations.ContainsKey(animation.Key))
                    {
                        _activeAnimations[animation.Key].Dispose();
                        _activeAnimations[animation.Key] = animation.Value;
                    }
                    else
                    {
                        _activeAnimations.Add(animation.Key, animation.Value);
                    }
                }

                _animationsToDelete.Clear();
                _animationsForChange.Clear();
                _isNeedUpdateAnimations = false;
            }
        }

        public void Dispose()
        {
            foreach (var animation in _activeAnimations)
            {
                animation.Value.Dispose();
            }

            _animatorsConfigs.Clear();
            _activeAnimations.Clear();
        }
    }
}