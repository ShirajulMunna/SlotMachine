using System.Collections.Generic;
using UnityEngine;

namespace JGM.Game.Patterns
{
    public interface ILinePatternChecker
    {
        ILineResult GetResultFromLine(in List<int> itemsInsideLine, GameObject failWindow, GameObject winWindow, GameObject[] particle, Sprite[] sprites, int particleStyleMode);
    }
}