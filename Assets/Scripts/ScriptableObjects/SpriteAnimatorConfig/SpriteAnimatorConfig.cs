using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Core
{
    [CreateAssetMenu(fileName = "SpriteAnimationConfig", menuName = "Configs/Animation", order = 1)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        public ActorsTypes actorType;
        public List<SpriteSequence> SpriteSequences = new List<SpriteSequence>();

        public SpriteSequence FindSequence(AnimationsTypes track)
        {
            SpriteSequence sequence = null;

            for (int i = 0; i < SpriteSequences.Count; i++)
            {
                if (SpriteSequences[i].Track == track)
                {
                    sequence = SpriteSequences[i];
                    break;
                }
            }

            return sequence;
        }
    }
}