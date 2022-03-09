using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace RotomecaLib
{
    public abstract class RotomecaObject
    {
        RotomecaObject parent;
        List<RotomecaObject> children;

        public RotomecaObject Parent => parent;
        public IEnumerable<RotomecaObject> Children => _InitChildren().children;
        public static RotomecaObject Empty => new EmptyRotomecaObject();
        public static dynamic Dynamic => DynamicRotomecaObject.Creer();

        public RotomecaObject SetParent(RotomecaObject @object)
        {
            parent = @object;
            @object.AddChild(this);
            return this;
        }

        public RotomecaObject RemoveParent()
        {
            return SetParent(null).parent;
        }

        public RotomecaObject AddChild(RotomecaObject @object)
        {
            _InitChildren();
            children.Add(@object);
            @object.SetParent(this);
            return this;
        }

        public RotomecaObject AddChildren(IEnumerable<RotomecaObject> objects)
        {
            _InitChildren();
            children.AddRange(objects);

            foreach (var item in objects)
            {
                item.SetParent(this);
            }

            return this;
        }

        public System.Threading.Tasks.Task AddChildrenAsync(IEnumerable<RotomecaObject> objects)
        {
            AddChildren(objects);
            return System.Threading.Tasks.Task.CompletedTask;
        }

        private RotomecaObject _InitChildren()
        {
            if (children == null) children = new List<RotomecaObject>();
            return this;
        }

    }
}
