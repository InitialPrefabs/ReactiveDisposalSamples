using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Reactive.Unmanaged.Systems {

    [UpdateInGroup(typeof(DisposalTriggerGroup))]
    public class DestroySpriteRenderererEntitySystem : ComponentSystem {

        protected override void OnUpdate() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Entities.ForEach((Entity e, ref SpriteRendererBlob blob) => {
                    PostUpdateCommands.DestroyEntity(e);
                });
            }
        }
    }
}
