using PocketMonster.Model.DTOs.InputModels;
using PocketMonster.Model.DTOs.OutputModels;
using PocketMonster.Model.Interfaces.Repository;
using PocketMonster.Model.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace PocketMonster.Service
{
    public class TreinadorService : ITreinadorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TreinadorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public /*Task<*/TreinadorViewModel/*>*/ CadastrarTreinador(TreinadorInputModel dto)
        //{
        //    TreinadorViewModel t1 = new();
        //    return t1;
        //}
    }
}
