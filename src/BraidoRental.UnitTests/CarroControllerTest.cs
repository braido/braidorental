//using BraidoRental.API.Controllers;
//using BraidoRental.Services.Estoque.Domain.Contracts.Application;
//using BraidoRental.Services.Estoque.Domain.Entities;
//using BraidoRental.Services.Infrastructure;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;

//namespace BraidoRental.UnitTests
//{
//    public class CarroControllerTest
//    {

//        private readonly DbContextOptions<BraidoRentalContext> _dbOptions;

//        public CarroControllerTest()
//        {

//        }

//        [Fact]
//        public async Task listar_carros_com_sucesso()
//        {
//            //Arrange
//            var totalEsperado = 2;

//            var carroServiceMock = new Mock<IEstoqueService>();
//            carroServiceMock.Setup(x => x.ListarCarros()).Returns(GetFakeCarros());

//            //Act
//            var carroController = new EstoqueController(carroServiceMock.Object);


//            var actionResult = await carroController.ListarTodos();

//            //Assert
//            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
//            Assert.Equal((((ObjectResult)actionResult.Result).Value as IList<Carro>).Count, totalEsperado);
//        }

//        [Fact]
//        public async Task listar_carros_disponiveis_com_sucesso()
//        {
//            //Arrange
//            var totalEsperado = 1;

//            var carroServiceMock = new Mock<IEstoqueService>();
//            carroServiceMock.Setup(x => x.ListarCarrosDisponiveis()).Returns(GetFakeCarros().Where(x => x.IsDisponivel).ToList());

//            //Act
//            var carroController = new EstoqueController(carroServiceMock.Object);


//            var actionResult = await carroController.ListarDisponiveis();

//            //Assert
//            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
//            Assert.Equal((((ObjectResult)actionResult.Result).Value as IList<Carro>).Count, totalEsperado);
//        }


//        [Fact]
//        public async Task obter_carro_por_id_com_sucesso()
//        {
//            //Arrange
//            var idCarro = 2;

//            var carroServiceMock = new Mock<IEstoqueService>();
//            carroServiceMock.Setup(x => x.ObterCarro(idCarro)).Returns(GetFakeCarros().First(x => x.Id == idCarro));

//            //Act
//            var carroController = new EstoqueController(carroServiceMock.Object);


//            var actionResult = await carroController.Obter(idCarro);

//            //Assert
//            Assert.Equal((actionResult.Result as ObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
//            Assert.Equal((((ObjectResult)actionResult.Result).Value as Carro).Id, idCarro);
//        }

//        [Fact]
//        public async Task obter_carro_por_id_nao_encontrado()
//        {
//            //Arrange
//            var idCarro = 5;

//            var carroServiceMock = new Mock<IEstoqueService>();
//            carroServiceMock.Setup(x => x.ObterCarro(idCarro)).Returns<Carro>(null);

//            //Act
//            var carroController = new EstoqueController(carroServiceMock.Object);


//            var actionResult = await carroController.Obter(idCarro);

//            //Assert
//            Assert.Equal((actionResult.Result as ObjectResult).StatusCode, (int)System.Net.HttpStatusCode.NotFound);
//            Assert.Equal((((ObjectResult)actionResult.Result).Value), idCarro);
//        }

//        [Fact]
//        public async Task inserir_carro_com_sucesso()
//        {
//            //Arrange
//            var carroBefore = new Carro()
//            {
//                Marca = "Fiat",
//                Modelo = "Argo",
//                Placa = "ABC-1234"
//            };

//            var carroAfter = new Carro()
//            {
//                Id = 1,
//                Marca = "Fiat",
//                Modelo = "Argo",
//                Placa = "ABC-1234"
//            };


//            var carroServiceMock = new Mock<IEstoqueService>();
//            carroServiceMock.Setup(x => x.SalvarCarro(carroBefore)).Returns(carroAfter);

//            //Act
//            var carroController = new EstoqueController(carroServiceMock.Object);


//            var actionResult = await carroController.Salvar(carroBefore);

//            //Assert
//            Assert.Equal((actionResult.Result as ObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
//            Assert.Equal((((ObjectResult)actionResult.Result).Value), carroAfter);
//        }

//        [Fact]
//        public async Task atualizar_carro_com_sucesso()
//        {
//            //Arrange
//            var carroBefore = new Carro()
//            {
//                Id = 1,
//                Marca = "Fiat",
//                Modelo = "Argo",
//                Placa = "ABC-1234"
//            };

//            var carroAfter = new Carro()
//            {
//                Id = 1,
//                Marca = "Fiat",
//                Modelo = "Argo",
//                Placa = "ABC-1234"
//            };


//            var carroServiceMock = new Mock<IEstoqueService>();
//            carroServiceMock.Setup(x => x.SalvarCarro(carroBefore)).Returns(carroAfter);

//            //Act
//            var carroController = new EstoqueController(carroServiceMock.Object);

            
//            var actionResult = await carroController.Salvar(carroBefore);

//            //Assert
//            Assert.Equal((actionResult.Result as ObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
//            Assert.Equal((((ObjectResult)actionResult.Result).Value), carroAfter);
//        }

//        private IList<Carro> GetFakeCarros()
//        {
//            return new List<Carro>()
//            {
//                new Carro() {
//                    Id = 1,
//                    Marca = "Fiat",
//                    Modelo = "Argo",
//                    Placa= "ABC-1234",
//                    IsDisponivel = true
//                },
//                new Carro() {
//                    Id = 2,
//                    Marca = "Renout",
//                    Modelo = "Sandero",
//                    Placa = "XYZ-0000",
//                    IsDisponivel = false
//                }
//            };
//        }
//    }
//}
