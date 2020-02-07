using Unity.Entities;
using UnityEngine;

namespace ReactiveDisposal.Unmanaged.Systems {

    public class DestroyUnmanagedEntitySystem : ComponentSystem {

        protected override void OnUpdate() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Entities.ForEach((Entity e, ref SpriteRendererBlob blob) => {
                    PostUpdateCommands.DestroyEntity(e);
                });
            }

            if (Input.GetKeyDown(KeyCode.A)) {
                Entities.ForEach((Entity e, ref TestData blob) => {
                    PostUpdateCommands.DestroyEntity(e);
                });
            }
        }
    }
}
