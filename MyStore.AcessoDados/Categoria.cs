//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyStore.AcessoDados
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categoria
    {
        public Categoria()
        {
            this.Produto = new HashSet<Produto>();
        }
    
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public int IdDepartamento { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    
        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
