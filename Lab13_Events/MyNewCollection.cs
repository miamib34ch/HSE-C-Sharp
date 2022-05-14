using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10_Interfaces;
using Lab12_CollectionsCreatedByUser;

namespace Lab13_Events
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    public class MyNewCollection : MyCollection
    {
        public event CollectionHandler CollectionCountChanged; //событие после добаления или удаления объектов
        public event CollectionHandler CollectionReferenceChanged;  //при изменении ссылок 

        public string NameCollection
        {
            get;
            set;
        }

        public MyNewCollection(string Name)
        {
            NameCollection = Name;
            this.data = null;
            this.next = null;
            this.Count = 0;
        }

        public void Add(Challenge obj)
        {
            if (this.Count == 0)
            {
                this.data = obj;
                this.Count = this.Count + 1;
                this.OnCollctionCountChaged(this, new CollectionHandlerEventArgs("add", this[0]));
            }
            else
            {
                this[Count - 1].next = new MyCollection(obj.Grade, obj.Name);
                this.Count = this.Count + 1;
                this.OnCollctionCountChaged(this, new CollectionHandlerEventArgs("add", this[Count - 1]));
            }
        }

        public void AddDefault()
        {
            Random rnd = new Random();
            string[] subject = { "biology", "algebra", "geometry", "project", "chemistry", "math", "english", "russian", "programming", "physics", "history" };
            if (this.Count == 0)
            {
                this.data = new Challenge(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
                this.Count = this.Count + 1;
                this.OnCollctionCountChaged(this, new CollectionHandlerEventArgs("add", this[0]));
            }
            else
            {
                this[Count - 1].next = new MyCollection(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
                this.Count = this.Count + 1;
                this.OnCollctionCountChaged(this, new CollectionHandlerEventArgs("add", this[Count - 1]));
            }
        }

        public bool Remove(int j)
        {
            if (j > 0 && j < this.Count - 1)
            {
                this.OnCollctionCountChaged(this, new CollectionHandlerEventArgs("delete", this[j]));
                this[j - 1].next = this[j + 1];
                this.Count--;
                return true;
            }
            else
            {
                if (j == 0)
                {
                    this.OnCollctionCountChaged(this, new CollectionHandlerEventArgs("delete", this[j]));
                    MyCollection a = DeletePoint(this);
                    this.data = a.data;
                    this.next = a.next;
                    this.Count--;
                    return true;
                }
                else
                {
                    if (j == this.Count - 1)
                    {
                        this.OnCollctionCountChaged(this, new CollectionHandlerEventArgs("delete", this[j]));
                        this[Count - 2].next = null;
                        this.Count--;
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public override MyCollection this[int index]
        {
            get
            {
                MyCollection r = this;
                if (index <= Count - 1)
                {
                    for (int i = 0; i < index; i++)
                    {
                        r = r.next;
                    }
                    return r;
                }
                else
                {
                    if (index == 0)
                    {
                        for (int i = 0; i <= index; i++)
                        {
                            r = r.next;
                        }
                        return r;
                    }
                    else return this;
                }
            }
            set
            {
                if (index == 0)
                {
                    MyCollection r = this;
                    for (int i = 0; i <= index; i++)
                    {
                        r = r.next;
                    }
                    r = value;
                    this.OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs("change", r));
                }
                else
                    if (index <= Count - 1)
                {
                    MyCollection r = this;
                    for (int i = 0; i < index; i++)
                    {
                        r = r.next;
                    }
                    r = value;
                    this.OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs("change", r));
                }

            }
        }

        public void OnCollctionCountChaged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(source, args);
        }

        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(source, args);
        }

    }

}
