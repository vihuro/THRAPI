﻿namespace ThrAPI.Dto.Estoque.IdentificaoMaterial
{
    public class UpdateIdentificaoDto
    {
        public int IdentificaoId { get; set; }
        public decimal Quantidade { get; set; }
        public Guid LocalEstocagemId { get; set; }
        public Guid UsuarioAlteracao { get; set; }

    }
}
