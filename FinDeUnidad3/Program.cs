using AppElecciones;


#region Partidos predeterminados
// Falta implementar una verificación de representantes por lo que se usarán datos fútiles
CArbolPartido ArbolPartido = new();
ArbolPartido.Agregar(new CPartido("P01", "Partido1", "R001", 1200, 900));
ArbolPartido.Agregar(new CPartido("P01", "Partido2", "R002", 900, 800));
ArbolPartido.Agregar(new CPartido("P03", "Partido3", "R003", 1800, 1700));
ArbolPartido.Agregar(new CPartido("P04", "Partido4", "R004", 1000, 700));
ArbolPartido.Agregar(new CPartido("P05", "Partido5", "R005", 100, 40));
ArbolPartido.Agregar(new CPartido("P06", "Partido6", "R006", 700, 400));
ArbolPartido.Agregar(new CPartido("P07", "Partido7", "R007", 600, 200));
ArbolPartido.Agregar(new CPartido("P08", "Partido8", "R008", 100, 100));
ArbolPartido.Agregar(new CPartido("P09", "Partido9", "R009", 2000, 1200));
ArbolPartido.Agregar(new CPartido("P010", "Partid10", "R010", 1200, 1100));
#endregion

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

CControlRepresentante nuevoControl_Representantes = new(Representantes);
CControlPartido nuevoControl_Partido = new(ArbolPartido);   
CMenu.MostrarMenu(nuevoControl_Partido, nuevoControl_Representantes, ArbolPartido);
