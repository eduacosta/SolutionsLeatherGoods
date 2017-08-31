using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    
    public class AspNetUserRoles {
        [NotNull(Message="Se debe cargar algún valor para el campo Asp Net Users, no puede estar vacío")]
        [Length(Max=128, Message="La longitud del campo Asp Net Users no debe ser mayor a 128 caracteres")]
        public virtual AspNetUsers AspNetUsers { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Asp Net Roles, no puede estar vacío")]
        [Length(Max=128, Message="La longitud del campo Asp Net Roles no debe ser mayor a 128 caracteres")]
        public virtual AspNetRoles AspNetRoles { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as AspNetUserRoles;
			if (t == null) return false;
			if (AspNetUsers.UserId == t.AspNetUsers.UserId
			 && AspNetRoles.RoleId == t.AspNetRoles.RoleId)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ AspNetUsers.UserId.GetHashCode();
			hash = (hash * 397) ^ AspNetRoles.RoleId.GetHashCode();

			return hash;
        }
        #endregion
    }
}
