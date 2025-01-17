﻿using Components.Events.Physics;
using Components.Movement;
using Unity.Entities;
using UnityEngine;

namespace Entities
{
    public class Unit : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity,
                            EntityManager entityManager,
                            GameObjectConversionSystem conversionSystem)
        {
            Vector3 pos = transform.position;

            entityManager.AddComponentData(
                    entity,
                    new UnitComponent {Position = pos, Destination = pos}
                );

            entityManager.AddBuffer<StatefulTriggerEvent>(entity);
            entityManager.AddComponentData(entity, new CollisionEventsReceiverProperties());
            entityManager.AddBuffer<StatefulCollisionEvent>(entity);
        }
    }
}