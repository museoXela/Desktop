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
    public class Publicacion : ResourceObject<Publicacion>
    {

        public Publicacion()
            : base("/api/v1/publicacion/")
        {
            

        }

        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public string nombre { get; set; }

        [JsonProperty]
        public string publicacion { get; set; }

        [JsonProperty]
        public string link { get; set; }

        [JsonProperty]
        public int autor { get; set; }


        public void guardar()
        {
            try
            {
                this.Create();
            }
            catch (Exception e)
            {
             
                Error.ingresarError(3, "No se ha guardado en la Informacion en la base de datos");
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
                Error.ingresarError(4, "No se ha modifico en la Informacion en la base de datos");
            }
        }


        public ArrayList consultarNombre(String nombre)
        {
            List<Publicacion> listaNueva = null;
            try
            {
                string consultarNombre = this.resource_uri + "?nombre=" + nombre;
                listaNueva = this.GetAsCollection(consultarNombre);

            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia por la busqueda por nombre");
                return null;
            }

            return new ArrayList(listaNueva);
        }


        public ArrayList consultapublicacion(string publicacion)  //  la acabo de agregar segun la clase fichas 
        {
            List<Publicacion> listaNueva = null;
            try
            {
                string consultarpublicacion = this.resource_uri + "?publicacion=" + publicacion;
                listaNueva = this.GetAsCollection(consultarpublicacion);
                
                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
                {
                Error.ingresarError(2, "No se encontro coicidencias con la publicacion");
                return null;
                }
            return new ArrayList(listaNueva);
        }


        public ArrayList consultalink(string link)  //  la acabo de agregar segun la clase fichas 
        {
            List<Publicacion> listaNueva = null;
            try
            {
                string consultalink = this.resource_uri + "?link=" + link;
                listaNueva = this.GetAsCollection(consultalink);
                                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
                {
                Error.ingresarError(2, "No se encontro el link de la publicacion");
                return null;
                }

            return new ArrayList(listaNueva);
        }


        public ArrayList consultapublicacionfecha(DateTime fecha)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Publicacion> listaNueva = null;
            try
            {


                string fecha2 = fecha.Date.ToString();
                string consultapublicacionfecha = this.resource_uri+"?fecha=" + fecha2;
                listaNueva = this.GetAsCollection(consultapublicacionfecha);
                                
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

        public ArrayList regresarTodos()
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                List<Publicacion> todaspublicacion = this.GetAsCollection();

                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
                {
                Error.ingresarError(2, "No se econtro ninguna coincidencia al parecer la tabla esta vacia");
                return null;
                }
            return new ArrayList(listaNueva);
        }

        public ArrayList regresarPublicaciones()
        {
            List<Publicacion> listaNueva = null;
            try
            {
                Publicacion clas = new Publicacion();
                string consulta = this.resource_uri + "?nombre=" + this.id.ToString();
                listaNueva = clas.GetAsCollection(consulta);
               
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
                {
                Error.ingresarError(2, "No se encontro nombre similares");
                return null;
                }
            return new ArrayList(listaNueva);
        }

        
        public void regresarObjeto(int id)
        {
            try
            {
                Publicacion eventosTemp = this.Get(id.ToString());
                if (eventosTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = eventosTemp.id;
                this.nombre = eventosTemp.nombre;
                this.fecha = eventosTemp.fecha;
                this.publicacion = eventosTemp.publicacion;
                this.link = eventosTemp.link;
                
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

        /*CONSULTAR PADRE  por sala id*/

        public Autor consultarautor()
        {
             Autor clase = new Autor();
            try
            {
                clase.regresarObjecto(this.autor);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con autor: " + autor);
            }
            return (clase);
        }



       
    }
}