using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class Country : EntityBase
    {
        public Country() {
			Client = new List<Client>();
			Dealer = new List<Dealer>();
        }
        [DataMember]
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Name, no puede estar vacío")]
        [Length(Max=60, Message="La longitud del campo Name no debe ser mayor a 60 caracteres")]
        [DataMember]
        public virtual string Name { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        [DataMember]
        public virtual DateTime CreatedOn { get; set; }
        [DataMember]
        public virtual string CreatedBy { get; set; }
        [DataMember]
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        [DataMember]
        public virtual string ChangedBy { get; set; }
        [DataMember]
        public virtual IList<Client> Client { get; set; }
        public virtual IList<Dealer> Dealer { get; set; }
    }
}
