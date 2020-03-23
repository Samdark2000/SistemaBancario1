using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techh_Onvi.Models
{
    public class LPaginador<T>
    {
        private int cantidad = 5;

        private int pagi_nav_num_enlaces = 3;

        private int pagi_Actual;

        private string pagi_nav_anterior = "&laquo; Anterior";

        private string pagi_nav_siguiente = "Siguiente &raquo;";

        private string pagi_nav_primera = "&laquo; Primero";

        private string pagi_nav_ultimo = "Ultimo &raquo;";

        private string pagi_navegacion = null;

        public object[] paginador(List<T> table, int pagina, int Registros, string area, string controller, string action, string host)
        {
            if (Registros > 0)
            {
                cantidad = Registros;
            }

            if (pagina.Equals(0))
            {
                pagi_Actual = 1;
            }
            else
            {
                pagi_Actual = pagina;
            }

            int pagi_totalReg = table.Count;
            int pagi_totalRegs = pagi_totalReg;
            if ((pagi_totalReg % cantidad) > 0)
            {
                pagi_totalRegs += 2;
            }
            int pagi_totalPags = pagi_totalRegs / cantidad;
            if (pagi_Actual != 1)
            {
                int pagi_url = 1;

                pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/" + action
                    + "?id=" + pagi_url + "&Registros=" + cantidad + "&area=" + area + "'>" + pagi_nav_primera + "</a>";


                pagi_url = pagi_Actual - 1;
                pagi_navegacion += "<a class='btn btn-deafault'" + host + "/" + controller + "/" + action
                    + "?id=" + pagi_url + "&Registros=" + cantidad + "&area=" + area + "'>" + pagi_nav_anterior + "</a>";

            }
            double valor2 = (pagi_nav_num_enlaces / 2);
            int pagi_nav_intervalos = Convert.ToInt16(Math.Round(valor2));
            int pagi_nav_desde = pagi_Actual - pagi_nav_intervalos;
            int pagi_nav_hasta = pagi_Actual + pagi_nav_intervalos;

            if (pagi_nav_desde < 1)
            {
                pagi_nav_hasta -= (pagi_nav_desde - 1);

                pagi_nav_desde = 1;
            }

            if (pagi_nav_hasta > pagi_totalPags)
            {
                pagi_nav_desde -= (pagi_nav_hasta - pagi_totalPags);
            }
            if (pagi_nav_desde < 1)
            {
                pagi_nav_desde = 1;
            }

            for (int pagi_i = pagi_nav_desde; pagi_i <= pagi_nav_hasta; pagi_i++)
            {
                if (pagi_i == pagi_Actual)
                {
                    pagi_navegacion += "<span class='btn btn-default' disable='disable'> " + pagi_i + "</span>";
                }
                else
                {
                    pagi_navegacion += "<a class= 'btn btn-default' href='" + host + "/" + controller + "/" + action + "?id=" + pagi_i + "&Registros=" + cantidad + "&area=" + area + "'>" + pagi_i + " </a>";
                }
            }

            if (pagi_Actual < pagi_totalPags)
            {
                int pagi_url = pagi_Actual + 1;
                pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/" + action + "?id=" + pagi_url + "&Registros=" + cantidad + "&area=" + area + "'>" + pagi_nav_siguiente + "</a>";

                pagi_url = pagi_totalPags;
                pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/" + action + "?id=" + pagi_url + "&Registros=" + cantidad + "&area=" + area + "'>" + pagi_nav_ultimo + "</a>";
            }

            int pagi_inicial = (pagi_Actual - 1) * cantidad;

            var query = table.Skip(pagi_inicial).Take(cantidad).ToList();



            string pagi_info = "del <b> " + pagi_Actual + "</b> al <b>" + pagi_totalPags + "</b> de <b>" + pagi_totalReg + "</b> <b>/" + cantidad + "registros por pagina </b>";

            object[] data = { pagi_info, pagi_navegacion, query };

            return data;
        }
    }
}
