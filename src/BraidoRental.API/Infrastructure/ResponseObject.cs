using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BraidoRental.API.Infrastructure
{
    public class ResponseObject
    {
        public static ResponseObject SucessoMsg = new ResponseObject(true, "Requisição com Sucesso");
        public static ResponseObject FalhaMsg = new ResponseObject(false, "Requisição com Falha");

        public static ResponseObject SucessoObj(object obj)
        {
            return new ResponseObject(true, "Requisição com Sucesso", obj);
        }

        public static ResponseObject FalhaObj(object obj)
        {
            return new ResponseObject(false, "Requisição com Falha", obj);
        }

        public static ResponseObject FalhaMsgCustom(string msg)
        {

            return new ResponseObject(false, msg);
        }

        public bool Sucesso { get; protected set; }

        public object Objeto { get; protected set; }

        public string Mensagem { get; protected set; }

        public ResponseObject(bool sucesso, string msg = null, object obj = null)
        {
            Sucesso = sucesso;
            Mensagem =msg;
            Objeto = obj;
        }
    }
}
