﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    class Fotografia:ResourceObject<Fotografia>
    {
        [JsonProperty]
        public int mantenimiento { get; set; }
        [JsonProperty]
        public int pieza { get; set; }
        [JsonProperty]
        public Int16 tipo { get; set; }  // ya
        [JsonProperty]
        public String ruta { get; set; }
        [JsonProperty]
        public Boolean perfil { set; get; } // ya

        public Fotografia()
            : base("/api/v1/fotografias/")
        {
        }

        public void guardar()
        {
            try
            {
                this.Create();
            }
            catch (Exception e)
            {
                //string error = e.Source;// para ver el nombre del error
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

        public ArrayList consultartipo(Int16 tipo)
       //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Fotografia> listaNueva = null;
            try
            {

                string tipo2 = tipo.ToString();
                //fecha.Date.ToString();
                string consultartipo = this.resource_uri+"?tipo=" + tipo2;
                listaNueva = this.GetAsCollection(consultartipo);

                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
                {
                Error.ingresarError(2, "No se encontro ninguna coincidencia por la busqueda por el tipo en fotografia");
                return null;
                }
            return new ArrayList(listaNueva);
        }
                

                    
        public ArrayList consultapormantenimiento(int mantenimiento)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Fotografia> listaNueva = null;
            try
            {

                string mantenimiento2 = mantenimiento.ToString();
                //fecha.Date.ToString();
                string consultapormantenimiento = this.resource_uri + "?mantenimiento=" + mantenimiento2;
                listaNueva = this.GetAsCollection(consultapormantenimiento);
                                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia por la busqueda por mantenimiento");
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultaporpieza(int pieza)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Fotografia> listaNueva = null;
            try
            {

                string pieza2 = pieza.ToString();
                //fecha.Date.ToString();
                string consultapormantenimiento = this.resource_uri + "?pieza=" + pieza2;
                listaNueva = this.GetAsCollection(consultapormantenimiento);

               
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia por la busqueda por pieza");
                return null;
            }
            return new ArrayList(listaNueva);
        }


        public ArrayList consultaporruta(string ruta)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Fotografia> listaNueva = null;
            try
            {
                string consultaporruta = this.resource_uri + "?ruta=" + ruta;
                listaNueva = this.GetAsCollection(consultaporruta);
                                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia por la busqueda por la ruta de la URL");
                return null;
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList consultarporperfil(bool perfil)
        {
            List<Fotografia> listaNueva = null;
            try
            {
                string consultar = this.resource_uri + "?perfil=" + perfil.ToString();
                listaNueva = this.GetAsCollection(consultar);
                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia por la busqueda por el perfil de fotografia");
                return null;
            }

            return new ArrayList(listaNueva);
        }


        public ArrayList regresarTodos()
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                List<Fotografia> todasFichas = this.GetAsCollection();
                               
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro conicidencia al perecer la tabla esta vacia ");
                return null;
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList regresarClasificaciones()
        {
            List<Clasificacion> listaNueva = null;
            try
            {
                Clasificacion clas = new Clasificacion();
                string consulta = this.resource_uri + "?fotografia=" + this.id.ToString();
                listaNueva = clas.GetAsCollection(consulta);
                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia ");
                return null;
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList regresarEventos()
        {
            List<Eventos> listaNueva = null;
            try
            {
                Eventos clas = new Eventos();
                string consulta = this.resource_uri + "?eventos=" + this.id.ToString();
                listaNueva = clas.GetAsCollection(consulta);

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


        public void regresarObjeto(int id)
        {
            try
            {
                Fotografia eventosTemp = this.Get(id.ToString());
                if (eventosTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = eventosTemp.id;
                this.mantenimiento = eventosTemp.mantenimiento;
                this.pieza = eventosTemp.pieza;
                this.tipo = eventosTemp.tipo;
                this.ruta = eventosTemp.ruta;
                this.perfil = eventosTemp.perfil;
                
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


        /*CONSULTAR PADRE  por mantenimiento id*/

        public Mantenimiento consultarmantenimeintoid()
        {
            Mantenimiento clase = new Mantenimiento();
            try
            {
                clase.regresarObjeto(this.mantenimiento);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con sala: " + mantenimiento);
            }
            return (clase);
        }


        public Pieza consultarpieza()
        {
            Pieza clase = new Pieza();
            try
            {
                clase.regresarObjeto(this.pieza);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con sala: " + pieza);
            }
            return (clase);
        }



    }
}
