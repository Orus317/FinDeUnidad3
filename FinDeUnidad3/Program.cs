using AppElecciones;


#region Representantes predeterminados
CArbolRepresentante Representantes = new();
Representantes.Agregar("111", "Ramirez", "Lastra", "Alberto", "95961212", "Av. Brasil");
Representantes.Agregar("112", "Palacios", "Grau", "Maria", "36192134", "Av. Argentina");
Representantes.Agregar("113", "Durand", "Rondón", "Jose", "34480959", "Av. Cusco");
Representantes.Agregar("114", "De los Rios", "Huaman", "Andric", "85586251", "Av. Manco");
Representantes.Agregar("115", "Quispe", "Villena", "Fernando", "85143178", "Av. Oreo");
Representantes.Agregar("116", "Puma", "Villavicencio", "Lia", "45686143", "Av. Zulha");
Representantes.Agregar("117", "Espinoza", "Ramirez", "Ian", "82784817", "Av. Lima");
Representantes.Agregar("118", "Mamamni", "Brenner", "Wilse", "01278535", "Av. 2 de mayo");
Representantes.Agregar("119", "Suarez", "Cavani", "Horus", "01278535", "Av. La Cultura");
Representantes.Agregar("120", "Do Santos", "Cuchitini", "Antonella", "23478535", "Av. Pallar");
#endregion

#region Partidos predeterminados
CArbolPartido ArbolPartido = new();
ArbolPartido.Agregar("P01", "Acción Popular", "111", 2800, 900, Representantes, ArbolPartido);
ArbolPartido.Agregar("P02", "Fuerza Popular", "112", 1900, 800, Representantes, ArbolPartido);
ArbolPartido.Agregar("P03", "Renovación Popular", "113", 5800, 1700, Representantes, ArbolPartido);
ArbolPartido.Agregar("P04", "Paloma Popular", "114", 8000, 700, Representantes, ArbolPartido);
ArbolPartido.Agregar("P05", "Perú Libre", "115", 100, 40, Representantes, ArbolPartido);
ArbolPartido.Agregar("P06", "Pueblo Libre", "116", 700, 400, Representantes, ArbolPartido);
ArbolPartido.Agregar("P07", "País Libre", "117", 600, 200, Representantes, ArbolPartido);
ArbolPartido.Agregar("P08", "APRA", "118", 100, 100, Representantes, ArbolPartido);
ArbolPartido.Agregar("P09", "FREDEMO", "119", 2000, 1200, Representantes, ArbolPartido);
ArbolPartido.Agregar("P10", "UE", "120", 1200, 1100, Representantes, ArbolPartido);
#endregion

CControlRepresentante nuevoControl_Representantes = new(Representantes);
CControlPartido nuevoControl_Partido = new(ArbolPartido);   
CMenu.EjecutarMenu(nuevoControl_Partido, nuevoControl_Representantes, ArbolPartido, Representantes);
