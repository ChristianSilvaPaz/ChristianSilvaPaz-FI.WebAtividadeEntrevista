using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        [HttpPost]
        public JsonResult Incluir(BeneficiarioModel model)
        {
            BoBeneficiario boBeneficiario = new BoBeneficiario();
            BoCliente boCliente = new BoCliente();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                bool BeneficiarioExiste = boBeneficiario.VerificarExistencia(model.Cpf);

                if (BeneficiarioExiste)
                {
                    Response.StatusCode = 400;
                    return Json("Esse beneficiário já está cadastrado");
                }

                model.Id = boBeneficiario.Incluir(new Beneficiario
                {
                    Nome = model.Nome,
                    CPF = model.Cpf,
                    IdCLiente = model.ClienteId
                });

                return Json("Cadastro efetuado com sucesso");
            }
        }
    }
}