﻿using Microsoft.AspNetCore.Mvc;
using ThrAPI.Dto.Estoque.IdentificaoMaterial;
using ThrAPI.Interface.Estoque;

namespace ThrAPI.Controllers.Estoque
{
    [ApiController]
    [Route("api/estoque/identificao")]
    public class IdentificaoEstoqueController :ControllerBase
    {
        private readonly IiDentificaoMaterialService service;
        public IdentificaoEstoqueController(IiDentificaoMaterialService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public ActionResult<List<ReturnIdentificationDto>> SelectAll()
        {
            try
            {
                return Ok(service.SelectList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult<ReturnIdentificationDto> Insert([FromBody] CreateIdentificationDto dto)
        {
            try
            {
                return Ok(service.Insert(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<ReturnIdentificationDto> SelectForId(int id)
        {
            try
            {
                return Ok(service.SelectFromId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public string UpdateId(int id) 
        {
            return "AtualirPorId";
        }
    }
}
