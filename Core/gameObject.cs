using System;
using System.Collections.Generic;
using csEngine.Components;
using csEngine.Physics;
using csEngine.Rendering;

namespace csEngine.Core
{
    public class gameObject
    {
        private List<gameObject> children;
        private List<gameComponent> components;
        private Transform transform;
        private coreEngine engine;

        public List<gameObject> getAllAtached() { return children; }
        public List<gameComponent> getComponents() { return components; }
        public Transform getTransform() { return transform; }
        public coreEngine getCoreEngine() { return engine; }

        public void setTransform(Transform transform) { this.transform = transform; }
        public void setCoreEngine(coreEngine engine) { this.engine = engine; }

        public gameObject()
        {
            children = new List<gameObject>();
            components = new List<gameComponent>();
            transform = new Transform();
            engine = null;
        }

        public gameObject addChild(gameObject child)
        {
            children.Add(child);
            child.setCoreEngine(engine);
            child.getTransform().setParent(transform);

            return this;
        }

        public gameObject addComponent(gameComponent component)
        {
            components.Add(component);
            //component.setParent(this);

            return this;
        }
    }
}
