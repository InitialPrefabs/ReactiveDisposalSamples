using Unity.Jobs;

namespace ReactiveDisposal.Unmanaged.Systems {

    public class TestDataReactiveDisposalSystem : ReactiveDisposalSystem<TestData> {
        protected override void OnUpdate() {
            DisposeOnMainThread();
        }
    }

    public class SpriteRendererReactiveDisposalSystem : ReactiveDisposalJobSystem<SpriteRendererBlob> {
        protected override JobHandle OnUpdate(JobHandle inputDeps) {
            return ScheduleDisposalJob(inputDeps);
        }
    }
}
