using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Pieces {
    public class SelectionCollection : List<Card> {
        

        public SelectionCollection() : base(3) {

        }

        public bool IsFull => base.Count == 3;

        public void AddCardo(Card c) {
            if (base.Count > 3)
                return;

            base.Add(c);
        }

        public void Clear() {
            foreach (var c in this)
                c.Selected = false;
            base.Clear();
        }

        public bool IsMatch() {
            //todo what do i do here
            if (base.Count != 3)
                return false;

            var list = this;
            return CompareCat(list.Select(c => c.ValueTrait0).ToArray())
                && CompareCat(list.Select(c => c.ValueTrait1).ToArray())
                && CompareCat(list.Select(c => c.ValueTrait2).ToArray());

        }

        bool CompareCat(string[] traits) {
            if (traits[0] == traits[1])
                return traits[1] == traits[2];
            else
                return (traits[0] != traits[2] 
                    && traits[1] != traits[2]);
        }
    }
}
