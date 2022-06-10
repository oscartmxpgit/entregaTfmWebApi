using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using eCartaBE.Controllers;
using eCartaBE.InfrastructuraSeguridad;
using eCartaBE.Tests;
using eCartaBE.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eCartaBEPrj;
using System.Linq;
using eCartaBEPrj.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using eCartaBEPrj.Controllers;

namespace eCartaBEProjMSTests
{
    [TestClass]
    public class OperacionesCajasControllerTests
    {
        private readonly TestHostFixture _testHostFixture = new TestHostFixture();
        private HttpClient _httpClient;
        private IServiceProvider _serviceProvider;

        [TestInitialize]
        public void SetUp()
        {
            _httpClient = _testHostFixture.Client;
            _serviceProvider = _testHostFixture.ServiceProvider;
        }

        [TestMethod]
        public void ComprobarOperacionesCaja()
        {
            var data = new List<OperacionesCaja>
            {
                new OperacionesCaja { IdNegocio = 1,Importe=40,Cantidad=100,Tipo="Incremento",FechaHora=DateTime.Now, Estado="Pendiente"},
                new OperacionesCaja { IdNegocio = 1,Importe=85,Cantidad=12,Tipo="Incremento",FechaHora=DateTime.Now.AddDays(-10), Estado="Validado" },
                new OperacionesCaja { IdNegocio = 1,Importe=21,Cantidad=53,Tipo="Incremento",FechaHora=DateTime.Now.AddDays(-30), Estado="Validado" },
                new OperacionesCaja { IdNegocio = 1,Importe=42,Cantidad=25,Tipo="Decremento",FechaHora=DateTime.Now.AddDays(-80), Estado="Validado" },
                new OperacionesCaja { IdNegocio = 1,Importe=67,Cantidad=32,Tipo="Incremento",FechaHora=DateTime.Now.AddDays(-100), Estado="Validado" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<OperacionesCaja>>();
            mockSet.As<IQueryable<OperacionesCaja>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<OperacionesCaja>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<OperacionesCaja>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<OperacionesCaja>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BDeCarta>();
            mockContext.Setup(c => c.OperacionesCajas).Returns(mockSet.Object);

            var service = new OperacionesCajasController(mockContext.Object);
            var operaciones = service.GetTotalCajaPorNegocio(1);

            //40*100=4000 <-no cuenta porque no está validado
            //85*12=1020
            //21*53=1113

            //67*32=2144
            //Total: 4277

            Assert.AreEqual(4277, operaciones.incremento);

            //42*25
            Assert.AreEqual(1050, operaciones.decremento);
            
            Assert.AreEqual(99.48694029850746, operaciones.tasaCrecimiento);

        } 
        
    }
}
