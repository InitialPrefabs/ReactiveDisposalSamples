using System;
using Unity.Collections;
using Unity.Entities;

namespace ReactiveDisposal.Unmanaged {

    public struct MyDisposableData {
        public BlobPtr<int> IntValue;
    }

    public struct TestData : ISystemStateComponentData, IDisposable {

        public BlobAssetReference<MyDisposableData> BlobAsset;

        public void Dispose() {
            if (BlobAsset.IsCreated) {
                BlobAsset.Dispose();
            }
        }
    }

    public class TestDataProxy : BaseBlob<MyDisposableData> {

        protected override void AttachToEntity(Entity e, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
            dstManager.AddComponentData(e, new TestData {
                BlobAsset = ConstructBlob()
            });
        }

        protected override BlobAssetReference<MyDisposableData> ConstructBlob() {
            var builder = new BlobBuilder(Allocator.Temp);
            ref var root = ref builder.ConstructRoot<MyDisposableData>();

            ref var @int = ref builder.Allocate(ref root.IntValue);
            @int = 22;

            var asset = builder.CreateBlobAssetReference<MyDisposableData>(Allocator.Persistent);
            builder.Dispose();
            return asset;
        }
    }
}
