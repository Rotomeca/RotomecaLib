using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace RotomecaLib
{
    public class EmptyRotomecaObject : RotomecaObject
    {
        public EmptyRotomecaObject() { }
    }

    public class DynamicRotomecaObject : DynamicObject
    {
        public class Champ
        {
            public string FieldName;
            public Type FieldType;

            public Champ(string name, Type type)
            {
                this.FieldName = name;
                this.FieldType = type;
            }
        }

        private Dictionary<string, KeyValuePair<Type, object>> _champs;

        public dynamic this[string name]
        {
            get => _champs[name].Value;
            set => _champs.Add(name, new KeyValuePair<Type, object>(value.GetType(), value));
        }

        public DynamicRotomecaObject()
        {
            _champs = new Dictionary<string, KeyValuePair<Type, object>>();
        }

        public DynamicRotomecaObject(List<Champ> champs)
        {
            _champs = new Dictionary<string, KeyValuePair<Type, object>>();
            champs.ForEach(x => _champs.Add(x.FieldName,
                new KeyValuePair<Type, object>(x.FieldType, null)));
        }

        public DynamicRotomecaObject(IDictionary<string, KeyValuePair<Type, object>> objet)
        {
            _champs = new Dictionary<string, KeyValuePair<Type, object>>(objet);
        }

        public DynamicRotomecaObject(IDictionary<string, Tuple<Type, object>> objet)
        {
            _champs = new Dictionary<string, KeyValuePair<Type, object>>(objet.ToDictionary(x => x.Key, x => new KeyValuePair<Type, object>(x.Value.Item1, x.Value.Item2)));
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_champs.ContainsKey(binder.Name))
            {
                var type = _champs[binder.Name].Key;
                if (value.GetType() == type)
                {
                    _champs[binder.Name] = new KeyValuePair<Type, object>(type, value);
                    return true;
                }
                else throw new Exception("Value " + value + " is not of type " + type.Name);
            }
            return false;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _champs[binder.Name].Value;
            return true;
        }

        public static dynamic Creer()
        {
            return new DynamicRotomecaObject();
        }
    }
}
