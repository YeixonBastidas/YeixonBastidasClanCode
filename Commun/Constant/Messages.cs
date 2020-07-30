using System;
using System.Collections.Generic;
using System.Text;

namespace Commun.Constant
{
    public class Messages
    {
        public static readonly string ErrorInValuesBet = "El valor apostado no es valido e el sistema";

        public static readonly string ErrorClosedRoulettes = "La ruleta especificada no se encuentra abierta";

        public static readonly string ErrorInsufficientBalance = "No tiene saldo suficiente para esta apuesta";

        public static readonly string ErrorMaximumBet = "El Valor máximo en apuestas es de 10.000 dólares";

        public static readonly string SuccessfulBet = "La apuesta fue realizada con éxito";

        public static readonly string UserIdIsNUll = "Recuerde enviar el UserId en los encabezados";

        public static readonly string MessageSummary = "Resumen de apuestas";

        public static readonly string MessageSuccessful = "La petición fue realizada con éxito";

        public static readonly string ErrorNotResult = "No se encontró la información requerida";
    }
}
