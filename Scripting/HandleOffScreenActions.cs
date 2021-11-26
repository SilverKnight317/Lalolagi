
using System.Collections.Generic;
using Lalolagi.Casting;
using Lalolagi.Services;

namespace Lalolagi
{
    public class HandleOffScreenActions : Action
    {
        AudioService _audioService;
        public HandleOffScreenActions(AudioService audioService)
        {
            _audioService = audioService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            throw new System.NotImplementedException();
        }
    }
}