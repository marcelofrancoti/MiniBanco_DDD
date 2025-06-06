// <copyright file="EntidadeBase.cs" company="Vertrau Gestao de Fundos de Investimento LTDA">
// Copyright (c) Vertrau Gestao de Fundos de Investimento LTDA. All rights reserved.
// </copyright>

namespace  Cliente.Domain.Comum
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Representa a entidade base.
    /// </summary>
    public class EntidadeBase
    {
        /// <summary>
        /// Representa o identificador da entidade.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// Representa a data de registro.
        /// </summary>
        [Required]
        public DateTime? DataRegistro { get; set; }

        /// <summary>
        /// Representa a data de alteração.
        /// </summary>
        public DateTime? DataAlteracao { get; set; }
    }
}
