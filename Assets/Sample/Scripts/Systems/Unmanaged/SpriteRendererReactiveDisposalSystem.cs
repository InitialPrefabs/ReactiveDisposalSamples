using Unity.Jobs;
using UnityEngine;

namespace Reactive.Unmanaged.Systems {

    public class SpriteRendererReactiveDisposalSystem : ReactiveDisposalSystem {
        protected override JobHandle OnUpdate(JobHandle inputDeps) {
            return ScheduleDisposalJob<SpriteRendererBlob>(inputDeps);
        }
    }
}
