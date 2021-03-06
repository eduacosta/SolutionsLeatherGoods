using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class Category : EntityBase
    {
        public Category() {
			Dealer = new List<Dealer>();
        }
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Name, no puede estar vacío")]
        [Length(Max=30, Message="La longitud del campo Name no debe ser mayor a 30 caracteres")]
        [DataMember]
        [DisplayName("Name")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public virtual string Name { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        [DataMember]
        [DisplayName("Created On")]
        public virtual DateTime CreatedOn { get; set; }
        [DataMember]
        [DisplayName("Created By")]
        public virtual string CreatedBy { get; set; }
        [DataMember]
        [DisplayName("Changed On")]
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        [DataMember]
        [DisplayName("Changed By")]
        public virtual string ChangedBy { get; set; }
        public virtual IList<Dealer> Dealer { get; set; }
    }
}
