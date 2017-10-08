using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class Setting : EntityBase
    {
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Name, no puede estar vacío")]
        [Length(Max=30, Message="La longitud del campo Name no debe ser mayor a 30 caracteres")]
        public virtual string Name { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Value, no puede estar vacío")]
        [Length(Max=255, Message="La longitud del campo Value no debe ser mayor a 255 caracteres")]
        public virtual string Value { get; set; }
        public virtual string Description { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Last Change Date, no puede estar vacío")]
        public virtual DateTime LastChangeDate { get; set; }
        [Length(Max=500, Message="La longitud del campo Web Site Name no debe ser mayor a 500 caracteres")]
        public virtual string WebSiteName { get; set; }
        [Length(Max=500, Message="La longitud del campo Web Site Url no debe ser mayor a 500 caracteres")]
        public virtual string WebSiteUrl { get; set; }
        [Length(Max=80, Message="La longitud del campo Page Title no debe ser mayor a 80 caracteres")]
        public virtual string PageTitle { get; set; }
        [Length(Max=100, Message="La longitud del campo Admin Email Address no debe ser mayor a 100 caracteres")]
        public virtual string AdminEmailAddress { get; set; }
        [Length(Max=100, Message="La longitud del campo SMTP no debe ser mayor a 100 caracteres")]
        public virtual string SMTP { get; set; }
        [Length(Max=100, Message="La longitud del campo SMTP Username no debe ser mayor a 100 caracteres")]
        public virtual string SMTPUsername { get; set; }
        [Length(Max=100, Message="La longitud del campo SMTP Password no debe ser mayor a 100 caracteres")]
        public virtual string SMTPPassword { get; set; }
        [Length(Max=10, Message="La longitud del campo SMTP Port no debe ser mayor a 10 caracteres")]
        public virtual string SMTPPort { get; set; }
        public virtual bool? SMTPEnableSSL { get; set; }
        [Length(Max=100, Message="La longitud del campo Theme no debe ser mayor a 100 caracteres")]
        public virtual string Theme { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Default Language Id, no puede estar vací" +
            "o")]
        public virtual int DefaultLanguageId { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual string CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        public virtual string ChangedBy { get; set; }
    }
}
