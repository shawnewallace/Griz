using System;
using Griz.Data.Interfaces;

namespace Griz.Data.Models
{
    /// <summary>
    /// Base class for all Entity classes. Entities are low-level Model classes that have a tight
    /// coupling to a specific table in the database. Any domain object wishing to utilize NHibernate
    /// for persistence should ultimately be derived from EntityBase, although in most cases 
    /// deriving from ModelBase is preferable to directly inheriting this class.
    /// </summary>
    /// <typeparam name="TKey">The data type for the primary key of this entity.</typeparam>
    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Indicates whether or not this entity has been flagged for deletion.
        /// </summary>
        public virtual bool IsDeleted { get; protected set; }

        /// <summary>
        /// Mark this entity for deletion. Derived types that want to cascade deletes should override
        /// this and cascade the delete to their children. Derived types with business rules governing
        /// delete should implement them here, throwing a rule violation exception if the model is not
        /// available for deleting.
        /// </summary>
        public virtual void MarkForDeletion()
        {
            IsDeleted = true;
        }

        /// <summary>
        /// Clears the delete flag from this entity. Derived types that cascade deletes to their children
        /// should override this and cascade the undelete as well.
        /// </summary>
        public virtual void Undelete()
        {
            IsDeleted = false;
        }

        /// <summary>
        /// Indicates whether or not this represents a new entity or one that already exists in the DB.
        /// </summary>
        public virtual bool IsTransient
        {
            get { return Id.Equals(default(TKey)); }
        }

        #region Object equality

        /// <summary>
        /// Returns TRUE if two Entity instances refer to the same database record
        /// or the same object in memory.
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as EntityBase<TKey>);
        }


        /// <summary>
        /// Returns TRUE if two Entity instances refer to the same database record
        /// or the same object in memory.
        /// </summary>
        public virtual bool Equals(EntityBase<TKey> otherEntity)
        {
            var otherIsNotNull = (otherEntity != null);
            var otherIsSameObj = ReferenceEquals(this, otherEntity);
            var idsAreEqual = otherIsNotNull && (otherEntity.Id.Equals(this.Id));

            return otherIsNotNull && (otherIsSameObj || idsAreEqual);
        }


        public override int GetHashCode()
        {
            lock (_synchronizer)
            {
                if (_hashCode == null)
                {
                    // The hash code is normally based upon the Id value, unless GetHashCode()
                    // is called on a transient instance without an ID. The hash code should
                    // never change once it is set.
                    _hashCode = IsTransient
                                    ? base.GetHashCode()
                                    : Id.GetHashCode();
                }

                return _hashCode.Value;
            }
        }


        /// <summary>
        /// The hash code is normally based upon the Id value, unless GetHashCode()
        /// is called on a transient instance without an ID. The hash code should
        /// never change once it is set, so this field records the first hash code
        /// that is generated.
        /// </summary>
        private int? _hashCode;

        private object _synchronizer = new Object();

        #endregion
    }
}
