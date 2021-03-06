using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {

    [Serializable]
    [DataContract]
    public class AspNetUserLogins : EntityBase
    {
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Asp Net Users, no puede estar vacío")]
        [Length(Max=128, Message="La longitud del campo Asp Net Users no debe ser mayor a 128 caracteres")]
        public virtual AspNetUsers AspNetUsers { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as AspNetUserLogins;
			if (t == null) return false;
			if (LoginProvider == t.LoginProvider
			 && ProviderKey == t.ProviderKey
			 && AspNetUsers.Id == t.AspNetUsers.Id)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ LoginProvider.GetHashCode();
			hash = (hash * 397) ^ ProviderKey.GetHashCode();
			hash = (hash * 397) ^ AspNetUsers.Id.GetHashCode();

			return hash;
        }
        #endregion
    }
}
