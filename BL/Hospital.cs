using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Hospital
    {
        public static void Add(ML.Hospital hospital)
        {
            Dictionary<string, object> resultado = new Dictionary<string, object> { { "Excepcion", "" }, { "Resultado", false }, { "Hospital", null } };
            try
            {
                using (DL.KpalomaresCrudContext context = new DL.KpalomaresCrudContext())
                {
                    var registro = context;



                 }

            }
            catch (Exception ex)
            {
                resultado["Resultado"] = false;
                resultado["Excepcion"] = ex.Message;
            }


        }



        public static void GetAll()
        {
            //ML.Hospital hospital1 = new ML.Hospital();
            Dictionary<string, object> resultado = new Dictionary<string, object> { { "Excepcion", "" }, { "Resultado", false }, { "Hospital", null } };
            try
            {
                using (DL.KpalomaresCrudContext context = new DL.KpalomaresCrudContext())
                {
                    //var registro =("$HospitalGetAll({hospital.IdHopital},'{Hospital.Nombre}','{Hospital.Direccion}','{Hospital.AñoConstruccion}',{Hospital.Capacidad})");
                    var registro = (from Hospital in context.Hospitals
                                    select new
                                    {
                                        IdHospital = Hospital.IdHospital,
                                        Nombre = Hospital.Nombre,
                                        Direccion = Hospital.Direccion,
                                        AñoConstruccion = Hospital.AñoDeConstruccion,
                                        Capacidad = Hospital.Capacidad

                                    }).ToList();
                    

                    foreach (var hospital in registro)
                    {
                        hospital.IdHospital = registro.IdHospital;
                        hospital.Nombre = registro.Nombre;
                        hospital.Direccion = registro.Direccion;
                        hospital.AñoConstruccion = registro.AñoContruccion;
                        hospital.Capacidad = registro.Capacidad;

                        hospital.Add(hospital);
                    }
                }            


                
            }
            catch (Exception ex)
            {
                resultado["Resultado"] = false;
                resultado["Excepcion"] = ex.Message;

            }

        }





    }
}
