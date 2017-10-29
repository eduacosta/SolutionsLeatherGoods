using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class OrderNumber : EntityBase
    {
        [DataMember]
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún  [DataMember]valor para el campo Number, no puede estar vacío")]
        [DataMember]
        public virtual int Number { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual string CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        public virtual string ChangedBy { get; set; }
    }
}
