using Unity.Jobs;

namespace ReactiveDisposal.Unmanaged.Systems {

    public class SpriteRendererReactiveDisposalSystem : ReactiveDisposalSystem<SpriteRendererBlob> {
        protected override JobHandle OnUpdate(JobHandle inputDeps) {
            return ScheduleDisposalJob(inputDeps);
        }
    }
}
