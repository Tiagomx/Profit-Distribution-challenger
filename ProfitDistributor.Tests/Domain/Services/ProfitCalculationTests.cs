using System;
using System.Collections.Generic;
using Moq;
using ProfitDistributor.Domain.Entities;
using ProfitDistributor.Services.Business;
using ProfitDistributor.Services.Interfaces;
using Xunit;

namespace ProfitDistributor.Tests.Domain.Services
{
    public class ProfitCalculationTests
    {
        [Fact]
        public void ProfitCalculationTest_GetEquationResult()
        {
            List<PTAModel> ptaModels = getPTAModelList();
            List<PFSModel> pfsModels = getPFSModelList();
            List<PAAModel> paaModels = getPAAModelList();
            Dictionary<string, decimal> dict = new Dictionary<string, decimal>
            {
                { "Diretoria", 1},
                { "Contabilidade", 2},
                { "Financeiro", 2},
                { "Tecnologia", 2},
                { "Serviços Gerais", 3},
                { "Relacionamento com o Cliente", 5},
            };
            string area = "Financeiro";
            var mockDbWeights = new Mock<IDatabaseWeights>();
            var mockMapper = new Mock<IObjectMappers>();

            var profitCalculation = new ProfitCalculations(mockDbWeights.Object, mockMapper.Object);
            var result = profitCalculation
                .GetEquationResult(2000, DateTime.Parse("2020-01-01"), area, "Funcionario", pfsModels, ptaModels, dict);

            Assert.Equal(5, result);
        }

        private List<PAAModel> getPAAModelList()
        {
            return new List<PAAModel>
            {
                new PAAModel {
                    Area = "Diretoria",
                    Weight = 1
                },
                new PAAModel {
                    Area = "Contabilidade",
                    Weight = 2
                },
                new PAAModel {
                    Area = "Financeiro",
                    Weight = 2
                },
                new PAAModel {
                    Area = "Tecnologia",
                    Weight = 2
                },
                new PAAModel {
                    Area = "Serviços Gerais",
                    Weight = 3
                },
                new PAAModel {
                    Area = "Relacionamento com o Cliente",
                    Weight = 6
                }
            };
        }

        private List<PFSModel> getPFSModelList()
        {
            return new List<PFSModel>
            {
                new PFSModel {
                    Weight = 1,
                    MinSalaries= 0,
                    MaxSalaries= 3
                },
                new PFSModel {
                    Weight = 2,
                    MinSalaries= 3,
                    MaxSalaries= 5
                },
                new PFSModel {
                    Weight = 3,
                    MinSalaries= 5,
                    MaxSalaries= 8
                },
                new PFSModel {
                    Weight = 5,
                    MinSalaries= 8,
                    MaxSalaries= null
                }
            };
        }

        private List<PTAModel> getPTAModelList()
        {
            return new List<PTAModel>
            {
                new PTAModel
                {
                    Weight = 1,
                    MinYears = 0,
                    MaxYears = 1
                },
                new PTAModel
                {
                    Weight = 2,
                    MinYears = 1,
                    MaxYears = 3
                },
                new PTAModel
                {
                    Weight = 3,
                    MinYears = 3,
                    MaxYears = 8
                },
                new PTAModel
                {
                    Weight = 5,
                    MinYears = 8,
                    MaxYears = null
                }
            };
        }
    }
}