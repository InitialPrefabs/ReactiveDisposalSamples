using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Reactive.Unmanaged {

    public struct SpriteRendererRefWrapper {
        public SpriteRenderer WrappedValue;
    }

    public struct SpriteRendererPtr {
        public BlobPtr<SpriteRendererRefWrapper> Ptr;
    }

    public struct SpriteRendererBlob : ISystemStateComponentData, System.IDisposable {
        public BlobAssetReference<SpriteRendererPtr> BlobAsset;

        public SpriteRenderer SpriteRenderer => BlobAsset.Value.Ptr.Value.WrappedValue;

        public void Dispose() {
            if (BlobAsset.IsCreated)
                BlobAsset.Dispose();
        }
    }

    public class SpriteRendererBlobProxy : BaseBlob<SpriteRendererPtr> {

        public SpriteRenderer SpriteRenderer;

        protected override void AttachToEntity(Entity e, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
            dstManager.AddComponentData(e, new SpriteRendererBlob {
                BlobAsset = ConstructBlob()
            });
        }

        protected override BlobAssetReference<SpriteRendererPtr> ConstructBlob() {
            var builder = new BlobBuilder(Allocator.Temp);
            ref var root = ref builder.ConstructRoot<SpriteRendererPtr>();

            ref var wrappedValue = ref builder.Allocate(ref root.Ptr);
            wrappedValue = new SpriteRendererRefWrapper { WrappedValue = SpriteRenderer };

            var blobAsset = builder.CreateBlobAssetReference<SpriteRendererPtr>(Allocator.Persistent);
            builder.Dispose();
            return blobAsset;
        }
    }
}
