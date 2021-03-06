﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFService.Model;
using System.Threading;

namespace WCFService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        IEnumerable<ROL> GetRolbyId(int id);

        [OperationContract]
        IEnumerable<CUENTAS> GetAccountbyId(string id);

        [OperationContract]
        int SetAccount(CUENTAS cuenta);

        [OperationContract]
        int SetUsuario(USUARIOS cuenta);

        [OperationContract]
        Result UptAccount(string idAccount, string numCuenta);

        [OperationContract]
        Result DelAccount(string idAccount);

        [OperationContract]
        Result AddAmount(string idAccount, double valor);

        [OperationContract]
        Result RemoveAmount(string idAccount, double valor);

        [OperationContract]
        IEnumerable<CUENTAS> GetSateAccountbyId(string idAccount);

        [OperationContract]
        IEnumerable<SALDO> GetBalance(string idAccount);

        [OperationContract]
        IEnumerable<USUARIO> GetUserByUserAndPass(string user, string pass);

        [OperationContract]
        IEnumerable<USUARIOS> GetRolByIdUser(int idUser);

    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Result
    {
        [DataMember]
        public int codigo { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
