﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    public class Traslado : ResourceObject<Traslado>
    {
        public Traslado()
            : base("/api/v1/traslados/")
        {

        }

        [JsonProperty]
        public DateTime fecha { get; set; } 

        [JsonProperty]
        public Boolean bodega { get; set; } // falta

        [JsonProperty]
        public string nombre { get; set; }

        [JsonProperty]
        public int caja { get; set; }

        [JsonProperty]
        public int vitrina { get; set; }

        [JsonProperty]
        public int responsable { get; set; }

        [JsonProperty]
        public String codigopieza { get; set; }

        public void guardar()
        {
            try
            {
                this.Create();
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    Error.ingresarError(3, "No se ha guardado la Informacion en la base de datos");
                }
            }
        }

        public void modificar()
        {
            try
            {
                this.Save(this.id.ToString());
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    Error.ingresarError(4, "No se ha modificado la Informacion en la base de datos");
                }
            }
        }

      

        // hace las consultas solo por fecha sin incluir tiempo

        public ArrayList consultarpornombre(string nombre)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Traslado> listaNueva = null;
            try
            {

                
                string consultarpornombre = this.resource_uri + "?fecha=" + fecha;
                listaNueva = this.GetAsCollection(consultarpornombre);
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia con el nombre");
                return null;
            }
            return new ArrayList(listaNueva);
        }
       

        public ArrayList consultaraficheporfecha(DateTime fecha)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Traslado> listaNueva = null;
            try
            {

                string fecha2 = fecha.Date.ToString();
                string consultaraficheporfecha = this.resource_uri + "?fecha=" + fecha2;
                listaNueva = this.GetAsCollection(consultaraficheporfecha);
                            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia con la fecha");
                return null;
            }
            return new ArrayList(listaNueva);
        }


        public ArrayList consultarbodega(Boolean bodega)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Traslado> listaNueva = null;
            try
            {

                string bodega2 = bodega.ToString();
                //fecha.Date.ToString();
                string consultarbodega = this.resource_uri + "?bodega=" + bodega2;
                listaNueva = this.GetAsCollection(consultarbodega);

            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia con la bodega");
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList regresarTodos()
        {
            ArrayList listaNueva = new ArrayList();
            try
            {
                
                List<Traslado> todostraslado = this.GetAsCollection();

   
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
                {
                Error.ingresarError(2, "No se econtro ningun traslado registrado");
                return null;
                }

            return new ArrayList(listaNueva);
        }

        public ArrayList regresarEventos()
        {
            List<Traslado> listaNueva = null;
            try
            {
                Traslado clas = new Traslado();
                string consulta = this.resource_uri + "?traslado=" + this.id.ToString();
                listaNueva = clas.GetAsCollection(consulta);
                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
                {
                Error.ingresarError(2, "No se encontro nombre similares");
                }
            return new ArrayList(listaNueva);
        }


        public void regresarObjeto(int id)
        {
            try
            {
                Traslado eventosTemp = this.Get(id.ToString());
                if (eventosTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = eventosTemp.id;
                this.nombre = eventosTemp.nombre;
                this.fecha = eventosTemp.fecha;
                this.bodega = eventosTemp.bodega;
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
        }

        public void regresarObjeto()
        {
            regresarObjeto(this.id);
        }

        /*CONSULTAR PADRE  */

        public Caja consultarCaja()
        {
            Caja clase = new Caja();
            try
            {
                clase.regresarObjecto(this.caja);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con sala: " + caja);
            }
            return (clase);
        }

        public Vitrina consultarVitrina()
        {
            Vitrina clase = new Vitrina();
            try
            {
                clase.regresarObjeto(this.vitrina);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con vitrina: " + vitrina);
            }
            return (clase);
        }



    }
}
