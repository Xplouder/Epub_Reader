using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePubIntegrator.Models {
    public class MutableKeyValuePair<TKey, TValue> {

        public MutableKeyValuePair (TKey key, TValue value) {
            Key = key;
            Value = value;
        }

        public TKey Key {
            get;
            set;
        }
        public TValue Value {
            get;
            set;
        }
    }
}
