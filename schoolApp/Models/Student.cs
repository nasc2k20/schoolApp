//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace schoolApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string Name { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int GradeId { get; set; }
        public string Comments { get; set; }
    
        public virtual Grade Grade { get; set; }
    }
}
