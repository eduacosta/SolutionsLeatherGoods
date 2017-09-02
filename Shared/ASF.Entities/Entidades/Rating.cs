using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class Rating : EntityBase
    {
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Client, no puede estar vacío")]
        public virtual Client Client { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Product, no puede estar vacío")]
        public virtual Product Product { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Stars, no puede estar vacío")]
        public virtual int Stars { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual int? CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        public virtual int? ChangedBy { get; set; }
    }
}
