using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class Language : EntityBase
    {
        public Language() {
			LocaleStringResource = new List<LocaleStringResource>();
        }
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Name, no puede estar vacío")]
        [Length(Max=100, Message="La longitud del campo Name no debe ser mayor a 100 caracteres")]
        public virtual string Name { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Language Culture, no puede estar vacío")]
        [Length(Max=20, Message="La longitud del campo Language Culture no debe ser mayor a 20 caracteres")]
        public virtual string LanguageCulture { get; set; }
        [Length(Max=50, Message="La longitud del campo Flag Image File Name no debe ser mayor a 50 caracteres")]
        public virtual string FlagImageFileName { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Right To Left, no puede estar vacío")]
        public virtual bool RightToLeft { get; set; }
        public virtual IList<LocaleStringResource> LocaleStringResource { get; set; }
    }
}
