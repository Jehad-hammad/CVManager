using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManager.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly IServiceUnitOfWork serviceUnitOfWork;
        public CVController(IServiceUnitOfWork _serviceUnitOfWork)
        {
            serviceUnitOfWork = _serviceUnitOfWork;
        }


        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                Cv cv = serviceUnitOfWork.CV.Value.Get(Id);
                return Ok(cv);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public IActionResult GetList()
        {
            try
            {
                IEnumerable<Cv> cvs = serviceUnitOfWork.CV.Value.GetAll();
                return Ok(cvs);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public IActionResult PostItem(Cv cv)
        {
            try
            {
                Cv postItem = serviceUnitOfWork.CV.Value.Add(cv);
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        [HttpPost]
        public IActionResult EditItem(Cv cv)
        {
            try
            {
                Cv EditedItem = serviceUnitOfWork.CV.Value.Update(cv);
                return Ok();
            }
            catch (Exception e)
            {

                throw;
            }
        }


        [HttpPost]
        public IActionResult RemoveItem(Cv cv)
        {
            try
            {
                Cv removeItem = serviceUnitOfWork.CV.Value.Remove(cv);
                return Ok();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
