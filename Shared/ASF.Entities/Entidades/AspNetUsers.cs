using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    
    public class AspNetUsers {
        public AspNetUsers() {
			AspNetUserClaims = new List<AspNetUserClaims>();
			AspNetUserLogins = new List<AspNetUserLogins>();
			AspNetUserRoles = new List<AspNetUserRoles>();
        }
        public virtual string Id { get; set; }
        [Length(Max=256, Message="La longitud del campo Email no debe ser mayor a 256 caracteres")]
        public virtual string Email { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Email Confirmed, no puede estar vacío")]
        public virtual bool EmailConfirmed { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string PhoneNumber { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Phone Number Confirmed, no puede estar v" +
            "acío")]
        public virtual bool PhoneNumberConfirmed { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Two Factor Enabled, no puede estar vacío" +
            "")]
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Lockout Enabled, no puede estar vacío")]
        public virtual bool LockoutEnabled { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Access Failed Count, no puede estar vací" +
            "o")]
        public virtual int AccessFailedCount { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo User Name, no puede estar vacío")]
        [Length(Max=256, Message="La longitud del campo User Name no debe ser mayor a 256 caracteres")]
        public virtual string UserName { get; set; }
        public virtual IList<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual IList<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual IList<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
